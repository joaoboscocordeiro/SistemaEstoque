using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Data;
using SistemaEstoque.Dtos.Produto;
using SistemaEstoque.Models;

namespace SistemaEstoque.Services.Produtos
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public Task<ResponseModel<string>> AdicionarAsync(ProdutoDto produtoDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<string>> AtualizarAsync(ProdutoDto produtoDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Produto> ObterPorIdAsync(int id)
        {
            return await _context.Produtos.Include(c => c.Categoria).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Produto>> ObterTodosAsync()
        {
           return await _context.Produtos.Include(c => c.Categoria).ToListAsync();
        }

        public Task<ResponseModel<string>> RemoverAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
