using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class PostsController :Controller
    {
       

        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("SpringMVC/servlet/retrieve-all-Posts").Result;
            if(response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Posts>>().Result;

            }else
            {
                ViewBag.result = "erreur";
            }
            return View(ViewBag.result);

        }
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("SpringMVC/servlet/retrieve-Posts/" + id).Result;
            Posts cri = new Posts();
            if (response.IsSuccessStatusCode)
            {

                cri = response.Content.ReadAsAsync<Posts>().Result;

            }
            else
            {
                cri = null;
            }

            return View(cri);
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8081");

                // TODO: Add insert logic here
                client.DeleteAsync("SpringMVC/servlet/1/remove-Posts/" + id)
                        .ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
            Client.PostAsJsonAsync<Posts>("SpringMVC/servlet/1/add-Posts", pst).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }
        public ActionResult ViewComments(int id )
        {
            CommentsController cc = new CommentsController();
            return cc.Index(id);
        }
    }
}