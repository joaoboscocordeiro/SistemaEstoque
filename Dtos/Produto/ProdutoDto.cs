using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaEstoque.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaEstoque.Dtos.Produto
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "A descrição é obrigatório!")]
        public string Descricao { get; set; } = string.Empty;
        [Required(ErrorMessage = "O Preço é obrigatório!")]
        public decimal? Preco { get; set; }
        [Required(ErrorMessage = "A quantidade é obrigatório!")]
        public int? Quantidade { get; set; }
        [Required(ErrorMessage = "O código é obrigatório!")]
        public string Codigo { get; set; } = string.Empty;
        public int CategoriaId { get; set; }
        public CategoriaModel? Categoria { get; set; }
        public IFormFile? ImagemUpload { get; set; }
        public byte[]? Imagem { get; set; }
        public SelectList? Categorias { get; set; }
    }
}
