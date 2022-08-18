using Microsoft.AspNetCore.Mvc;
using YourBeautyEstetica.MVC.Models;

namespace YourBeautyEstetica.MVC.Controllers
{
    public class FuncionariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Atualizar(FuncionarioDTO model)
        {
            return RedirectToAction("Administracao", "Home");
        }
    }
}