using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        public IActionResult MovieList()
        {
            return View();
        }
    }
}
