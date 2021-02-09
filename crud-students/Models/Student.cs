namespace crud_students.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    [Table("Student")]
    public class Student
    {
        public Student()
        {
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

        [Required]
        public DateTime create_at { get; set; }

    }
}