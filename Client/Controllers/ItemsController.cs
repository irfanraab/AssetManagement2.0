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
    public class ItemsController : Controller
    {
        BaseLink get = new BaseLink();
        // GET: Items
        public ActionResult Index()
        {
            return View(LoadItem());
        }

        public JsonResult LoadItem()
        {
            IEnumerable<Item> itemVM = null;
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
                itemVM = readTask.Result;
            }
            else
            {
                itemVM = Enumerable.Empty<Item>();
                ModelState.AddModelError(string.Empty, "Server error");
            }
            return Json(itemVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(Item itemVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var myContent = JsonConvert.SerializeObject(itemVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (itemVM.Id.Equals(0))
            {
                var result = client.PostAsync("Items", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Items/" + itemVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            Item itemVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var responseTask = client.GetAsync("Items/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Item>();
                readTask.Wait();
                itemVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(itemVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var result = client.DeleteAsync("Items/" + id).Result;
        }

        //DropDown

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

        public JsonResult GetLocationProject()
        {
            IEnumerable<Location> location = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("Locations");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Location>>();
                readTask.Wait();
                location = readTask.Result;
            }
            else
            {
                location = Enumerable.Empty<Location>();
                ModelState.AddModelError(string.Empty, "Server error");
            }

            return Json(location, JsonRequestBehavior.AllowGet);
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