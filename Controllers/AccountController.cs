using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Dtos;

namespace SistemaEstoque.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {    
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            if(!ModelState.IsValid) return View(registerUserDto);

            var user = new IdentityUser { UserName = registerUserDto.Email, Email = registerUserDto.Email };

            var result = await _userManager.CreateAsync(user, registerUserDto.Senha);

            if(result.Succeeded)
            {
                if(!await _roleManager.RoleExistsAsync(registerUserDto.Perfil))
                {
                    await _roleManager.CreateAsync(new IdentityRole(registerUserDto.Perfil));
                }

                await _userManager.AddToRoleAsync(user, registerUserDto.Perfil);
            }

            TempData["MensagemSucesso"] = $"Usuário: {user.UserName} Criado com sucesso!";
            return View();
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {

        }
    }
}
