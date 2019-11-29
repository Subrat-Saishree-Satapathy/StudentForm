using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentForm.Models;

namespace StudentForm.Models
{
    public class DatabaseContext:DbContext
    {
        

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }
        public DatabaseContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
          
                optionsBuilder.UseMySQL("server=localhost;Uid=root;Pwd=bablu;persistsecurityinfo=True;database=studentdbform;Allow User Variables=True;");
            }
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; } 
        public DbSet<Viewmodel> Viewmodel { get; set; }
       
    }



}
