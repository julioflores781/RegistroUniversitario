using Contraladores;
using Datos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RegistroUniversitario.Controllers
{
    [Route("api/ReportesMaterias/{action}")]
    public class ReporteEstudiantesMateriasController : ApiController
    {


        [HttpGet]
        public HttpResponseMessage Obtener()
        {
            try
            {
                registro_universitarioEntities context = new registro_universitarioEntities();
                Ctrl_ReporteEstudiantesMaterias _ctrl = new Ctrl_ReporteEstudiantesMaterias(context);

                List<ReporteEstudiantesMateriasHorarios_Result> result = _ctrl.Obtener();

                

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception excepcion)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, excepcion.Message);
            }
        }

    }
}
