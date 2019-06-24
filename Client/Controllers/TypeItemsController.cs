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
    public class TypeItemsController : Controller
    {
        BaseLink get = new BaseLink();
        // GET: TypeItem
        public ActionResult Index()
        {
            return View(LoadTypeItem());
        }

        public JsonResult LoadTypeItem()
        {
            IEnumerable<TypeItem> typeItemVM = null;
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
                typeItemVM = readTask.Result;
            }
            else
            {
                typeItemVM = Enumerable.Empty<TypeItem>();
                ModelState.AddModelError(string.Empty, "Server error");
            }
            return Json(typeItemVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(TypeItem typeItemVM)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var myContent = JsonConvert.SerializeObject(typeItemVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (typeItemVM.Id.Equals(0))
            {
                var result = client.PostAsync("TypeItems", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("TypeItems/" + typeItemVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            TypeItemVM typeItemVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var responseTask = client.GetAsync("TypeItems/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<TypeItemVM>();
                readTask.Wait();
                typeItemVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(typeItemVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var result = client.DeleteAsync("TypeItems/" + id).Result;
        }
    }
}