using Microsoft.Extensions.DependencyInjection;
using TesteHiper.Service.Interface;
using TesteHiper.Service.Servico;

namespace TesteHiper.Service.Config
{
    public class ServiceConfiguration
    {
        public void MapearServicos(IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<ISync, Sincronizador>();
        }
    }
}
