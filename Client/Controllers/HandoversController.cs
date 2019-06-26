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
    public class HandoversController : Controller
    {
        BaseLink get = new BaseLink();
        // GET: Handovers
        public ActionResult Index()
        {
            return View(LoadHandover());
        }

        public JsonResult LoadHandover()
        {
            IEnumerable<Handover> handoverVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("Handovers");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Handover>>();
                readTask.Wait();
                handoverVM = readTask.Result;
            }
            else
            {
                handoverVM = Enumerable.Empty<Handover>();
                ModelState.AddModelError(string.Empty, "Server error");
            }
            return Json(handoverVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(Handover handoverVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var myContent = JsonConvert.SerializeObject(handoverVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (handoverVM.Id.Equals(0))
            {
                var result = client.PostAsync("Handovers", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Handovers/" + handoverVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            Handover handoverVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var responseTask = client.GetAsync("Handovers/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Handover>();
                readTask.Wait();
                handoverVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(handoverVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var result = client.DeleteAsync("Handovers/" + id).Result;
        }
    }
}