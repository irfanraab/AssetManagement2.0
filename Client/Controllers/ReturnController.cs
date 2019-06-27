using Core.Base;
using DataAccess.Models;
using DataAccess.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class ReturnController : Controller
    {
        BaseLink get = new BaseLink();
        // GET: Return
        public ActionResult Index()
        {
            return View(LoadReturn());
        }


        public JsonResult LoadReturn()
        {
            IEnumerable<Return> returnVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("Returns");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Return>>();
                readTask.Wait();
                returnVM = readTask.Result;
            }
            else
            {
                returnVM = Enumerable.Empty<Return>();
                ModelState.AddModelError(string.Empty, "Server error");
            }
            return Json(returnVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(ReturnVM returnVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var myContent = JsonConvert.SerializeObject(returnVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (returnVM.Id.Equals(0))
            {
                var result = client.PostAsync("Returns", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Returns/" + returnVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            ReturnVM returnVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var responseTask = client.GetAsync("Returns/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ReturnVM>();
                readTask.Wait();
                returnVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(returnVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var result = client.DeleteAsync("Returns/" + id).Result;
        }

        public JsonResult GetItemProject()
        {
            IEnumerable<Item> item = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("Items");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Item>>();
                readTask.Wait();
                item = readTask.Result;
            }
            else
            {
                item = Enumerable.Empty<Item>();
                ModelState.AddModelError(string.Empty, "Server error");
            }

            return Json(item, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTypeItemProject()
        {
            IEnumerable<TypeItem> item = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("TypeItems");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<TypeItem>>();
                readTask.Wait();
                item = readTask.Result;
            }
            else
            {
                item = Enumerable.Empty<TypeItem>();
                ModelState.AddModelError(string.Empty, "Server error");
            }

            return Json(item, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetConditionProject()
        {
            IEnumerable<Condition> condition = null;
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
                condition = readTask.Result;
            }
            else
            {
                condition = Enumerable.Empty<Condition>();
                ModelState.AddModelError(string.Empty, "Server error");
            }

            return Json(condition, JsonRequestBehavior.AllowGet);
        }
    }
}
