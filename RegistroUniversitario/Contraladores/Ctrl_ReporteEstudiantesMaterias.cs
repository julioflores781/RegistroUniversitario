using Datos;
using System.Collections.Generic;
using System.Linq;

namespace Contraladores
{
    public class Ctrl_ReporteEstudiantesMaterias
    {
        public readonly registro_universitarioEntities context;

        public Ctrl_ReporteEstudiantesMaterias(registro_universitarioEntities _context)
        {
            context = _context;
        }


        public List<ReporteEstudiantesMateriasHorarios_Result> Obtener()
        {


            context.Configuration.LazyLoadingEnabled = false;

            var resultado = context.Database.SqlQuery<ReporteEstudiantesMateriasHorarios_Result>("exec ReporteEstudiantesMateriasHorarios").ToList();
            return resultado;
        }
    }
}
