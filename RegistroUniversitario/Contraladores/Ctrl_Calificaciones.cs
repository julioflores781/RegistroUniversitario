using Datos;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contraladores
{
    public class Ctrl_Calificaciones
    {
        public readonly registro_universitarioEntities context;

        public Ctrl_Calificaciones(registro_universitarioEntities _context)
        {
            context = _context;
        }


        /// <summary>
        /// Obtener resultados de un dinamicos
        /// </summary>
        /// <param name="loadOptions"></param>
        /// <returns></returns>
        public LoadResult Obtener2(DataSourceLoadOptions loadOptions)
        {
            try
            {
                LoadResult resultado = new LoadResult();
                try
                {
                    resultado = DataSourceLoader.Load(context.calificaciones, loadOptions);
                    return resultado;
                }
                catch (Exception)
                {
                    return resultado;
                }
            }
            catch (Exception excepcion)
            {
                throw new ApplicationException(excepcion.Message, excepcion.InnerException);
            }
        }

        /// <summary>
        /// Obtener todas las calificaciones
        /// </summary>
        /// <returns>List<calificaciones></returns>
        public List<calificaciones> Obtener()
        {


            context.Configuration.LazyLoadingEnabled = false;

            var resultado = context.calificaciones.ToList();

            return resultado;
        }


        /// <summary>
        /// Obtener calificaciones por id
        /// </summary>
        /// <param name="id">Id Calificacion</param>
        /// <returns>calificaciones</returns>
        public calificaciones ObtenerPorId(int id)
        {


            context.Configuration.LazyLoadingEnabled = false;

            var resultado = context.calificaciones.Where(x => x.id == id).FirstOrDefault();

            return resultado;

        }


        /// <summary>
        /// Actualizar calificaciones
        /// </summary>
        /// <param name="obj">calificaciones</param>
        /// <returns>calificaciones</returns>
        public calificaciones Actualizar(calificaciones obj)
        {

            context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return obj;

        }

        /// <summary>
        /// Crea una nueva calificacion
        /// </summary>
        /// <param name="obj">calificaciones</param>
        /// <returns>calificaciones</returns>
        public calificaciones Guardar(calificaciones obj)
        {

            context.calificaciones.Add(obj);
            context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// Elimina una calificacion
        /// </summary>
        /// <param name="obj">calificaciones</param>
        /// <returns>calificaciones</returns>
        public calificaciones Eliminar(calificaciones obj)
        {

            context.calificaciones.Remove(obj);
            context.SaveChanges();
            return obj;
        }

    }
}
