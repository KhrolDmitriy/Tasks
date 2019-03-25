using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using IGI_lab_1.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace IGI_lab_1
{
    class HospitalDB: DbContext, IDisposable
    {
        public DbSet<HospitalDepartment> HospitalDepartments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var options = optionsBuilder.UseSqlServer(connectionString).Options;
        }

        public void Dispose()
        {
        }
    }
}
