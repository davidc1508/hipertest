using Microsoft.AspNetCore.Mvc;
using TesteHiper.Data.Model;
using TesteHiper.Service.Interface;

namespace TesteHiperWeb.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly IEstoqueService _estoqueService;

        public ProdutoController(IProdutoService produtoService, IEstoqueService estoqueService)
        {
            _produtoService = produtoService;
            _estoqueService = estoqueService;
        }

        public IActionResult Index()
        {
            var itens = _produtoService.ListarProdutos();
            return View(itens);
        }

        public IActionResult Novo()
        {
            var estoques = _estoqueService.ListarEstoques();
            ViewBag.Estoques = estoques;

            return View();
        }

        public IActionResult Edit(int id)
        {
            var estoques = _estoqueService.ListarEstoques();
            ViewBag.Estoques = estoques;

            var obj = _produtoService.BuscarProduto(id);
            return View("Novo", obj);
        }

        public IActionResult Delete(int id)
        {
            _produtoService.ExcluirProduto(id);
            return RedirectToAction("Index");
        }


        public IActionResult Cadastrar(ProdutoModel model)
        {
            _produtoService.CadastrarProduto(model);
            return RedirectToAction("Index");
        }

        public IActionResult Atualizar(ProdutoModel model)
        {
            _produtoService.AtualizarProduto(model);
            return RedirectToAction("Index");
        }
    }
}