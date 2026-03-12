using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Areas.Admin.Controllers
{
    public class AdminCastController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCastController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult CastList()
        {
            return View();
        }
    }
}
