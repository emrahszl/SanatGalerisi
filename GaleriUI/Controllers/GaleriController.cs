using GaleriAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GaleriUI.Controllers
{
    public class GaleriController : Controller
    {
        private readonly HttpClient _httpClient;

        public GaleriController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _httpClient.GetFromJsonAsync<List<Tablo>>("https://localhost:7228/api/Tablolar"));
        }

        public IActionResult Yeni()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Yeni(PostTabloDto tabloDto)
        {
            if (ModelState.IsValid)
            {
                await _httpClient.PostAsJsonAsync("https://localhost:7228/api/Tablolar", tabloDto);

                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Duzenle(int id)
        {
            return View(await _httpClient.GetFromJsonAsync<PutTabloDto>($"https://localhost:7228/api/Tablolar/{id}"));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(int id, PutTabloDto tabloDto)
        {
            if (ModelState.IsValid)
            {
                await _httpClient.PutAsJsonAsync($"https://localhost:7228/api/Tablolar/{id}", tabloDto);

                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Sil(int id)
        {
            return View(await _httpClient.GetFromJsonAsync<Tablo>($"https://localhost:7228/api/Tablolar/{id}"));
        }

        [HttpPost,ValidateAntiForgeryToken]
        [ActionName("Sil")]
        public async Task<IActionResult> SilOnay(int id)
        {
            await _httpClient.DeleteAsync($"https://localhost:7228/api/Tablolar/{id}");

            return RedirectToAction("Index");
        }
    }
}
