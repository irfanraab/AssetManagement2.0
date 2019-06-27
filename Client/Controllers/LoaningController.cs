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
    public class LoaningController : Controller
    {

        BaseLink get = new BaseLink();
        // GET: Loaning
        public ActionResult Index()
        {
            return View(LoadLoaning());
        }
        public JsonResult LoadLoaning()
        {
            IEnumerable<Loaning> loaningVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("Loanings");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Loaning>>();
                readTask.Wait();
                loaningVM = readTask.Result;
            }
            else
            {
                loaningVM = Enumerable.Empty<Loaning>();
                ModelState.AddModelError(string.Empty, "Server error");
            }
            return Json(loaningVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(LoaningVM loaningVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var myContent = JsonConvert.SerializeObject(loaningVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (loaningVM.Id.Equals(0))
            {
                var result = client.PostAsync("Loanings", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Loanings/" + loaningVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            LoaningVM loaningVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var responseTask = client.GetAsync("Loanings/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<LoaningVM>();
                readTask.Wait();
                loaningVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(loaningVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var result = client.DeleteAsync("Loanings/" + id).Result;
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
            IEnumerable<TypeItem> typeitem = null;
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
                typeitem = readTask.Result;
            }
            else
            {
                typeitem = Enumerable.Empty<TypeItem>();
                ModelState.AddModelError(string.Empty, "Server error");
            }

            return Json(typeitem, JsonRequestBehavior.AllowGet);
        }

    }

}