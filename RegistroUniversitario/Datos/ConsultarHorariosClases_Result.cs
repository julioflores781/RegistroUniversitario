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
    
    public partial class ConsultarHorariosClases_Result
    {
        public int id { get; set; }
        public Nullable<int> id_materia { get; set; }
        public Nullable<System.TimeSpan> hora_inicio { get; set; }
        public Nullable<System.TimeSpan> hora_finalizacion { get; set; }
        public string aula { get; set; }
        public Nullable<bool> Lunes { get; set; }
        public Nullable<bool> martes { get; set; }
        public Nullable<bool> miercoles { get; set; }
        public Nullable<bool> jueves { get; set; }
        public Nullable<bool> viernes { get; set; }
    }
}
