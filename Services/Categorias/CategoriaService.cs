using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Data;
using SistemaEstoque.Models;

namespace SistemaEstoque.Services.Categorias
{
    public class CategoriaService : ICategoriaInterface
    {
        private readonly AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> ObterTodasCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }
    }
}
