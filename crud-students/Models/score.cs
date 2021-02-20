namespace crud_students.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("score")]
    public partial class Score
    {
        public int id { get; set; }

        public int? id_studentsubject { get; set; }

        [Column(TypeName = "numeric")]
        public decimal score_data { get; set; }

        public virtual Studentsubject studentsubject { get; set; }
    }
}
