using System.Collections.Generic;
using TesteHiper.Data.Model;

namespace TesteHiper.Service.Interface
{
    public interface IEstoqueService
    {
        void CadastrarEstoque(EstoqueModel model);
        IList<EstoqueModel> ListarEstoques();
        void AtualizarEstoque(EstoqueModel model);
        void ExcluirEstoque(int id);
        void ExcluirEstoque(string guid);
        void ExcluirEstoque(EstoqueModel model);
        EstoqueModel BuscarEstoque(int id);
    }
}
