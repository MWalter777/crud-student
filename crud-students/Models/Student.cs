namespace crud_students.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Data.SqlTypes;

    [Table("Student")]
    public class Student
    {
        public Student()
        {
            create_at = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string surname { get; set; }

        [Required]
        public int age { get; set; }

        [Required]
        [StringLength(20)]
        public string gender { get; set; }

        public DateTime create_at { get; set; }

    }
}