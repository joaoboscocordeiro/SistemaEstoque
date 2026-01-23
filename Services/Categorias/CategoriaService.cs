using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Data;
using SistemaEstoque.Dtos.Categoria;
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

        public async Task<ResponseModel<CategoriaModel>> AdicionarCategoria(CreateCategoriaDto createCategoriaDto)
        {
            ResponseModel<CategoriaModel> response = new ResponseModel<CategoriaModel>();

            try
            {
                CategoriaModel categoria = new CategoriaModel()
                {
                    Descricao = createCategoriaDto.Descricao
                };

                _context.Add(categoria);
                await _context.SaveChangesAsync();

                response.Mensagem = $"Categoria {categoria.Descricao} cadastrado com sucesso!";
                response.Dados = categoria;
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<List<CategoriaModel>> ObterTodasCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<CategoriaModel> RemoverCategoria(int id)
        {
           return await _context.Categorias.FindAsync(id);
        }

        public async Task<ResponseModel<string>> DeleterCategoria(int id)
        {
            ResponseModel<string> response = new ResponseModel<string>();

            try
            {
                var categoria = await RemoverCategoria(id);

                if (categoria == null)
                {
                    response.Mensagem = "Categoria não localizado!";
                    return response;
                }

                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();

                response.Mensagem = $"Categoria {categoria.Descricao} Removido com Sucesso!";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
