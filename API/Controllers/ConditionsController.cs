using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessLogic.Service;
using DataAccess.Context;
using DataAccess.Models;
using DataAccess.ViewModel;

namespace API.Controllers
{
    public class ConditionsController : ApiController
    {
        private MyContext db = new MyContext();
        private readonly IConditionService iConditionService;
        public ConditionsController() { }
        public ConditionsController(IConditionService _iConditionService)
        {
            iConditionService = _iConditionService;
        }
        // GET: api/Conditions
        public HttpResponseMessage GetConditions()
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            var result = iConditionService.Get();
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }

        // GET: api/Conditions/5
        public HttpResponseMessage GetCondition(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iConditionService.Get(id);
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }


        // PUT: api/Conditions/5
        public HttpResponseMessage PutCondition(int id, ConditionVM conditionVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iConditionService.Update(id, conditionVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, conditionVM);
            }
            return message;
        }

        // POST: api/Conditions
        public HttpResponseMessage InsertCondition(ConditionVM conditionVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            var result = iConditionService.Insert(conditionVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            return message;
        }

        // DELETE: api/Conditions/5
        public HttpResponseMessage DeleteCondition(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iConditionService.Delete(id);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            return message;
        }
    }
}