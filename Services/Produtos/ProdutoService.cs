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

        public async Task<ResponseModel<string>> AdicionarAsync(ProdutoDto produtoDto)
        {
            ResponseModel<string> response = new ResponseModel<string>();

            try
            {
                var produtoBanco = new Produto
                {
                    Nome = produtoDto.Nome,
                    Descricao = produtoDto.Descricao,
                    Preco = produtoDto.Preco,
                    Quantidade = produtoDto.Quantidade,
                    Codigo = produtoDto.Codigo,
                    CategoriaId = produtoDto.CategoriaId,
                    Imagem = await ConverterImagem(produtoDto.ImagemUpload)
                };

                _context.Add(produtoBanco);
                await _context.SaveChangesAsync();

                response.Mensagem = "Produto adicionado com sucesso!";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<string>> AtualizarAsync(ProdutoDto produtoDto)
        {
            ResponseModel<string> response = new ResponseModel<string>();

            try
            {
                var produtoBanco = await ObterPorIdAsync(produtoDto.Id);

                if (produtoBanco == null)
                {
                    response.Mensagem = "Produto não encontrado!";
                    response.Status = false;
                    return response;
                }

                produtoBanco.Nome = produtoDto.Nome;
                produtoBanco.Descricao = produtoDto.Descricao;
                produtoBanco.Preco = produtoDto.Preco;
                produtoBanco.Quantidade = produtoDto.Quantidade;
                produtoBanco.Codigo = produtoDto.Codigo;
                produtoBanco.CategoriaId = produtoDto.CategoriaId;

                if(produtoDto.ImagemUpload != null)
                {
                    produtoBanco.Imagem = await ConverterImagem(produtoDto.ImagemUpload);
                }

                _context.Update(produtoBanco);
                await _context.SaveChangesAsync();

                response.Mensagem = "Produto atualizado com sucesso!";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<Produto> ObterPorIdAsync(int id)
        {
            return await _context.Produtos.Include(c => c.Categoria).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Produto>> ObterTodosAsync()
        {
           return await _context.Produtos.Include(c => c.Categoria).ToListAsync();
        }

        public async Task<ResponseModel<string>> RemoverAsync(int id)
        {
            ResponseModel<string> response = new ResponseModel<string>();

            try
            {
                var produtoBanco = await ObterPorIdAsync(id);

                if (produtoBanco == null)
                {
                    response.Mensagem = "Produto não localizado!";
                    response.Status = false;
                    return response;
                }

                _context.Produtos.Remove(produtoBanco);
                await _context.SaveChangesAsync();

                response.Mensagem = "Produto removido com sucesso!";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        private async Task<byte[]> ConverterImagem(IFormFile imagem)
        {
            if (imagem == null) return null;

            using var memoryStream = new MemoryStream();

            await imagem.CopyToAsync(memoryStream);

            return memoryStream.ToArray();
        }
    }
}
