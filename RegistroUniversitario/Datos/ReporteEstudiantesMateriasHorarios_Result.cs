//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    
    public partial class ReporteEstudiantesMateriasHorarios_Result
    {
        public string NombreEstudiante { get; set; }
        public string ApellidoEstudiante { get; set; }
        public string Materia { get; set; }
        public string NombreProfesor { get; set; }
        public string ApellidoProfesor { get; set; }
        public Nullable<bool> lunes { get; set; }
        public Nullable<bool> martes { get; set; }
        public Nullable<bool> miercoles { get; set; }
        public Nullable<bool> jueves { get; set; }
        public Nullable<bool> viernes { get; set; }
        public Nullable<System.TimeSpan> Hora_Inicio { get; set; }
        public Nullable<System.TimeSpan> Hora_Finalizacion { get; set; }
        public string Aula { get; set; }
    }
}