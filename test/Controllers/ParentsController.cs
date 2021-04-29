using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using test.Models;

namespace test.Controllers
{
    public class ParentsController : Controller
    {
        public object HttpClientBuilder { get; private set; }

        // GET: Parents
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("retrieve-all-Parents").Result;
            IList<Parents> parents;
            if (response.IsSuccessStatusCode)
            {
                parents = response.Content.ReadAsAsync<IList<Parents>>().Result;
            }
            else
            {
                return View("Index");

            }

            return View(parents);
        }


        public ActionResult Parent()
        {
           


            HttpClient Client = new HttpClient();
             Client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
             Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //string url = "retrieve-Parent/" + 1;
            HttpResponseMessage response = Client.GetAsync("getParent").Result;
            IList<Parents> parents;
             if (response.IsSuccessStatusCode)
             {
                 parents = response.Content.ReadAsAsync<IList<Parents>>().Result;
             }
             else
             {
                 return View("Index");

             }

             return View(parents);
        }


        public ActionResult Kindergarten()
        {



            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("KinderGartenByLikes").Result;
            IList<childrengarden> childrengardens;
            if (response.IsSuccessStatusCode)
            {
                childrengardens = response.Content.ReadAsAsync<IList<childrengarden>>().Result;
            }
            else
            {
                return View("Index");

            }

            return View(childrengardens);




        }


        public ActionResult Notification()
        {


            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
          
            string url = "Notif/" + 1;
            HttpResponseMessage response = Client.GetAsync(url).Result;

            string childrengardens;
            if (response.IsSuccessStatusCode)
            {
                childrengardens = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return View("Index");

            }

            return Redirect("/Parents/Notification");


        }

     

       
      
        public ActionResult LikeKnderGarten(long gardenId)
        {
       
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
            string url = "AddLikeKinderGarten/" + 1 + "/" + gardenId;
            HttpResponseMessage response=Client.PostAsJsonAsync<LikeKinderGarten>(url,new LikeKinderGarten()).Result;
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Kindergarten", "Parents");

        }
        public ActionResult DislikeKnderGarten(long gardenId)
        {

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
            string url = "AddDisLikeKinderGarten/" + 1 + "/" + gardenId;
            HttpResponseMessage response = Client.PostAsJsonAsync<LikeKinderGarten>(url, new LikeKinderGarten()).Result;
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Kindergarten", "Parents");

        }


        public ActionResult SendMailIns(long gardenId)
        {

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
            string url = "send-mail/" + 1 + "/" + gardenId;
            HttpResponseMessage response = Client.PostAsJsonAsync<UserSendMail>(url, new UserSendMail()).Result;
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Kindergarten", "Parents");

        }
        public ActionResult SendMailSat()
        {

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
            string url = "sendSatsifactionEmail/" + 1 ;
            HttpResponseMessage response = Client.PostAsJsonAsync<UserSendMail>(url, new UserSendMail()).Result;
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Parent", "Parents");

        }




      /*  public ActionResult Recherche(string city, string gouvernerat)
        {



            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            string url = "rechercheparcity/" + city + "/" + gouvernerat;
            HttpResponseMessage response = Client.GetAsync("url").Result;
            IList<childrengarden> childrengardens;
            if (response.IsSuccessStatusCode)
            {
                childrengardens = response.Content.ReadAsAsync<IList<childrengarden>>().Result;
            }
            else
            {
                return View("Index");

            }

            return View(childrengardens);



        }*/


        public ActionResult Recherche(childrengarden child)
        {

            var garten = new List<childrengarden>();

            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("KinderGartenByLikes").Result;
            if (response.IsSuccessStatusCode)
            {
                garten = (List<childrengarden>)response.Content.ReadAsAsync<IEnumerable<childrengarden>>().Result;
                if (!string.IsNullOrEmpty(child.governate))
                {
                    garten = garten.Where(s => s.governate.Contains(child.governate)).ToList();
                }
                return View(garten);
            }


            else
            {
                return RedirectToAction("Index");
            }

        }


        public ActionResult Edit()
        {
            Parents not = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
                //HTTP GET
                var responseTask = client.GetAsync("getParent");
                // responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Parents>();
                    readTask.Wait();

                    not = readTask.Result;
                }
            }
            return View(not);

        }
        // POST: Kid/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Parents not)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Parents>("updateParent/" + id, not);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(not);
        }
      


    }
}