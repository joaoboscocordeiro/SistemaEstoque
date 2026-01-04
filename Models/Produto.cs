namespace SistemaEstoque.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public byte[] Imagem { get; set; }

        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        public ICollection<MovimentacoesEstoque> Movimentacoes { get; set; }
    }
}
