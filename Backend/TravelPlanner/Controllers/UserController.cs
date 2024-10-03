using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TravelPlanner.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("User")]
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(UserDTO u) {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = UserService.Create(u);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else {
                        var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();

                    var response = new
                    {
                        Message = "Validation failed",
                        Errors = errors
                    };

                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }
                
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "User/Create" });
            }
        }
        [HttpPost]
        [Route("Update")]
        public HttpResponseMessage Update(UserDTO u) {
            try
            {
                var data = UserService.Update(u);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) { 
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg= "User/Update" });
            }
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id) {
            try
            {
                var data=UserService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK,data);
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg= "User/Get" });
            }
        }
        [HttpGet]
        [Route("Delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = UserService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "User/Delete" });
            }
        }
        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAll() {
            try
            {
                var data = UserService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "User/GetAll" });
            }
        }
        [HttpPost]
        [Route("Login")]
        public HttpResponseMessage Login(UserDTO k)
        {
            try
            {
                var data = AuthService.Authenticate(k.Email, k.Password);
                return Request.CreateResponse(HttpStatusCode.OK,data);
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex);
            }
            
        }
    }
}
