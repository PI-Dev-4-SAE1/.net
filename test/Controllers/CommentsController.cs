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
    public class CommentsController : Controller
    {
        public ActionResult Index(int id)
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("SpringMVC/servlet/posts/" + id + "/comments").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Comments>>().Result;

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
        public ActionResult Create(Comments pst)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.PostAsJsonAsync<Comments>("SpringMVC/servlet/1/add-Posts", pst).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }
    }
}
