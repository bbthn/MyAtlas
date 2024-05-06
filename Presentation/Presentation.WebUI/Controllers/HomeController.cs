using Core.Application.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebUI.Controllers
{
    public class HomeController : Controller
    {

        [AddRedisAttribute()]
        public IActionResult Index()
        {
            return View();
        }
    }
}
