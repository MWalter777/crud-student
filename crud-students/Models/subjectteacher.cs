namespace crud_students.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("subjectteacher")]
    public partial class Subjectteacher
    {
        public int id { get; set; }

        public int id_subject { get; set; }

        public int id_teacher { get; set; }

        public virtual Subject subject { get; set; }

        public virtual Teacher teacher { get; set; }
    }
}
