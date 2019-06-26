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
using DataAccess.Context;
using DataAccess.Models;
using Common.Repository;
using BusinessLogic.Service;
using DataAccess.ViewModel;

namespace API.Controllers
{
    public class HandoversController : ApiController
    {
        private MyContext db = new MyContext();
        private readonly IHandoverService iHandoverService;
        public HandoversController() { }
        public HandoversController(IHandoverService _iHandoverService)
        {
            iHandoverService = _iHandoverService;
        }

        // GET: api/Handovers
        public HttpResponseMessage GetHandovers()
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            var result = iHandoverService.Get();
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }
    

        // GET: api/Handovers/5
        public HttpResponseMessage GetHandover(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iHandoverService.Get(id);
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }

        // PUT: api/Handovers/5
        public HttpResponseMessage PutHandover(int id, HandoverVM handoverVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iHandoverService.Update(id, handoverVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            return message;
        }

        // POST: api/Handovers
        public HttpResponseMessage InsertHandover(HandoverVM handoverVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iHandoverService.Insert(handoverVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.Created);
            }
            return message;
        }


        // DELETE: api/Handovers/5
        public HttpResponseMessage DeleteHandover(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iHandoverService.Delete(id);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            return message;

        }
    }
}
