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
    public class LocationsController : Controller
    {
        BaseLink get = new BaseLink();
        // GET: Locations
        public ActionResult Index()
        {
            return View(LoadLocation());
        }

        public JsonResult LoadLocation()
        {
            IEnumerable<Location> locationVM = null;
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
                locationVM = readTask.Result;
            }
            else
            {
                locationVM = Enumerable.Empty<Location>();
                ModelState.AddModelError(string.Empty, "Server error");
            }
            return Json(locationVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(Location locationVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var myContent = JsonConvert.SerializeObject(locationVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (locationVM.Id.Equals(0))
            {
                var result = client.PostAsync("Locations", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Locations/" + locationVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            LocationVM locationVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var responseTask = client.GetAsync("Locations/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<LocationVM>();
                readTask.Wait();
                locationVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(locationVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var result = client.DeleteAsync("Locations/" + id).Result;
        }
    }
}