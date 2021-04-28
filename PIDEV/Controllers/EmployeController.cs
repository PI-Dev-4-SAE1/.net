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
    public class EmployeController : Controller
    {
        // GET: EmployeController
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("SpringMVC/servlet/retrieve-all-Employe").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Employe>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }

        // GET: EmployeController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Employe e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.PostAsJsonAsync<Employe>("SpringMVC/servlet/add-Employe", e).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());


            SmtpClient smtpClient = new SmtpClient("mail.MyWebsiteDomainName.com", 25);

            smtpClient.Credentials = new System.Net.NetworkCredential("alaeddinne.ghribi@esprit.tn", "ala&kira28749574");
            // smtpClient.UseDefaultCredentials = true; // uncomment if you don't want to use the network credentials
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            //Setting From , To and CC
            mail.From = new MailAddress("alaeddinne.ghribi@esprit.tn", "MyWeb Site");
            mail.To.Add(new MailAddress("alaeddinne.ghribi@esprit.tn"));
            mail.CC.Add(new MailAddress("alaeddinne.ghribi@esprit.tn"));

            smtpClient.Send(mail);


            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("SpringMVC/servlet/remove-Employe/" + id).Result;
            Employe a = new Employe();
            if (response.IsSuccessStatusCode)
            {

                a = response.Content.ReadAsAsync<Employe>().Result;

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
                client.DeleteAsync("SpringMVC/servlet/remove-Employe/" + id).ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }


        public ActionResult Edit(int id)
        {
            Employe e = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081");
                var responseTask = client.GetAsync("SpringMVC/servlet/retrieve-Employe/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Employe>();
                    readTask.Wait();
                    e = readTask.Result;
                }
            }
            return View(e);
        }


        //a post to update
        [HttpPost]
        public ActionResult Edit(Employe e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081");
                var putTask = client.PutAsJsonAsync<Employe>("SpringMVC/servlet/modify-Employe", e);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                return View(e);
            }
        }

        
    }
}
