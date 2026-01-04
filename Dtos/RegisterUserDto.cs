using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaEstoque.Dtos
{
    public class RegisterUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Senha { get; set; } = string.Empty;
        [Required]
        public string ConfirmaSenha { get; set; } = string.Empty;
        [Required]
        public string Perfil { get; set; } = string.Empty;
    }
}
