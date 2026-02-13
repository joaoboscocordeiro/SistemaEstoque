using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Services.Produtos;
using System.Threading.Tasks;

namespace SistemaEstoque.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoInterface _produtoInterface;

        public HomeController(IProdutoInterface produtoInterface) 
        {
            _produtoInterface = produtoInterface;
        }

        public async Task<IActionResult> Index(string termoBusca = "", int page = 1)
        {
            var produtos = await _produtoInterface.ObterTodosAsync();

            var estoqueBaixo = produtos.Where(p => p.Quantidade <= 5).ToList();
            var totalProdutos = produtos.Count();
            var valorTotalEstoque = produtos.Sum(p => (p.Preco ?? 0) * p.Quantidade);

            if (!string.IsNullOrEmpty(termoBusca))
            {
                produtos = produtos.Where(p => p.Nome.Contains(termoBusca, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            int pageSize = 5;
            var produtosPaginados = produtos
                .OrderBy(p => p.Nome)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.TotalProdutos = totalProdutos;
            ViewBag.ValorTotalEstoque = valorTotalEstoque;
            ViewBag.TotalEstoqueBaixo = estoqueBaixo.Count();
            ViewBag.TermoBusca = termoBusca;
            ViewBag.PaginaAtual = page;
            ViewBag.TotalPaginas = (int)Math.Ceiling((double)produtos.Count / pageSize);

            return View(produtosPaginados);
        }
    }
}
