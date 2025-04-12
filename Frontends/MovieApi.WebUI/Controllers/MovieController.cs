using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult MovieList()
        {
            ViewBag.movieList = "Film Listesi";
            ViewBag.conrollerName = "Ana Sayfa";
            ViewBag.movieListing = "Tüm Filmler";
            return View();
        }
    }
}
