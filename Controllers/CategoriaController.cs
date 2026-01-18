using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Services.Categorias;

namespace SistemaEstoque.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaInterface _categoriaInterface;

        public CategoriaController(ICategoriaInterface categoriaInterface)
        {
            _categoriaInterface = categoriaInterface;
        }

        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaInterface.ObterTodasCategorias();
            return View(categorias);
        }
    }
}
