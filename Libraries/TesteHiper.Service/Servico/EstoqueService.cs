using System.Collections.Generic;
using System.Linq;
using TesteHiper.Data;
using TesteHiper.Data.Entidade;
using TesteHiper.Data.Model;
using TesteHiper.Service.Interface;

namespace TesteHiper.Service.Servico
{
    internal class EstoqueService : IEstoqueService
    {
        private readonly IRepository<Estoque> _repEstoque;
        private readonly ISync _sync;

        public EstoqueService(IRepository<Estoque> repEstoque, ISync sync)
        {
            _repEstoque = repEstoque;
            _sync = sync;
        }

        public void AtualizarEstoque(EstoqueModel model)
        {
            var obj = _repEstoque.GetByGuid(model.Guid);

            obj.Nome = model.Nome;

            _repEstoque.Update(obj);

            _sync.Enviar(model, Common.Enumerator.ETipoAcao.Update);
        }

        public EstoqueModel BuscarEstoque(int id)
        {
            var entity = _repEstoque.GetById(id);
            return new EstoqueModel
            {
                Id = id,
                Nome = entity.Nome,
                Guid = entity.Guid,
                Produtos = entity.Produtos.Select(e => new ProdutoModel { Id = e.Id }).ToList()
            };
        }

        public void CadastrarEstoque(EstoqueModel model)
        {
            var obj = new Estoque
            {
                Nome = model.Nome,
                Guid = model.Guid
            };

            model.Guid = _repEstoque.Insert(obj);

            _sync.Enviar(model, Common.Enumerator.ETipoAcao.Create);
        }

        public void ExcluirEstoque(int id)
        {
            var obj = _repEstoque.GetById(id);

            var model = new EstoqueModel
            {
                Id = id,
                Nome = obj.Nome,
                Guid = obj.Guid
            };
            
            _repEstoque.Delete(obj);

            _sync.Enviar(model, Common.Enumerator.ETipoAcao.Delete);
        }

        public void ExcluirEstoque(string guid)
        {
            var obj = _repEstoque.Table.SingleOrDefault(e => e.Guid.Equals(guid));
            _repEstoque.Delete(obj);
        }

        public void ExcluirEstoque(EstoqueModel model)
        {
            ExcluirEstoque(model.Guid);
        }

        public IList<EstoqueModel> ListarEstoques()
        {
            var lista = _repEstoque.Table.ToList();

            return lista.Select(e => new EstoqueModel
            {
                Id = e.Id,
                Guid = e.Guid,
                Nome = e.Nome,
            }).ToList();
        }
    }
}
