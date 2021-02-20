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
            scores = new HashSet<Score>();
        }

        public int id { get; set; }

        public int id_student { get; set; }

        public int id_subject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Score> scores { get; set; }

        public virtual Student student { get; set; }

        public virtual Subject subject { get; set; }
    }
}
