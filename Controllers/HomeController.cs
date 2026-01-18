using Microsoft.AspNetCore.Mvc;

namespace SistemaEstoque.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
