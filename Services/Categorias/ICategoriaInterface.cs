using SistemaEstoque.Dtos.Categoria;
using SistemaEstoque.Models;

namespace SistemaEstoque.Services.Categorias
{
    public interface ICategoriaInterface
    {
        Task<List<CategoriaModel>> ObterTodasCategorias();
        Task<ResponseModel<CategoriaModel>> AdicionarCategoria(CreateCategoriaDto createCategoriaDto);
        Task<CategoriaModel> RemoverCategoria(int id);
        Task<ResponseModel<string>> DeleterCategoria(int id);
    }
}
