using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RegistroUniversitario.Controllers
{
    public class PruebaController : ApiController
    {

        [HttpGet]
        [Route("api/Prueba")]
        public HttpResponseMessage Prueba()
        {
            try
            {
                

                return Request.CreateResponse(HttpStatusCode.OK, "Esto es una prueba");
            }
            catch (Exception excepcion)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, excepcion.Message);
            }
        }
    }
}
