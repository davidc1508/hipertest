using TesteHiper.Common.Enumerator;

namespace TesteHiper.Service.Interface
{
    public interface ISync
    {
        void Enviar(object obj, ETipoAcao acao);
    }
}
