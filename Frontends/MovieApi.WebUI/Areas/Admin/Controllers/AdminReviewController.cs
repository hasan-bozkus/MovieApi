using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.AdminReviewDtos;
using Newtonsoft.Json;

namespace MovieApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminReviewController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminReviewController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44366/api/Reviews?page={page}&pageSize={pageSize}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AdminResultReviewDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
