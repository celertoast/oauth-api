using Microsoft.EntityFrameworkCore;
using SMEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMDBContext
{
   public class KpmDbContext : DbContext
    {

        public KpmDbContext()
        {

        }


        public DbSet<Student> Students { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<LoginUser> LoginUsers { get; set; }

        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-C0FBNF9\SQLEXPRESS;Initial Catalog=kpm;Integrated Security=True");
            }
        }


    }
}
