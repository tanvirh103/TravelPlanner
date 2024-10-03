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
    [RoutePrefix("Budget")]
    public class BudgetController : ApiController
    {
        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(BudgetDTO b) {
            try {
                var data=BudgetService.Create(b);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,new{Msg= "Budget/Create" });
            }
        }
        [HttpPost]
        [Route("Update")]
        public HttpResponseMessage Update(BudgetDTO b) {
            try
            {
                var data=BudgetService.Update(b);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Budget/Update" });
            }
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id) {
            try
            {
                var data=BudgetService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK,data);
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Budget/GET" });
            }
        }
        [HttpGet]
        [Route("Delete/{id}")]
        public HttpResponseMessage Delete(int id) {
            try
            {
                var data=BudgetService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Delete Done" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Budget/Delete" });
            }
        }
        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAll() {
            try
            {
                var data=BudgetService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK,data );
            }
            catch (Exception ex)
            { 
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new {Msg= "Budget/GetAll" });
            }
        }
    }
}
