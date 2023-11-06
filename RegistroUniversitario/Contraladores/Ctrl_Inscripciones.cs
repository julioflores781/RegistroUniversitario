using Datos;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contraladores
{
    public  class Ctrl_Inscripciones
    {
        public readonly registro_universitarioEntities context;

        public Ctrl_Inscripciones(registro_universitarioEntities _context)
        {
            context = _context;
        }


        /// <summary>
        /// Obtener todos las inscripciones
        /// </summary>
        /// <returns></returns>
        public List<inscripciones> Obtener()
        {


            context.Configuration.LazyLoadingEnabled = false;

            var resultado = context.inscripciones.ToList();
            return resultado;
        }

        /// <summary>
        /// Obtener las inscripciones dinamico
        /// </summary>
        /// <param name="loadOptions"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public LoadResult Obtener2(DataSourceLoadOptions loadOptions)
        {
            try
            {
                LoadResult resultado = new LoadResult();
                try
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    resultado = DataSourceLoader.Load(context.inscripciones, loadOptions);
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
        /// Obtener inscripciones por id
        /// </summary>
        /// <param name="id">Id inscripciones</param>
        /// <returns>inscripciones</returns>
        public inscripciones ObtenerPorId(int id)
        {


            context.Configuration.LazyLoadingEnabled = false;

            var resultado = context.inscripciones.Where(x => x.id == id).FirstOrDefault();

            return resultado;

        }


        /// <summary>
        /// Actualizar inscripciones
        /// </summary>
        /// <param name="obj">inscripciones</param>
        /// <returns>inscripciones</returns>
        public inscripciones Actualizar(inscripciones obj)
        {

            context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return obj;

        }

        /// <summary>
        /// Crea una nuevo inscripciones
        /// </summary>
        /// <param name="obj">inscripciones</param>
        /// <returns>inscripciones</returns>
        public inscripciones Guardar(inscripciones obj)
        {

            context.inscripciones.Add(obj);
            context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// Elimina un inscripciones
        /// </summary>
        /// <param name="obj">inscripciones</param>
        /// <returns>inscripciones</returns>
        public inscripciones Eliminar(inscripciones obj)
        {

            context.inscripciones.Remove(obj);
            context.SaveChanges();
            return obj;
        }

    }
}
