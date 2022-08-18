using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace YourBeautyEstetica.MVC.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IMapper _mapper;

        public ClienteController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        
    }
}
