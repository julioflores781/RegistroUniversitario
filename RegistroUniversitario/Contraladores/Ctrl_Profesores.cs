using Datos;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contraladores
{
    public class Ctrl_Profesores
    {
        public readonly registro_universitarioEntities context;

        public Ctrl_Profesores(registro_universitarioEntities _context)
        {
            context = _context;
        }
        /// <summary>
        /// Obtener todas las profesores
        /// </summary>
        /// <returns>List<profesores></returns>
        public List<profesores> Obtener()
        {


            context.Configuration.LazyLoadingEnabled = false;

            var resultado = context.profesores.ToList();
            return resultado;
        }

        /// <summary>
        /// Obtener los profesores dinamico
        /// </summary>
        /// <param name="loadOptions"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public LoadResult Obtener2(DataSourceLoadOptions loadOptions)
        {
            try
            {

                context.Configuration.LazyLoadingEnabled = false;
                LoadResult resultado = new LoadResult();
                try
                {
                    resultado = DataSourceLoader.Load(context.profesores, loadOptions);
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
        /// Obtener profesores por id
        /// </summary>
        /// <param name="id">Id profesores</param>
        /// <returns>profesores</returns>
        public profesores ObtenerPorId(int id)
        {


            context.Configuration.LazyLoadingEnabled = false;

            var resultado = context.profesores.Where(x => x.id == id).FirstOrDefault();

            return resultado;

        }


        /// <summary>
        /// Actualizar profesores
        /// </summary>
        /// <param name="obj">profesores</param>
        /// <returns>profesores</returns>
        public profesores Actualizar(profesores obj)
        {

            context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return obj;

        }

        /// <summary>
        /// Crea una nuevo profesor
        /// </summary>
        /// <param name="obj">profesores</param>
        /// <returns>profesores</returns>
        public profesores Guardar(profesores obj)
        {

            context.profesores.Add(obj);
            context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// Elimina un profesor
        /// </summary>
        /// <param name="obj">profesores</param>
        /// <returns>profesores</returns>
        public profesores Eliminar(profesores obj)
        {

            context.profesores.Remove(obj);
            context.SaveChanges();
            return obj;
        }
    }
}
