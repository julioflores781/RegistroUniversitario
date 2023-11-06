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
    [Route("api/HorariosMaterias/{action}")]
    public class HorariosMateriasController : ApiController
    {

        #region Consultar


       
        [HttpGet]
        public HttpResponseMessage Obtener(DataSourceLoadOptions loadOptions)
        {
            try
            {
                registro_universitarioEntities context = new registro_universitarioEntities();

                Ctrl_HorariosMaterias _ctrl = new Ctrl_HorariosMaterias(context);
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

                Ctrl_HorariosMaterias _ctrl = new Ctrl_HorariosMaterias(context);
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
                Ctrl_HorariosMaterias _ctrl = new Ctrl_HorariosMaterias(context);

                List<horarios_clases> resultado = _ctrl.Obtener();

                var result = resultado.Select(d => new
                {
                    d.id,
                    d.materias,
                    d.hora_inicio,
                    d.hora_finalizacion,
                    d.aula,
                    d.Lunes,
                    d.martes,
                    d.miercoles,
                    d.jueves,
                    d.viernes

                });

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception excepcion)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, excepcion.Message);
            }
        }
        #endregion

        #region Insertar
        [HttpPost]
        public HttpResponseMessage Insertar(FormDataCollection form)
        {
            try
            {                
                string values = form.Get("values");

                registro_universitarioEntities context = new registro_universitarioEntities();
                Ctrl_HorariosMaterias _ctrl = new Ctrl_HorariosMaterias(context);

                horarios_clases resultado = new horarios_clases();

                JsonConvert.PopulateObject(values, resultado);

                var result = _ctrl.Guardar(resultado);

                return Request.CreateResponse(HttpStatusCode.OK, result);
                
            }
            catch (Exception excepcion)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, excepcion.Message);
            }
        }
        #endregion

        #region Actualizar
        [HttpPut]
        public HttpResponseMessage Actualizar(FormDataCollection form)
        {
            try
            {

                int key = Convert.ToInt32(form.Get("key"));
                string values = form.Get("values");

                registro_universitarioEntities context = new registro_universitarioEntities();
                Ctrl_HorariosMaterias _ctrl = new Ctrl_HorariosMaterias(context);

                horarios_clases resultado = _ctrl.ObtenerPorId(key);

                JsonConvert.PopulateObject(values, resultado);

                var result = _ctrl.Actualizar(resultado);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception excepcion)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, excepcion.Message);
            }
        }


        #endregion

        #region Eliminar
        [HttpDelete]
        public HttpResponseMessage Eliminar(FormDataCollection form)
        {
            try
            {
                int key = Convert.ToInt32(form.Get("key"));
                

                registro_universitarioEntities context = new registro_universitarioEntities();
                Ctrl_HorariosMaterias _ctrl = new Ctrl_HorariosMaterias(context);

                horarios_clases resultado = _ctrl.ObtenerPorId(key);
               
                var result = _ctrl.Eliminar(resultado);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception excepcion)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, excepcion.Message);
            }
        }
        #endregion

    }
}
