using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.Controllers
{
    public class TaskController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44385/api/Task");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class2>>(jsonString);

            return View(values);
        }
        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTask(Class2 p)
        {
            var httpClient = new HttpClient();
            var jsonTask = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonTask, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:44385/api/Task",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public async Task<IActionResult> DeleteTask(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44385/api/Task" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }

    public class Class2
    {
        public int Id { get; set; }
        public string Taskk { get; set; }
        public DateTime TaskkCreateDate { get; set; }
    }
}
