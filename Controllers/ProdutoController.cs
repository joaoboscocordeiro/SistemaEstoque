using Microsoft.AspNetCore.Mvc;

namespace SistemaEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
