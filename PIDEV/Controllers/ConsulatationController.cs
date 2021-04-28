using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIDEV.Models;

namespace PIDEV.Controllers
{
    public class ConsulatationController : Controller
    {
        // GET: ConsulatationController
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("SpringMVC/servlet/retrieve-all-Consultation").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Consulatation>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Consulatation c)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.PostAsJsonAsync<Consulatation>("SpringMVC/servlet/add-consultation", c).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());


            



            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("SpringMVC/servlet/remove-consultation/" + id).Result;
            Consulatation a = new Consulatation();
            if (response.IsSuccessStatusCode)
            {

                a = response.Content.ReadAsAsync<Consulatation>().Result;

            }
            else
            {
                a = null;
            }

            return View(a);
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8081");

                // TODO: Add insert logic here
                client.DeleteAsync("SpringMVC/servlet/remove-consultation/" + id).ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Createe()
        {
            return View("Createe");
        }

        public ActionResult Createe(Consulatation c)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.PostAsJsonAsync<Consulatation>("SpringMVC/servlet/add-auto-consultation", c).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Consulatation c = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081");
                var responseTask = client.GetAsync("SpringMVC/servlet/retrieve-consultation/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Consulatation>();
                    readTask.Wait();
                    c = readTask.Result;
                }
            }
            return View(c);
        }

        [HttpPost]
        public ActionResult Edit(Consulatation c)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081");
                var putTask = client.PutAsJsonAsync<Consulatation>("SpringMVC/servlet/modify-Consultation", c);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                return View(c);
            }
        }


    }
}
