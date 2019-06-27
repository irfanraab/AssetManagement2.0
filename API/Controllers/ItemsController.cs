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
    public class ItemsController : ApiController
    {
        private MyContext db = new MyContext();
        private readonly IItemService iItemService;
        public ItemsController() { }
        public ItemsController(IItemService _iItemService)
        {
            iItemService = _iItemService;
        }

        // GET: api/Items
        public HttpResponseMessage GetItems()
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            var result = iItemService.Get();
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }

        // GET: api/Items/5
        public HttpResponseMessage GetItem(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iItemService.Get(id);
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }

        // PUT: api/Items/5
        public HttpResponseMessage PutItem(int id, ItemVM itemVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iItemService.Update(id, itemVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            return message;
        }

        // POST: api/Items
        public HttpResponseMessage InsertItem(ItemVM itemVM)
        {

            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iItemService.Insert(itemVM);
            if (result)
                if (result)
                {
                    message = Request.CreateResponse(HttpStatusCode.Created);
                }
            return message;
        }

        // DELETE: api/Items/5
        public HttpResponseMessage DeleteItem(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iItemService.Delete(id);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            return message;
        }

        // DropDown
        public HttpResponseMessage GetTypeItemByModel(string modelQuery)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not FOund");
                var result = iItemService.GetTypeItemByModule(modelQuery);
                if (result != null) message = Request.CreateResponse(HttpStatusCode.OK, result);
                return message;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
        }

        public HttpResponseMessage GetLocationByModel(string modelQuery)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not FOund");
                var result = iItemService.GetLocationByModule(modelQuery);
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
                var result = iItemService.GetConditionByModule(modelQuery);
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