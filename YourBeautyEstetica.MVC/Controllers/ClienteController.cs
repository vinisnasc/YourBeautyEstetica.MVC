using Microsoft.AspNetCore.Mvc;

namespace YourBeautyEstetica.MVC.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
