using SistemaEstoque.Dtos.Produto;
using SistemaEstoque.Models;

namespace SistemaEstoque.Services.Produtos
{
    public class ProdutoService : IProdutoInterface
    {
        public Task<ResponseModel<string>> AdicionarAsync(ProdutoDto produtoDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<string>> AtualizarAsync(ProdutoDto produtoDto)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Produto>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<string>> RemoverAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
