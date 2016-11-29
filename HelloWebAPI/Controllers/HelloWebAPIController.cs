using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace HelloWebAPI.Controllers
{
    [RoutePrefix("api/HelloWebAPI")]
    public class HelloWebAPIController : ApiController
    {
        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetMessage()
        {
            return  Request.CreateResponse(HttpStatusCode.OK, "Hello From WEB API at " + DateTime.Now);
        }

        [HttpGet]
        [Route("{a:float}")]
        public HttpResponseMessage GeSecondMessage(float a)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Value Passed - " + a + ". |||| " + DateTime.Now);
        }

        [HttpGet]
        [Route("{s}/{i:int}")]
        public HttpResponseMessage GeSecondMessage(string s, int i)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Value 1 - " + s + ". |||| Value 2 - " + i + ". |||| " + DateTime.Now);
        }
    }
}