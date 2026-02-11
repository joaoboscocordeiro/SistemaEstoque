using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaEstoque.Dtos.Produto;
using SistemaEstoque.Models;
using SistemaEstoque.Services.Categorias;
using SistemaEstoque.Services.Produtos;

namespace SistemaEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoInterface _produtoInterface;
        private readonly ICategoriaInterface _categoriaInterface;

        public ProdutoController(IProdutoInterface produtoInterface, ICategoriaInterface categoriaInterface)
        {
            _produtoInterface = produtoInterface;
            _categoriaInterface = categoriaInterface;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoInterface.ObterTodosAsync();
            return View(produtos);
        }

        public async Task<IActionResult> Details(int id)
        {
            var produto = await _produtoInterface.ObterPorIdAsync(id);
            if (produto == null) return NotFound();

            return View(produto);
        }

        public async Task<IActionResult> Create()
        {
            var categorias = await _categoriaInterface.ObterTodasCategorias();

            var produtoDto = new ProdutoDto
            {
                Categorias = new SelectList(categorias, "Id", "Descricao")
            };

            return View(produtoDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _produtoInterface.ObterPorIdAsync(id);
            var categorias = await _categoriaInterface.ObterTodasCategorias();

            if (produto == null)
            {
                TempData["MensagemErro"] = "Produto não encontrado!";
                return RedirectToAction("Index");
            }
            ;

            var produtoDto = new ProdutoDto
            {
                Id = id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade,
                Codigo = produto.Codigo,
                CategoriaId = produto.CategoriaId,
                Imagem = produto.Imagem,
                Categorias = new SelectList(categorias, "Id", "Descricao", produto.CategoriaId)
            };

            return View(produtoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProdutoDto produtoDto)
        {
            var categorias = await _categoriaInterface.ObterTodasCategorias();

            if (ModelState.IsValid)
            {
                var response = await _produtoInterface.AdicionarAsync(produtoDto);

                if (!response.Status)
                {
                    TempData["MensagemErro"] = response.Mensagem;
                    produtoDto.Categorias = new SelectList(categorias, "Id", "Descricao");
                    return View(produtoDto);
                }

                TempData["MensagemSucesso"] = response.Mensagem;
                return RedirectToAction("Index");
            }

            produtoDto.Categorias = new SelectList(categorias, "Id", "Descricao");
            return View(produtoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProdutoDto produtoDto)
        {
            var categorias = await _categoriaInterface.ObterTodasCategorias();

            if (ModelState.IsValid)
            {
                var response = await _produtoInterface.AtualizarAsync(produtoDto);

                if (!response.Status)
                {
                    TempData["MensagemErro"] = response.Mensagem;
                    produtoDto.Categorias = new SelectList(categorias, "Id", "Descricao", produtoDto.CategoriaId);
                    return View(produtoDto);
                }

                TempData["MensagemSucesso"] = response.Mensagem;
                return RedirectToAction("Index");
            }

            produtoDto.Categorias = new SelectList(categorias, "Id", "Descricao", produtoDto.CategoriaId);
            return View(produtoDto);
        }
    }
}
