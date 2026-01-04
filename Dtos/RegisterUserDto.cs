using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaEstoque.Dtos
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "Email é obrigatório!")]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "A senha é obrigatório!")]
        public string Senha { get; set; } = string.Empty;
        [Required(ErrorMessage = "A confirmação de senha é obrigatória!")]
        [Compare("Senha", ErrorMessage = "As senhas não estão iguais!")]
        public string ConfirmaSenha { get; set; } = string.Empty;
        [Required]
        public string Perfil { get; set; } = string.Empty;
    }
}
