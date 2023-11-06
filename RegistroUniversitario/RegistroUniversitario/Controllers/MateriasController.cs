using Contraladores;
using Datos;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace RegistroUniversitario.Controllers
{
    [Route("api/Materias/{action}")]
    public class MateriasController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Obtener(DataSourceLoadOptions loadOptions)
        {
            try
            {
                registro_universitarioEntities context = new registro_universitarioEntities();

                Ctrl_Materias _ctrl = new Ctrl_Materias(context);

                var resultado = _ctrl.Obtener2(loadOptions);

                //var result = resultado.Select(d => new
                //{
                //    d.id,
                //    d.ID_Profesor,
                //    d.horarios_clases,
                //    d.nombre_materia,
                //    d.descripcion,
                //    d.codigo_curso,
                //    d.creditos
                //});

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception excepcion)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, excepcion.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage Obtener(DataSourceLoadOptions loadOptions, int skip, int take, bool valida_permiso = true)
        {
            try
            {
                registro_universitarioEntities context = new registro_universitarioEntities();

                Ctrl_Materias _ctrl = new Ctrl_Materias(context);
                var resultado = _ctrl.Obtener2(loadOptions);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage ObtenerPorId()
        {
            try
            {
                registro_universitarioEntities context = new registro_universitarioEntities();
                Ctrl_Materias _ctrl = new Ctrl_Materias(context);

                List<materias> resultado = _ctrl.Obtener();

                var result = resultado.Select(d => new
                {
                    d.id,
                    d.nombre_materia,
                    d.descripcion,
                    d.codigo_curso,
                    d.creditos,

                });

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception excepcion)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, excepcion.Message);
            }
        }



        [HttpPost]
        public HttpResponseMessage Insertar(FormDataCollection form)
        {
            try
            {
                string values = form.Get("values");

                registro_universitarioEntities context = new registro_universitarioEntities();
                Ctrl_Materias _ctrl = new Ctrl_Materias(context);

                materias resultado = new materias();

                JsonConvert.PopulateObject(values, resultado);

                var result = _ctrl.Guardar(resultado);

                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception excepcion)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, excepcion.Message);
            }
        }



        [HttpPut]
        public HttpResponseMessage Actualizar(FormDataCollection form)
        {
            try
            {

                int key = Convert.ToInt32(form.Get("key"));
                string values = form.Get("values");

                registro_universitarioEntities context = new registro_universitarioEntities();
                Ctrl_Materias _ctrl = new Ctrl_Materias(context);

                materias resultado = _ctrl.ObtenerPorId(key);

                JsonConvert.PopulateObject(values, resultado);

                var result = _ctrl.Actualizar(resultado);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception excepcion)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, excepcion.Message);
            }
        }





        [HttpDelete]
        public HttpResponseMessage Eliminar(FormDataCollection form)
        {
            try
            {
                int key = Convert.ToInt32(form.Get("key"));


                registro_universitarioEntities context = new registro_universitarioEntities();
                Ctrl_Materias _ctrl = new Ctrl_Materias(context);

                materias resultado = _ctrl.ObtenerPorId(key);

                var result = _ctrl.Eliminar(resultado);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception excepcion)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, excepcion.Message);
            }
        }


    }
}
