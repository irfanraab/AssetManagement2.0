using Core.Base;
using DataAccess.Models;
using DataAccess.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    
    public class ConditionsController : Controller
    {
        BaseLink get = new BaseLink();
        // GET: Conditions
        // [Authorize]
        public ActionResult Index()
        {
            return View(LoadCondition());
        }

        public JsonResult LoadCondition()
        {
            IEnumerable<Condition> conditionVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("Conditions");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Condition>>();
                readTask.Wait();
                conditionVM = readTask.Result;
            }
            else
            {
                conditionVM = Enumerable.Empty<Condition>();
                ModelState.AddModelError(string.Empty, "Server error");
            }
            return Json(conditionVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(Condition conditionVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var myContent = JsonConvert.SerializeObject(conditionVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (conditionVM.Id.Equals(0))
            {
                var result = client.PostAsync("Conditions", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Conditions/" + conditionVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            ConditionVM conditionVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var responseTask = client.GetAsync("Conditions/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ConditionVM>();
                readTask.Wait();
                conditionVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(conditionVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var result = client.DeleteAsync("Conditions/" + id).Result;
        }
    }
}