using Contraladores;
using Datos;
using DevExtreme.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RegistroUniversitario.Controllers
{
    [Route("api/Estudiantes/{action}")]
    public class EstudiantesController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage Obtener(DataSourceLoadOptions loadOptions)
        {
            try
            {
                registro_universitarioEntities context = new registro_universitarioEntities();

                Ctrl_Estudiantes _ctrl = new Ctrl_Estudiantes(context);
                var resultado = _ctrl.Obtener2(loadOptions);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage Obtener(DataSourceLoadOptions loadOptions, int skip, int take, bool valida_permiso = true)
        {
            try
            {
                registro_universitarioEntities context = new registro_universitarioEntities();

                Ctrl_Estudiantes _ctrl = new Ctrl_Estudiantes(context);
                var resultado = _ctrl.Obtener2(loadOptions);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        //[HttpGet]
        //public HttpResponseMessage Obtener()
        //{
        //    try
        //    {
        //        Ctrl_Estudiantes _ctrl = new Ctrl_Estudiantes();

        //        List<estudiantes> resultado = _ctrl.Obtener();

        //        var result = resultado.Select(d => new
        //        {
        //            d.id,
        //            d.nombre,
        //            d.numero_telefono,
        //            d.direccion,
        //            d.apellido,
        //            d.correo_electronico
        //        });

        //        return Request.CreateResponse(HttpStatusCode.OK, result);
        //    }
        //    catch (Exception excepcion)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Unauthorized, excepcion.Message);
        //    }
        //}

    }
}
