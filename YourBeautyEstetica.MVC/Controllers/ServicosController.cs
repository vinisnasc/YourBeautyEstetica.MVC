using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YB.Domain.Interfaces.Services;
using YB.Domain.Models;
using YourBeautyEstetica.MVC.Models;

namespace YourBeautyEstetica.MVC.Controllers
{
    public class ServicosController : Controller
    {
        private readonly IServicoService _servicoService;
        private readonly IFuncionarioService _funcionarioService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public ServicosController(IServicoService servicoService, IMapper mapper, IFuncionarioService funcionarioService, UserManager<IdentityUser> userManager)
        {
            _servicoService = servicoService;
            _mapper = mapper;
            _funcionarioService = funcionarioService;
            _userManager = userManager;
        }

        public IActionResult CadastrarServico()
        {
            return PartialView("_CadastrarServico");
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarServico(AdministracaoSimplesModel dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var funcionario = await _funcionarioService.BuscarFuncionario(user.Email);
            dto.Servico.FuncionarioId = funcionario.Id;

            var entity = _mapper.Map<Servico>(dto.Servico);

            await _servicoService.CadastrarServico(entity);

            return RedirectToAction("Administracao", "Home");
        }
    }
}
