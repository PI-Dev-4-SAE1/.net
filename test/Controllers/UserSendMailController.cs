using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class UserSendMailController : Controller
    {

        // GET: UserSendMail

        [HttpGet]
       public ActionResult SendMailIns()
        {
            return View("Kindergarten");
        }
        [HttpPost]
        public ActionResult SendMailIns(UserSendMail pst)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("localhost:8081/SpringMVC/servlet/");
            Client.PostAsJsonAsync("send-mail/1/4",pst).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return Redirect("Kindergarten");

        }


        
       


    }
}