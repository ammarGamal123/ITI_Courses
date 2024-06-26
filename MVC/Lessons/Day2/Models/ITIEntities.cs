﻿using Microsoft.EntityFrameworkCore;

namespace Day2.Models
{
    // Requirements for connection to Database: 
    // 1) Database Name 
    // 2) Server Name 
    // 3) Authantication (Windows auth , Admin auth)

    public class ITIEntities : DbContext
    {

        public ITIEntities() : base()
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source =DESKTOP-QU1F590;Initial Catalog=ITI_DB;Integrated Security=True;TrustServerCertificate=True");
            // dbms , Server Name , db , auth

            base.OnConfiguring(optionsBuilder);
        }
    }
}
