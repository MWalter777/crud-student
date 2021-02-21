namespace crud_students.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("studentsubject")]
    public partial class Studentsubject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Studentsubject()
        {
        }

        public int id { get; set; }

        public int id_student { get; set; }

        public int id_subject { get; set; }

        public virtual Student student { get; set; }

        public virtual Subject subject { get; set; }

        [Required]
        public virtual double examen1 { get; set; }

        [Required]
        public virtual double examen2 { get; set; }

        [Required]
        public virtual double examen3 { get; set; }

        [Required]
        public virtual double examen4 { get; set; }

    }
}
