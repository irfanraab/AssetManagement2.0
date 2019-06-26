﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using BusinessLogic.Service;
using DataAccess.Context;
using DataAccess.Models;
using DataAccess.ViewModel;

namespace API.Controllers
{
    public class ProcurementsController : ApiController
    {
        private MyContext db = new MyContext();
        private readonly IProcurementService iProcurementService;
        public ProcurementsController() { }
        public ProcurementsController(IProcurementService _iProcurementService)
        {
            iProcurementService = _iProcurementService;
        }
        // GET: api/Procurements
        public HttpResponseMessage GetProcurements()
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            var result = iProcurementService.Get();
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }

        // GET: api/Procurements/5
        public HttpResponseMessage GetProcurement(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iProcurementService.Get(id);
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }

        // PUT: api/Procurements/5
        public HttpResponseMessage PutProcurement(int id, ProcurementVM procurementVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iProcurementService.Update(id, procurementVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            return message;
        }

        // POST: api/Procurements
        public HttpResponseMessage InsertProcurement(ProcurementVM procurementVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iProcurementService.Insert(procurementVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.Created);
            }
            return message;
        }

        // DELETE: api/Procurements/5
        public HttpResponseMessage DeleteProcurement(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iProcurementService.Delete(id);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            return message;
        }

        // DropDown
        public HttpResponseMessage GetItemByModel(string modelQuery)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not FOund");
                var result = iProcurementService.GetItemByModule(modelQuery);
                if (result != null) message = Request.CreateResponse(HttpStatusCode.OK, result);
                return message;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
        }

        public HttpResponseMessage GetTypeItemByModel(string modelQuery)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not FOund");
                var result = iProcurementService.GetTypeItemByModule(modelQuery);
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