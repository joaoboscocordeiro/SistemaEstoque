using SistemaEstoque.Models;

namespace SistemaEstoque.Services.Categorias
{
    public interface ICategoriaInterface
    {
        Task<List<Categoria>> ObterTodasCategorias();
    }
}
