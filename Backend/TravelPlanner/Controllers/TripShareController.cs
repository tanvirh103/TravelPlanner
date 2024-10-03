using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TravelPlanner.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("TripShare")]
    public class TripShareController : ApiController
    {
        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(TripShareDTO t) {
            try
            {
                var data=TripShareService.Create(t);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "TripShare/Create" });
            }
        }
        [HttpPost]
        [Route("Update")]
        public HttpResponseMessage Update(TripShareDTO t)
        {
            try
            {
                var data=TripShareService.Update(t);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, data);
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "TripShare/Update" });
            }
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id) {
            try
            {
                var data=TripShareService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK,data);
            }
            catch (Exception ex) { 
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg= "TripShare/Get" });
            }
        }
        [HttpGet]
        [Route("Delete/{id}")]
        public HttpResponseMessage Delete(int id) {
            try
            {
                var data = TripShareService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) { 
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg= "TripShare/Delete" });
            }
        }
        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAll() {
            try
            {
                var data=TripShareService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK,data) ;
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "TripShare/GetAll" }); 
            }
        }
    }
}
