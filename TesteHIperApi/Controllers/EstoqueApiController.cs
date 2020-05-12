using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using TesteHiper.Data.Model;
using TesteHiper.Service.Interface;

namespace TesteHIperApi.Controllers
{
    [Route("estoque")]
    [ApiController]
    public class EstoqueApiController : ControllerBase
    {
        private readonly IEstoqueService _estoqueService;

        public EstoqueApiController(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        [Route("listar")]
        [HttpGet]
        public IList<EstoqueModel> Listar()
        {
            return _estoqueService.ListarEstoques();
        }

        [Route("sincronizar")]
        [HttpPost]
        public IActionResult Sincronizar(SyncModel model)
        {
            //var model = JsonConvert.DeserializeObject<SyncModel>(json);
            var obj = JsonConvert.DeserializeObject<EstoqueModel>(model.Item);

            switch (model.Acao)
            {
                case TesteHiper.Common.Enumerator.ETipoAcao.Create:
                    _estoqueService.CadastrarEstoque(obj);
                    break;
                case TesteHiper.Common.Enumerator.ETipoAcao.Update:
                    _estoqueService.AtualizarEstoque(obj);
                    break;
                case TesteHiper.Common.Enumerator.ETipoAcao.Delete:
                    _estoqueService.ExcluirEstoque(obj.Guid);
                    break;
            }

            return new ObjectResult("");
        }
    }
}