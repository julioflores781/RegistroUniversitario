using Datos;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contraladores
{
    public class Ctrl_Estudiantes
    {
        public readonly registro_universitarioEntities context;

        public Ctrl_Estudiantes(registro_universitarioEntities _context)
        {
            context = _context;
        }

        /// <summary>
        /// Obtener todos los estudiantes
        /// </summary>
        /// <returns></returns>
        public List<estudiantes> Obtener()
        {
           

            context.Configuration.LazyLoadingEnabled = false;

            var resultado = context.estudiantes.ToList();
            return resultado;
        }

        /// <summary>
        /// Obtener los estidiantes dinamico
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
                    resultado = DataSourceLoader.Load(context.estudiantes, loadOptions);
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
        /// Obtener estudiante por id
        /// </summary>
        /// <param name="id">Id estudiante</param>
        /// <returns>estudiante</returns>
        public estudiantes ObtenerPorId(int id)
        {


            context.Configuration.LazyLoadingEnabled = false;

            var resultado = context.estudiantes.Where(x => x.id == id).FirstOrDefault();

            return resultado;

        }


        /// <summary>
        /// Actualizar estudiante
        /// </summary>
        /// <param name="obj">estudiante</param>
        /// <returns>estudiante</returns>
        public estudiantes Actualizar(estudiantes obj)
        {

            context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return obj;

        }

        /// <summary>
        /// Crea una nuevo estudiante
        /// </summary>
        /// <param name="obj">estudiante</param>
        /// <returns>estudiante</returns>
        public estudiantes Guardar(estudiantes obj)
        {

            context.estudiantes.Add(obj);
            context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// Elimina un estudiante
        /// </summary>
        /// <param name="obj">estudiante</param>
        /// <returns>estudiante</returns>
        public estudiantes Eliminar(estudiantes obj)
        {

            context.estudiantes.Remove(obj);
            context.SaveChanges();
            return obj;
        }

    }
}
