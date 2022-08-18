using Microsoft.AspNetCore.Mvc;
using YB.Domain.Interfaces.Services;

namespace YourBeautyEstetica.MVC.Controllers
{
    public class ServicosController : Controller
    {
        private readonly IServicoService _servicoService;

        public ServicosController(IServicoService servicoService)
        {
            _servicoService = servicoService;
        }

        public IActionResult CadastrarServico()
        {
            return PartialView("_CadastroServico");
        }
    }
}
