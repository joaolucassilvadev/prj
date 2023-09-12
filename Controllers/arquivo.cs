using Microsoft.AspNetCore.Mvc;

namespace prj.Controllers
{
    public class arquivo : Controller
    {
        public IActionResult Arquivo()
        {
            return View();
        }
    }
}
