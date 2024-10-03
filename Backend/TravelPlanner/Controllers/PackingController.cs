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
    [RoutePrefix("Packing")]
    public class PackingController : ApiController
    {
        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(PackingDTO p) {
            try
            {
                var data = PackingService.Create(p);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Packing/Create" });
            }
        }
        [HttpPost]
        [Route("Update")]
        public HttpResponseMessage Update(PackingDTO p) {
            try
            {
                var data = PackingService.Update(p);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Packing/Update" });
            }
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id) {
            try
            {
                var data=PackingService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK,data);
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Packing/Get" });
            }
        }
        [HttpGet]
        [Route("Delete/{id}")]
        public HttpResponseMessage Delete(int id) {
            try
            {
                var data=PackingService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Delete Done" });
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Packing/Delete" });
            }
        }
        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAll() {
            try
            {
                var data=PackingService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK,data );
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Packing/GetAll" });
            }
        }
    }
}
