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
    using System.Collections.Generic;
    
    public partial class materias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public materias()
        {
            this.calificaciones = new HashSet<calificaciones>();
            this.horarios_clases = new HashSet<horarios_clases>();
            this.inscripciones = new HashSet<inscripciones>();
        }
    
        public int id { get; set; }
        public string nombre_materia { get; set; }
        public string descripcion { get; set; }
        public string codigo_curso { get; set; }
        public Nullable<int> creditos { get; set; }
        public Nullable<int> ID_Profesor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<calificaciones> calificaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<horarios_clases> horarios_clases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inscripciones> inscripciones { get; set; }
        public virtual profesores profesores { get; set; }
    }
}
