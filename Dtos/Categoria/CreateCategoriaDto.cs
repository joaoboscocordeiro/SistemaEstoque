using System.ComponentModel.DataAnnotations;

namespace SistemaEstoque.Dtos.Categoria
{
    public class CreateCategoriaDto
    {
        [Required(ErrorMessage = "O campo descrição é obrigatório!")]
        public string Descricao { get; set; } = string.Empty;
    }
}
