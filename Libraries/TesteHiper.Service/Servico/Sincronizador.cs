using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using TesteHiper.Common;
using TesteHiper.Common.Enumerator;
using TesteHiper.Data.Model;
using TesteHiper.Service.Interface;

namespace TesteHiper.Service.Servico
{
    internal class Sincronizador : ISync
    {
        private readonly AppConfigModel _config;

        public Sincronizador(IOptions<AppConfigModel> config)
        {
            _config = config.Value;
        }

        public async void Enviar(object obj, ETipoAcao acao)
        {
            if (_config == null || string.IsNullOrWhiteSpace(_config.CaminhoApi)) return;

            string sUrl = string.Empty;
            switch (obj)
            {
                case ProdutoModel _:
                    sUrl = "produto";
                    break;
                case EstoqueModel _:
                    sUrl = "estoque";
                    break;
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_config.CaminhoApi);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                await client.PostAsJsonAsync($"{sUrl}/sincronizar", new SyncModel { Item = JsonConvert.SerializeObject(obj), Acao = acao });
            }
        }
    }
}
