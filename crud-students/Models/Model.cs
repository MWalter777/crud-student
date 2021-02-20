namespace crud_students.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=Model")
        {
        }

        public virtual DbSet<Direction> Directions { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Studentsubject> Studentsubjects { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Subjectteacher> Subjectteachers { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Direction>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Direction>()
                .HasMany(e => e.students)
                .WithOptional(e => e.direction)
                .HasForeignKey(e => e.id_direction)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Score>()
                .Property(e => e.score_data)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Student>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.studentsubjects)
                .WithRequired(e => e.student)
                .HasForeignKey(e => e.id_student);

            modelBuilder.Entity<Studentsubject>()
                .HasMany(e => e.scores)
                .WithOptional(e => e.studentsubject)
                .HasForeignKey(e => e.id_studentsubject)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Subject>()
                .Property(e => e.name_subject)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.studentsubjects)
                .WithRequired(e => e.subject)
                .HasForeignKey(e => e.id_subject);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.subjectteachers)
                .WithRequired(e => e.subject)
                .HasForeignKey(e => e.id_subject);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.dui)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.subjectteachers)
                .WithRequired(e => e.teacher)
                .HasForeignKey(e => e.id_teacher);
        }
    }
}
