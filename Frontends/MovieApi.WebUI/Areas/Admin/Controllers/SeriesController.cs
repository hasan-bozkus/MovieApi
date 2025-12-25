using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Areas.Admin.Controllers
{
    public class SeriesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SeriesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult SeriesList()
        {
            return View();
        }
    }
}
