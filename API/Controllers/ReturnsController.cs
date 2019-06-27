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
    public class ReturnsController : ApiController
    {
        private MyContext db = new MyContext();
        private readonly IReturnService iReturnService;
        public ReturnsController() { }
        public ReturnsController(IReturnService _iReturnService)
        {
            iReturnService = _iReturnService;
        }

        // GET: api/Return
        public HttpResponseMessage GetReturns()
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            var result = iReturnService.Get();
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }

        // GET: api/Returns/5
        public HttpResponseMessage GetReturn(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iReturnService.Get(id);
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }

        // PUT: api/Returns/5
        public HttpResponseMessage PutReturn(int id, ReturnVM returnVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iReturnService.Update(id, returnVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            return message;
        }

        // POST: api/Returns
        public HttpResponseMessage InsertRetrun(ReturnVM returnVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iReturnService.Insert(returnVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.Created);
            }
            return message;
        }

        // DELETE: api/Returns/5
        public HttpResponseMessage DeleteReturn(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iReturnService.Delete(id);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            return message;
        }

        public HttpResponseMessage GetTypeItemByModel(string modelQuery)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not FOund");
                var result = iReturnService.GetTypeItemByModule(modelQuery);
                if (result != null) message = Request.CreateResponse(HttpStatusCode.OK, result);
                return message;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
        }

        public HttpResponseMessage GetItemByModel(string modelQuery)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not FOund");
                var result = iReturnService.GetItemByModule(modelQuery);
                if (result != null) message = Request.CreateResponse(HttpStatusCode.OK, result);
                return message;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
        }

        public HttpResponseMessage GetConditionByModel(string modelQuery)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not FOund");
                var result = iReturnService.GetConditionByModule(modelQuery);
                if (result != null) message = Request.CreateResponse(HttpStatusCode.OK, result);
                return message;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
        }
    }
}