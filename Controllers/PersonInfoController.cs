using Microsoft.AspNetCore.Mvc;

namespace Person_Registration_System.Controllers
{
    public class PersonInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
