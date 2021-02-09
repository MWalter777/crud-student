using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace crud_students.Models
{
    public class crud_studentsContext : DbContext
    {  
        public crud_studentsContext() : base("name=DefaultConnection") //base("name=crud_studentsContext")
        {
        }

        public System.Data.Entity.DbSet<crud_students.Models.Student> Students { get; set; }
    }
}
