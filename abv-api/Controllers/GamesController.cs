using Microsoft.AspNetCore.Mvc;

namespace abv_api.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
