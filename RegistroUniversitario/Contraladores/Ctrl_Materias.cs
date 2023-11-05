using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contraladores
{

    public class Ctrl_Materias
    {
        public registro_universitarioEntities context { get; set; }
        public List<materias> Obtener()
        {
            context = new registro_universitarioEntities();

            context.Configuration.LazyLoadingEnabled = false;

            var resultado = context.materias.ToList();
            return resultado;
        }
    }
}
