using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            System.Net.Http.HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("/SpringMVC/servlet/retrieve-all-User").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<User>>().Result;

            }
            else
            {
                ViewBag.result = "erreur";
            }
            return View(ViewBag.result);

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(Posts pst)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.PostAsJsonAsync<Posts>("SpringMVC/servlet/add-User", pst).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }
    }
}
