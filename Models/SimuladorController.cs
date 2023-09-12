using Microsoft.AspNetCore.Mvc;

namespace prj.Models
{
    public class SimuladorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
