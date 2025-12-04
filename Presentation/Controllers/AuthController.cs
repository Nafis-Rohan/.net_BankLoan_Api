using BLL.Services;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.ApplicationServices;
using System.Web.Http;
using System.Web.Services.Description;

namespace Presentation.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage login(LoginModel loginInfo)
        {
            try
            {
                var token = AuthService.Authenticate(loginInfo.UserName , loginInfo.Password);
                if (token != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, token);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new {Message = "User Not Found"} );
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
