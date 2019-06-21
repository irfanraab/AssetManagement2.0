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
    public class ParametersController : ApiController
    {
        private MyContext db = new MyContext();
        private readonly IParameterService iParameterService;
        public ParametersController() { }
        public ParametersController(IParameterService _iParameterService)
        {
            iParameterService = _iParameterService;
        }

        // GET: api/Items
        public HttpResponseMessage GetParameters()
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            var result = iParameterService.Get();
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            return message;
        }

        // GET: api/Parameters/5
        public HttpResponseMessage GetParameter(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iParameterService.Get(id);
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            return message;
        }

        // PUT: api/Parameters/5
        public HttpResponseMessage UpdateParameter(int id, ParameterVM parameterVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iParameterService.Update(id, parameterVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            return message;
        }

        // POST: api/Parameters
        public HttpResponseMessage InsertParameter(ParameterVM parameterVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iParameterService.Insert(parameterVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.Created);
            }
            return message;
        }

        // DELETE: api/Parameters/5
        public HttpResponseMessage DeleteParameter(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iParameterService.Delete(id);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            return message;
        }
    }
}