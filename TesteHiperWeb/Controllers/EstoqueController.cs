using Microsoft.AspNetCore.Mvc;
using TesteHiper.Data.Model;
using TesteHiper.Service.Interface;

namespace TesteHiperWeb.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly IEstoqueService _estoqueService;

        public EstoqueController(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        public IActionResult Index()
        {
            var lista = _estoqueService.ListarEstoques();
            return View(lista);
        }

        public IActionResult Novo()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var obj = _estoqueService.BuscarEstoque(id);
            return View("Novo", obj);
        }

        public IActionResult Delete(int id)
        {
            var obj = _estoqueService.BuscarEstoque(id);

            if(obj.Produtos.Count > 0)
            {
                TempData["MsgChangeStatus"] = "O estoque não pode ser excluído, pois existe produto vinculado.";
                return RedirectToAction("Index");
            }

            _estoqueService.ExcluirEstoque(id);
            return RedirectToAction("Index", "Estoque");
        }


        public IActionResult Cadastrar(EstoqueModel model)
        {
            _estoqueService.CadastrarEstoque(model);
            return RedirectToAction("Index", "Estoque");
        }

        public IActionResult Atualizar(EstoqueModel model)
        {
            _estoqueService.AtualizarEstoque(model);
            return RedirectToAction("Index", "Estoque");
        }
    }
}