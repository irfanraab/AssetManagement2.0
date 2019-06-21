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
using BusinessLogic.Service.Application;
using DataAccess.Context;
using DataAccess.Models;
using DataAccess.ViewModel;

namespace API.Controllers
{
    public class LocationsController : ApiController
    {
        private MyContext db = new MyContext();
        private readonly ILocationService iLocationService;
        public LocationsController() { }
        public LocationsController(ILocationService _iLocationService)
        {
            iLocationService = _iLocationService;
        }

        // GET: api/Location
        public HttpResponseMessage GetLocations()
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            var result = iLocationService.Get();
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            return message;
        }

        // GET: api/Locations/5
        public HttpResponseMessage GetLocation(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLocationService.Get(id);
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            return message;
        }

        // PUT: api/Locations/5
        public HttpResponseMessage UpdateLocation(int id, LocationVM locationVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLocationService.Update(id, locationVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            return message;
        }

        // POST: api/Locations
        public HttpResponseMessage InsertLocation(LocationVM locationVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLocationService.Insert(locationVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.Created);
            }
            return message;
        }

        // DELETE: api/Locations/5
        public HttpResponseMessage DeleteLocation(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLocationService.Delete(id);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            return message;
        }
    }
}