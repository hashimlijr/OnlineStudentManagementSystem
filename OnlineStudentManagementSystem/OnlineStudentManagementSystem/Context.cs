using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineStudentManagementSystem
{
    public class Context:DbContext
    {
        public Context() : base("StudentMS")
        {
            Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());
        }

        public DbSet<Student> Students { get; set; }
    }
}