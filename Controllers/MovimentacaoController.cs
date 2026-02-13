using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaEstoque.Models;
using SistemaEstoque.Services.Movimentacoes;
using SistemaEstoque.Services.Produtos;

namespace SistemaEstoque.Controllers
{
    public class MovimentacaoController : Controller
    {
        private readonly IMovimentacaoInterface _movimentacaoInterface;
        private readonly IProdutoInterface _produtoInterface;

        public MovimentacaoController(IMovimentacaoInterface movimentacaoInterface, IProdutoInterface produtoInterface)
        {
            _movimentacaoInterface = movimentacaoInterface;
            _produtoInterface = produtoInterface;
        }

        public async Task<IActionResult> Index()
        {
            var historico = await _movimentacaoInterface.ObterTodasAsync();
            return View(historico);
        }

        public async Task<IActionResult> Create()
        {
            var produtos = await _produtoInterface.ObterTodosAsync();

            ViewBag.Produtos = new SelectList(produtos, "Id", "Nome");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovimentacoesEstoque mov)
        {
            if (ModelState.IsValid)
            {
                mov.Usuario = User.Identity.Name ?? "Sistema";
                await _movimentacaoInterface.AdicionarMovimentacaoAsync(mov);
                return RedirectToAction("Index");
            }

            var produtos = await _produtoInterface.ObterTodosAsync();
            ViewBag.Produtos = new SelectList(produtos, "Id", "Nome");

            return View();
        }
    }
}
