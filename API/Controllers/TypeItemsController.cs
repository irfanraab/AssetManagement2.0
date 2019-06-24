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
using BusinessLogic.Service;
using DataAccess.ViewModel;

namespace API.Controllers
{
    public class TypeItemsController : ApiController
    {
        private MyContext db = new MyContext();
        private readonly ITypeItemService iTypeItemService;
        public TypeItemsController() { }
        public TypeItemsController(ITypeItemService _iTypeItemService)
        {
            iTypeItemService = _iTypeItemService;
        }
        // GET: api/TypeItem
        public HttpResponseMessage GetTypeItems()
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            var result = iTypeItemService.Get();
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }

        // GET: api/TypeItems/5
        public HttpResponseMessage GetTypeItem(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iTypeItemService.Get(id);
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }

        // PUT: api/TypeItems/5
        public HttpResponseMessage PutTypeItem(int id, TypeItemVM typeItemVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iTypeItemService.Update(id, typeItemVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, typeItemVM);
            }
            return message;
        }

        // POST: api/TypeItems
        public HttpResponseMessage InsertTypeItem(TypeItemVM typeItemVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iTypeItemService.Insert(typeItemVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.Created);
            }
            return message;
        }

        // DELETE: api/TypeItems/5
        public HttpResponseMessage DeleteTypeItem(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iTypeItemService.Delete(id);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            return message;
        }
    }
}