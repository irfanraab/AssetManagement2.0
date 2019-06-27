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
    public class LoaningsController : ApiController
    {
        private MyContext db = new MyContext();
        private readonly ILoaningService iLoaningService;
        public LoaningsController() { }
        public LoaningsController(ILoaningService _iLoaningService)
        {
            iLoaningService = _iLoaningService;
        }

        // GET: api/Loanings
        public HttpResponseMessage GetLoanings()
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            var result = iLoaningService.Get();
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }

        // GET: api/Loanings/5
        public HttpResponseMessage GetLoaning(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            var result = iLoaningService.Get(id);
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }

        // PUT: api/Loanings/5
        public HttpResponseMessage PutLoaning(int id, LoaningVM loaningVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLoaningService.Update(id, loaningVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, "Update SUccesfully");
            }
            return message;
        }

        // POST: api/Loanings
        public HttpResponseMessage InsertLoaning(LoaningVM loaningVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLoaningService.Insert(loaningVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.Created, "Insert Succesfully");
            }
            return message;
        }

        // DELETE: api/Loanings/5
        public HttpResponseMessage DeleteLoaning(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLoaningService.Delete(id);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, "Delete Succesfully");
            }
            return message;
        }
        public HttpResponseMessage GetTypeItemByModel(string modelQuery)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not FOund");
                var result = iLoaningService.GetTypeItemByModule(modelQuery);
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
                var result = iLoaningService.GetItemByModule(modelQuery);
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