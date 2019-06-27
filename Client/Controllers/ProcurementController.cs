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
    public class ProcurementController : Controller
    {
        BaseLink get = new BaseLink();
        // GET: Procurement
        [Authorize]
        public ActionResult Index()
        {
            return View(LoadProcurement());
        }

        public ActionResult IndexDivHead()
        {
            return View(LoadProcurement());
        }

        public JsonResult LoadProcurement()
        {
            IEnumerable<Procurement> procurementVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("Procurements");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Procurement>>();
                readTask.Wait();
                procurementVM = readTask.Result;
            }
            else
            {
                procurementVM = Enumerable.Empty<Procurement>();
                ModelState.AddModelError(string.Empty, "Server error");
            }
            return Json(procurementVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(Procurement procurementVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var myContent = JsonConvert.SerializeObject(procurementVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (procurementVM.Id.Equals(0))
            {
                var result = client.PostAsync("Procurements", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Procurements/" + procurementVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            ProcurementVM procurementVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var responseTask = client.GetAsync("Procurements/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ProcurementVM>();
                readTask.Wait();
                procurementVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(procurementVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var result = client.DeleteAsync("Procurements/" + id).Result;
        }

        // DropDown
        public JsonResult GetTypeItemProject()
        {
            IEnumerable<TypeItem> typeItem = null;
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
                typeItem = readTask.Result;
            }
            else
            {
                typeItem = Enumerable.Empty<TypeItem>();
                ModelState.AddModelError(string.Empty, "Server error");
            }

            return Json(typeItem, JsonRequestBehavior.AllowGet);
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
    }
}