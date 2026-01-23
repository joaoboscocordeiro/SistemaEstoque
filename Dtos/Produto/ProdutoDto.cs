using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaEstoque.Models;

namespace SistemaEstoque.Dtos.Produto
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public int CategoriaId { get; set; }
        public CategoriaModel? Categoria { get; set; }
        public IFormFile? ImagemUpload { get; set; }
        public byte[]? Imagem { get; set; }
        public SelectList? Categorias { get; set; }
    }
}
