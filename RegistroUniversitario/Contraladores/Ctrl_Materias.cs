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

    public class Ctrl_Materias
    {
        public readonly registro_universitarioEntities context;

        public Ctrl_Materias(registro_universitarioEntities _context)
        {
            context = _context;
        }
        /// <summary>
        /// Obtener todas las Materias
        /// </summary>
        /// <returns>List<materias></returns>
        public List<materias> Obtener()
        {
            context.Configuration.LazyLoadingEnabled = false;

            var resultado = context.materias.ToList();
            return resultado;
        }

        /// <summary>
        /// Obtener los Materias dinamico
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
                    resultado = DataSourceLoader.Load(context.materias, loadOptions);
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
        /// Obtener materias por id
        /// </summary>
        /// <param name="id">Id materias</param>
        /// <returns>materias</returns>
        public materias ObtenerPorId(int id)
        {


            context.Configuration.LazyLoadingEnabled = false;

            var resultado = context.materias.Where(x => x.id == id).FirstOrDefault();

            return resultado;

        }


        /// <summary>
        /// Actualizar materias
        /// </summary>
        /// <param name="obj">materias</param>
        /// <returns>materias</returns>
        public materias Actualizar(materias obj)
        {

            context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return obj;

        }

        /// <summary>
        /// Crea una nueva materias
        /// </summary>
        /// <param name="obj">materias</param>
        /// <returns>materias</returns>
        public materias Guardar(materias obj)
        {

            context.materias.Add(obj);
            context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// Elimina una materias
        /// </summary>
        /// <param name="obj">materias</param>
        /// <returns>materias</returns>
        public materias Eliminar(materias obj)
        {

            context.materias.Remove(obj);
            context.SaveChanges();
            return obj;
        }
    }
}
