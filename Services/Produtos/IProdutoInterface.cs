using SistemaEstoque.Dtos.Produto;
using SistemaEstoque.Models;

namespace SistemaEstoque.Services.Produtos
{
    public interface IProdutoInterface
    {
        Task<List<Produto>> ObterTodosAsync();
        Task<Produto> ObterPorIdAsync(int id);
        Task<ResponseModel<string>> AdicionarAsync(ProdutoDto produtoDto);
        Task<ResponseModel<string>> AtualizarAsync(ProdutoDto produtoDto);
        Task<ResponseModel<string>> RemoverAsync(int id);
    }
}
