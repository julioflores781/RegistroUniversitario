using Contraladores;
using Datos;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace RegistroUniversitario.Controllers
{
    [Route("api/Profesores/{action}")]
    public class ProfesoresController : ApiController
    {

        #region Consultar


       
        [HttpGet]
        public HttpResponseMessage Obtener(DataSourceLoadOptions loadOptions)
        {
            try
            {
                registro_universitarioEntities context = new registro_universitarioEntities();

                Ctrl_Profesores _ctrl = new Ctrl_Profesores(context);
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

                Ctrl_Profesores _ctrl = new Ctrl_Profesores(context);
                var resultado = _ctrl.Obtener2(loadOptions);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        public HttpResponseMessage ObtenerPorId(int id)
        {
            try
            {
                registro_universitarioEntities context = new registro_universitarioEntities();
                Ctrl_Profesores _ctrl = new Ctrl_Profesores(context);

                profesores d = _ctrl.ObtenerPorId( id);

                var result =  new ProfesorViewModel
                {
                    Id = d.id,
                    Nombre = d.nombre,
                    Apellido = d.apellido,
                    Correo_Electronico = d.correo_electronico,
                    Numero_telefono = d.numero_telefono
                    // Mapea otras propiedades aquí
                };

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
                Ctrl_Profesores _ctrl = new Ctrl_Profesores(context);

                profesores resultado = new profesores();

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
                Ctrl_Profesores _ctrl = new Ctrl_Profesores(context);

                profesores resultado = _ctrl.ObtenerPorId(key);

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
                Ctrl_Profesores _ctrl = new Ctrl_Profesores(context);

                profesores resultado = _ctrl.ObtenerPorId(key);
               
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
