using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SistemaEstoque.Dtos;
using SistemaEstoque.Models;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoriaDto createCategoriaDto)
        {
            if(ModelState.IsValid)
            {
                var response = await _categoriaInterface.AdicionarCategoria(createCategoriaDto);

                if (!response.Status)
                {
                    TempData["MensagemErro"] = response.Mensagem;
                }

                TempData["MensagemSucesso"] = response.Mensagem;
                return RedirectToAction("Index");
            }

            return View(createCategoriaDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriaInterface.RemoverCategoria(id);

            if (categoria == null)
            {
                TempData["MensagemErro"] = "Ocorreu um erro no processo!";
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _categoriaInterface.DeleterCategoria(id);
            if (!response.Status)
            {
                TempData["MensagemErro"] = response.Mensagem;
                return RedirectToAction("Index");
            }

            TempData["MensagemSucesso"] = response.Mensagem;
            return RedirectToAction("Index");
        }
    }
}
