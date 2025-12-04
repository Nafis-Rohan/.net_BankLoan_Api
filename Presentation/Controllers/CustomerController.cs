using BLL.DTOs;
using BLL.Services;
using DAL.EF.Tables;
using Presentation.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Presentation.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {

        [Logged]
        [HttpGet]
        [Route("all")]

        public HttpResponseMessage Get()
        {
            try
            {
                var data = CustomerService.Get();
                if (data == null )
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No data found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(CustomerDTO c)
        {
            try
            {
                var data = CustomerService.Create(c);
                if (!data) 
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Customer could not be created");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Logged]
        [HttpGet]
        [Route("all/{id}")]

        public HttpResponseMessage Get(int id)
        {
            try
            {
                var customer = CustomerService.Get(id);
                if (customer == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No data found");

                return Request.CreateResponse(HttpStatusCode.OK, customer);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(CustomerDTO c)
        {
            try
            {
                var data = CustomerService.Update(c);
                if (!data) 
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "update failed");
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Update successful");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = CustomerService.Delete(id);
                if (!data) 
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Customer not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Delete successful");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        [Route("logout/{id}")]
        public HttpResponseMessage Logout(int id)
        {
            try
            {
                
                var a = AuthService.Logout(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Token Expired"});
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



    }
}
