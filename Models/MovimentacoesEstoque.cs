using System.ComponentModel.DataAnnotations;

namespace SistemaEstoque.Models
{
    public class MovimentacoesEstoque
    {
        public int Id { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public string Tipo { get; set; } = string.Empty;
        [Required(ErrorMessage = "A quantidade é obrigatória!")]
        public int? Quantidade { get; set; }
        public string? Usuario { get; set; }
        [Required(ErrorMessage = "A observação é obrigatória!")]
        public string Observacao { get; set; } = string.Empty;
        public Produto? Produto { get; set; }
        [Required(ErrorMessage = "O produto é obrigatória!")]
        public int? ProdutoId { get; set; }
    }
}
