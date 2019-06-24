using Core.Base;
using DataAccess.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Client.Controllers
{
    public class ParametersController : Controller
    {
        BaseLink get = new BaseLink();
        // GET: Locations
        public ActionResult Index()
        {
            return View(LoadParameter());
        }

        public JsonResult LoadParameter()
        {
            IEnumerable<Parameter> parameterVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("Parameters");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Parameter>>();
                readTask.Wait();
                parameterVM = readTask.Result;
            }
            else
            {
                parameterVM = Enumerable.Empty<Parameter>();
                ModelState.AddModelError(string.Empty, "Server error");
            }
            return Json(parameterVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(ParameterVM parameterVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var myContent = JsonConvert.SerializeObject(parameterVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (parameterVM.Id.Equals(0))
            {
                var result = client.PostAsync("Parameters", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Parameters/" + parameterVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            ParameterVM parameterVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var responseTask = client.GetAsync("Parameters/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ParameterVM>();
                readTask.Wait();
                parameterVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(parameterVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var result = client.DeleteAsync("Parameters/" + id).Result;
        }
    }
}