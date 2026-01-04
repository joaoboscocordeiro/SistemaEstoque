namespace SistemaEstoque.Models
{
    public class MovimentacoesEstoque
    {
        public int Id { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public string Tipo { get; set; } = string.Empty;
        public int? Quantidade { get; set; }
        public string? Usuario { get; set; }
        public string Observacao { get; set; } = string.Empty;

        public Produto? Produto { get; set; }
        public int? ProdutoId { get; set; }
    }
}
