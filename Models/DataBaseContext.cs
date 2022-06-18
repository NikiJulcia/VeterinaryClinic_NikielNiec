using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VeterinaryClinic.Models.DBModels;

namespace VeterinaryClinic.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() :
            base("ClinicConnectionString")
        { }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<Visit> Visits { get; set; }
    }
}