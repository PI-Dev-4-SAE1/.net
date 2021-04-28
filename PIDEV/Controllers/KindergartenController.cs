using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIDEV.Models;

namespace PIDEV.Controllers
{
    public class KindergartenController : Controller
    {
        // GET: KindergartenController
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("/retrieve-all-Consultation").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Childrengarden>>().Result;
            }
            else 
            {
                ViewBag.result = "error";
            }
            return View();
        }

        
        // GET: KindergartenController/Create
        [HttpGet]
        public ActionResult Create()
        {

            return View("Create");
        }
        [HttpPost]
        public ActionResult Create (Childrengarden c)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet");
            client.PostAsJsonAsync<Childrengarden>("/add-consultation", c).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index"); 
        }
        
    }
}
