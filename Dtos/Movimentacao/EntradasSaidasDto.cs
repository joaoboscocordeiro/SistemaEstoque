namespace SistemaEstoque.Dtos.Movimentacao
{
    public class EntradasSaidasDto
    {
        public int Ano { get; set; }
        public int Mes { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public int? Quantidade { get; set; }
    }
}
