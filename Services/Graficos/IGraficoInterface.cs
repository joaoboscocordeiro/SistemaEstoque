using SistemaEstoque.Dtos.Movimentacao;
using SistemaEstoque.Dtos.Produto;

namespace SistemaEstoque.Services.Graficos
{
    public interface IGraficoInterface
    {
        List<ProdutoEstoqueDto> ObterProdutosComMenorEstoque(int limite);
        List<EntradasSaidasDto> ObterEntradasVsSaidasPorMes();
        List<MovimentacoesPeriodoDto> ObterMovimentacoesPorPeriodo(DateTime? inicio, DateTime? fim, string tipo, int? categoriaId);
    }
}
