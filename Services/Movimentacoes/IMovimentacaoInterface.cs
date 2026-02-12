using SistemaEstoque.Models;

namespace SistemaEstoque.Services.Movimentacoes
{
    public interface IMovimentacaoInterface
    {
        Task AdicionarMovimentacaoAsync(MovimentacoesEstoque mov);
        Task<List<MovimentacoesEstoque>> ObterTodasAsync();
    }
}
