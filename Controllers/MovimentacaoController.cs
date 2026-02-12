using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Services.Movimentacoes;
using SistemaEstoque.Services.Produtos;
using System.Threading.Tasks;

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
    }
}
