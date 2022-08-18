using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YB.Domain.Interfaces.Services;
using YB.Domain.Models;
using YourBeautyEstetica.MVC.Models;

namespace YourBeautyEstetica.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClienteService _clienteService;
        private readonly IFuncionarioService _funcionarioService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(ILogger<HomeController> logger, IClienteService clienteService, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IFuncionarioService funcionarioService, IMapper mapper)
        {
            _logger = logger;
            _clienteService = clienteService;
            _userManager = userManager;
            _roleManager = roleManager;
            _funcionarioService = funcionarioService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Funcionario, CEO")]
        public async Task<IActionResult> Administracao()
        {
            var usuario = await _userManager.FindByNameAsync(User.Identity.Name);
            AdministracaoSimplesModel admModel = new();
            var funcionario = _mapper.Map<FuncionarioDTO>(await _funcionarioService.BuscarFuncionario(usuario.Email));
            admModel.Funcionario = funcionario;

            if ((await _userManager.GetRolesAsync(usuario)).Any(role => role.Equals("CEO")))
            {
                AdministracaoGeralModel model = new();
                model.Usuarios = _userManager.Users.ToList();
                model.Funcionario = funcionario;

                return View("AdministracaoGeral", model);
            }

            return View(admModel);
        }

        [Authorize(Roles = "CEO")]
        [HttpPost]
        public async Task<IActionResult> AtribuirRole(AdministracaoGeralModel model)
        {
            var usuarioIdentity = await _userManager.FindByIdAsync(model.UsuarioId.ToString());
            var cliente = await _clienteService.BuscarCliente(usuarioIdentity.Email);

            if (_userManager.GetRolesAsync(usuarioIdentity).Result.Any(x => x.Contains(model.Role)))
                return PartialView("_JaExistePermissionamento");

            _userManager.AddToRoleAsync(usuarioIdentity, model.Role).GetAwaiter().GetResult();

            if ((await _userManager.GetRolesAsync(usuarioIdentity)).Any(role => role.Equals("Funcionario")))
            {
                var funcionarioExiste = await _funcionarioService.BuscarFuncionario(usuarioIdentity.Email);
                if (funcionarioExiste == null)
                {
                    FuncionarioDTO funcionario = new();
                    funcionario.Email = cliente.Email;
                    funcionario.Nome = cliente.Nome;
                    funcionario.Telefone = cliente.Telefone;
                    await _funcionarioService.CriarFuncionario(_mapper.Map<Funcionario>(funcionario));
                }
                else await _funcionarioService.AtivarFuncionario(funcionarioExiste);
            }

            return RedirectToAction(nameof(Administracao));
        }

        [Authorize(Roles = "CEO")]
        public async Task<IActionResult> RetirarRole(AdministracaoGeralModel model)
        {
            if (!ModelState.IsValid) return View("AdministracaoGeral");

            var usuarioIdentity = await _userManager.FindByIdAsync(model.UsuarioId.ToString());

            if (!_userManager.GetRolesAsync(usuarioIdentity).Result.Any(x => x.Contains(model.Role)))
            {
                // TODO: Usuario não tem essa permissao!
            }
            _userManager.RemoveFromRoleAsync(usuarioIdentity, model.Role).GetAwaiter().GetResult();

            if (!(await _userManager.GetRolesAsync(usuarioIdentity)).Any(role => role.Equals(model.Role)))
            {
                var funcionario = await _funcionarioService.BuscarFuncionario(usuarioIdentity.Email);
                await _funcionarioService.InativarFuncionario(funcionario);
            }
            return RedirectToAction(nameof(Administracao));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
           return View(new ErrorViewModel { /*RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier*/ });
        }

        public async Task CriarRoles()
        {
            // Criei esse metodo apenas para criar as roles e dar o privelegio administrativo para o CEO
            _roleManager.CreateAsync(new IdentityRole("CEO")).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole("Funcionario")).GetAwaiter().GetResult();

            var usuarioIdentity = await _userManager.FindByEmailAsync("vini.souza00@gmail.com");
            _userManager.AddToRoleAsync(usuarioIdentity, "CEO").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(usuarioIdentity, "Funcionario").GetAwaiter().GetResult();
        }
    }
}