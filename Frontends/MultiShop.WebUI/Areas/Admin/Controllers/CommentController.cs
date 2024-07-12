using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Areas.Admin.Attributes;
using MultiShop.WebUI.Helpers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [PopulateViewBag("Yorumlar", "Yorum Listesi", "Yorum İşlemleri")]
    public class CommentController : AdminBaseController
    {
        private const string COMMENT_API_URL = $"https://localhost:7161/api/Comments";
        public CommentController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var responseMessage = await _client.GetAsync(COMMENT_API_URL);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                // JSON'u Deserialize etme
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var values = JsonSerializer.Deserialize<IEnumerable<ResultCommentDto>>(jsonData, options);

                return View(values);
            }
            return View();
        }

        [Route("CreateComment")]
        [HttpGet]
        public async Task<IActionResult> CreateComment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto CommentDto)
        {
            var stringContent = HttpContentHelper.CreateJsonContent(CommentDto);

            var responseMessage = await _client.PostAsync(COMMENT_API_URL, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("UpdateComment/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateComment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto CommentDto)
        {
            var stringContent = HttpContentHelper.CreateJsonContent(CommentDto);

            var responseMessage = await _client.PutAsync(COMMENT_API_URL, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            var responseMessage = await _client.DeleteAsync($"{COMMENT_API_URL}/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }
    }
}
