using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Data;
using SistemaEstoque.Dtos.Movimentacao;
using SistemaEstoque.Dtos.Produto;
using System.Threading.Tasks;

namespace SistemaEstoque.Services.Graficos
{
    public class GraficoService : IGraficoInterface
    {
        private readonly AppDbContext _context;

        public GraficoService(AppDbContext context)
        {
            _context = context;
        }

        public List<EntradasSaidasDto> ObterEntradasVsSaidasPorMes()
        {
            var dados = _context.MovimentacoesEstoque
                .GroupBy(m => new { m.Data.Year, m.Data.Month, m.Tipo })
                .Select(g => new EntradasSaidasDto
                {
                    Ano = g.Key.Year,
                    Mes = g.Key.Month,
                    Tipo = g.Key.Tipo,
                    Quantidade = g.Sum(m => m.Quantidade)
                }).ToList();

            return dados;
        }

        public List<MovimentacoesPeriodoDto> ObterMovimentacoesPorPeriodo(DateTime? inicio, DateTime? fim, string tipo, int? categoriaId)
        {
            var query = _context.MovimentacoesEstoque.Include(p => p.Produto).AsQueryable();

            if (inicio.HasValue)
            {
                query = query.Where(m => m.Data >= inicio.Value);
            }

            if (fim.HasValue)
            {
                query = query.Where(m => m.Data >= fim.Value);
            }

            if (!string.IsNullOrEmpty(tipo))
            {
                query = query.Where(m => m.Tipo == tipo);
            }

            if (categoriaId.HasValue)
            {
                query = query.Where(m => m.Produto.CategoriaId == categoriaId.Value);
            }

            return query
                .GroupBy(m => m.Data.Date)
                .Select(g => new MovimentacoesPeriodoDto
                {
                    Data = g.Key.ToString("dd/MM/yyyy"),
                    Quantidade = g.Sum(g => g.Quantidade)
                }).ToList();
        }

        public List<ProdutoEstoqueDto> ObterProdutosComMenorEstoque(int limite)
        {
            var dados = _context.Produtos
                .OrderBy(p => p.Quantidade)
                .Take(limite)
                .Where(p => p.Quantidade <= 5)
                .Select(p => new ProdutoEstoqueDto
                {
                    Produto = p.Nome,
                    Quantidade = p.Quantidade
                }).ToList();

            return dados;
        }
    }
}
