using System.Collections.Generic;
using System.Linq;
using TesteHiper.Data;
using TesteHiper.Data.Entidade;
using TesteHiper.Data.Model;
using TesteHiper.Service.Interface;

namespace TesteHiper.Service.Servico
{
    internal class ProdutoService : IProdutoService
    {
        private readonly IRepository<Produto> _repProduto;
        private readonly IRepository<Estoque> _repEstoque;
        private readonly ISync _sync;

        public ProdutoService(IRepository<Produto> repProduto, IRepository<Estoque> repEstoque, ISync sync)
        {
            _repProduto = repProduto;
            _repEstoque = repEstoque;
            _sync = sync;
        }

        public void AtualizarProduto(ProdutoModel produto)
        {
            var obj = _repProduto.GetByGuid(produto.Guid);

            obj.Nome = produto.Nome;
            obj.Preco = produto.Valor;

            if (obj.Estoque.Id != produto.Estoque.Id)
            {
                obj.Estoque = _repEstoque.GetById(produto.Estoque.Id);
            }

            _repProduto.Update(obj);

            _sync.Enviar(produto, Common.Enumerator.ETipoAcao.Update);
        }

        public ProdutoModel BuscarProduto(int id)
        {
            var entity = _repProduto.GetById(id);
            return new ProdutoModel
            {
                Id = id,
                Guid = entity.Guid,
                Estoque = new EstoqueModel
                {
                    Id = entity.Estoque.Id,
                    Nome = entity.Estoque.Nome
                },
                Nome = entity.Nome,
                Valor = entity.Preco
            };
        }

        public void CadastrarProduto(ProdutoModel produto)
        {
            var obj = new Produto
            {
                Nome = produto.Nome,
                Preco = produto.Valor,
                Guid = produto.Guid
            };

            if (produto.Estoque != null)
                obj.Estoque = _repEstoque.GetById(produto.Estoque.Id);

            produto.Guid = _repProduto.Insert(obj);

            _sync.Enviar(produto, Common.Enumerator.ETipoAcao.Create);
        }

        public void ExcluirProduto(int id)
        {
            var obj = _repProduto.GetById(id);

            var model = new ProdutoModel
            {
                Id = id,
                Nome = obj.Nome,
                Guid = obj.Guid
            };

            _repProduto.Delete(obj);

            _sync.Enviar(model, Common.Enumerator.ETipoAcao.Delete);
        }

        public void ExcluirProduto(string guid)
        {
            var obj = _repProduto.Table.SingleOrDefault(e => e.Guid.Equals(guid));
            _repProduto.Delete(obj);
        }

        public void ExcluirProduto(ProdutoModel model)
        {
            ExcluirProduto(model.Guid);
        }

        public IList<ProdutoModel> ListarProdutos()
        {
            var lista = _repProduto.Table.ToList();

            return lista.Select(e => new ProdutoModel
            {
                Id = e.Id,
                Guid = e.Guid,
                Nome = e.Nome,
                Valor = e.Preco,
                Estoque = new EstoqueModel
                {
                    Id = e.Estoque?.Id ?? 0,
                    Nome = e.Estoque?.Nome
                }
            }).ToList();
        }
    }
}
