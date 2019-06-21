using Core.Base;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class ConditionsController : Controller
    {
        BaseLink get = new BaseLink();
        // GET: Conditions
        public ActionResult Index()
        {
            return View(LoadCondition());
        }

        public JsonResult LoadCondition()
        {
            IEnumerable<ConditionVM> conditionVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("Conditions");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ConditionVM>>();
                readTask.Wait();
                conditionVM = readTask.Result;
            }
            else
            {
                conditionVM = Enumerable.Empty<ConditionVM>();
                ModelState.AddModelError(string.Empty, "Server error");
            }
            return Json(conditionVM, JsonRequestBehavior.AllowGet);
        }
    }
}