using Exam7_REST_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace Exam7_REST_API.Controllers
{
    public class TodoController(IHttpClientFactory clientFactory) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpClient = clientFactory.CreateClient();
            var res = await httpClient.GetAsync("https://dummyjson.com/todos");
            if (res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                TodosModel? todos = JsonSerializer.Deserialize<TodosModel>(content);
                return View(todos?.todos);
            }
            return View();
        }
        
        public IActionResult Create()
        {
            return View(new TodoModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(TodoModel todo)
        {
            var httpClient = clientFactory.CreateClient();
            var httpContent = new StringContent(JsonSerializer.Serialize(todo), Encoding.UTF8, "application/json");
            var res = await httpClient.PostAsync("https://dummyjson.com/todos/add", httpContent);
            if (res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                 return View(todo);
            }
            return View();
        }
    }
}
