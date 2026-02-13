using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Data;
using SistemaEstoque.Models;

namespace SistemaEstoque.Services.Movimentacoes
{
    public class MovimentacaoService : IMovimentacaoInterface
    {
        private readonly AppDbContext _context;

        public MovimentacaoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarMovimentacaoAsync(MovimentacoesEstoque mov)
        {
            var produto = await _context.Produtos.FindAsync(mov.ProdutoId);

            if (produto == null) throw new Exception("Produto não encontrado!");

            if (mov.Tipo == "Entrada")
                produto.Quantidade += mov.Quantidade;

            if (mov.Tipo == "Saida")
                produto.Quantidade -= mov.Quantidade;
            mov.Data = DateTime.Now;

            _context.MovimentacoesEstoque.Add(mov);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MovimentacoesEstoque>> ObterTodasAsync()
        {
            return await _context.MovimentacoesEstoque.Include(p => p.Produto).ToListAsync();
        }
    }
}
