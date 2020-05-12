using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using TesteHiper.Data.Model;
using TesteHiper.Service.Interface;

namespace TesteHIperApi.Controllers
{
    [ApiController]
    [Route("produto")]
    public class ProdutoApiController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoApiController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [Route("listar")]
        [HttpGet]
        public IList<ProdutoModel> Listar()
        {
            return _produtoService.ListarProdutos();
        }

        [Route("sincronizar")]
        [HttpPost]
        public IActionResult Sincronizar(SyncModel model)
        {
            var obj = JsonConvert.DeserializeObject<ProdutoModel>(model.Item);

            switch (model.Acao)
            {
                case TesteHiper.Common.Enumerator.ETipoAcao.Create:
                    _produtoService.CadastrarProduto(obj);
                    break;
                case TesteHiper.Common.Enumerator.ETipoAcao.Update:
                    _produtoService.AtualizarProduto(obj);
                    break;
                case TesteHiper.Common.Enumerator.ETipoAcao.Delete:
                    _produtoService.ExcluirProduto(obj.Guid);
                    break;
            }

            return new ObjectResult("");
        }
    }
}
