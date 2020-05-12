using System.Collections.Generic;
using TesteHiper.Data.Model;

namespace TesteHiper.Service.Interface
{
    public interface IProdutoService
    {
        void CadastrarProduto(ProdutoModel produto);
        IList<ProdutoModel> ListarProdutos();
        void AtualizarProduto(ProdutoModel produto);
        void ExcluirProduto(int id);
        void ExcluirProduto(string guid);
        void ExcluirProduto(ProdutoModel model);
        ProdutoModel BuscarProduto(int id);
    }
}
