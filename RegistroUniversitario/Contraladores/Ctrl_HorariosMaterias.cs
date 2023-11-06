using Datos;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contraladores
{
    public class Ctrl_HorariosMaterias
    {
        public readonly registro_universitarioEntities context;

        public Ctrl_HorariosMaterias(registro_universitarioEntities _context)
        {
            context = _context;
        }
        /// <summary>
        /// Obtener todas las horarios_clases
        /// </summary>
        /// <returns>List<horarios_clases></returns>
        public List<horarios_clases> Obtener()
        {


            context.Configuration.LazyLoadingEnabled = false;

            var resultado = context.horarios_clases.ToList();
            return resultado;
        }

        /// <summary>
        /// Obtener los horarios_clases dinamico
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
                    resultado = DataSourceLoader.Load(context.horarios_clases, loadOptions);
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
        /// Obtener horarios_clases por id
        /// </summary>
        /// <param name="id">Id horarios_clases</param>
        /// <returns>horarios_clases</returns>
        public horarios_clases ObtenerPorId(int id)
        {


            context.Configuration.LazyLoadingEnabled = false;

            var resultado = context.horarios_clases.Where(x => x.id == id).FirstOrDefault();

            return resultado;

        }


        /// <summary>
        /// Actualizar horarios_clases
        /// </summary>
        /// <param name="obj">horarios_clases</param>
        /// <returns>horarios_clases</returns>
        public horarios_clases Actualizar(horarios_clases obj)
        {

            context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return obj;

        }

        /// <summary>
        /// Crea una nuevo horarios_clases
        /// </summary>
        /// <param name="obj">horarios_clases</param>
        /// <returns>horarios_clases</returns>
        public horarios_clases Guardar(horarios_clases obj)
        {

            context.horarios_clases.Add(obj);
            context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// Elimina un horarios_clases
        /// </summary>
        /// <param name="obj">horarios_clases</param>
        /// <returns>horarios_clases</returns>
        public horarios_clases Eliminar(horarios_clases obj)
        {

            context.horarios_clases.Remove(obj);
            context.SaveChanges();
            return obj;
        }
    }
}
