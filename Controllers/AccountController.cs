using Microsoft.AspNetCore.Mvc;

namespace SistemaEstoque.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register() => View();
    }
}
