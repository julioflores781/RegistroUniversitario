using Contraladores;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RegistroUniversitario.Controllers
{
    [Route("api/Materias/{action}")]
    public class MateriasController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Obtener()
        {
            try
            {
                Ctrl_Materias _ctrl = new Ctrl_Materias();

                List<materias> resultado = _ctrl.Obtener();

                var result = resultado.Select(d => new
                {
                    d.id,
                    d.ID_Profesor,
                    d.horarios_clases,
                    d.nombre_materia,
                    d.descripcion,
                    d.codigo_curso,
                    d.creditos
                });

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception excepcion)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, excepcion.Message);
            }
        }
    }
}
