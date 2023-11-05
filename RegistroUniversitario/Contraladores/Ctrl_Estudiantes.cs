using Datos;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public LoadResult Obtener2(DataSourceLoadOptions loadOptions)
        {
            try
            {
                LoadResult resultado = new LoadResult();
                try
                {
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

    }
}
