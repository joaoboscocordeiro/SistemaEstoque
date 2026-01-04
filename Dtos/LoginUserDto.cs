using System.ComponentModel.DataAnnotations;

namespace SistemaEstoque.Dtos
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Email é obrigatório!")]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "A senha é obrigatório!")]
        public string Senha { get; set; } = string.Empty;
    }
}
