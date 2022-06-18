namespace VeterinaryClinic.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VeterinaryClinic.Models.DBModels;

    internal sealed class Configuration : DbMigrationsConfiguration<VeterinaryClinic.Models.DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VeterinaryClinic.Models.DataBaseContext context)
        {
            //  This method will be called after migrating to the latest version
            // uruchamia siê po wpisaniu do konsoli update-database

            List<Owner> owners = new List<Owner>();
            Owner o1 = new Owner("Jan", "Nowak", "445677654", "Kraków");
            owners.Add(o1);
            Owner o2 = new Owner("Ewa", "Nowak", "332324567", "Katowice");
            owners.Add(o2);
            Owner o3 = new Owner("Julia", "Kwiat", "889878867", "Kraków");
            owners.Add(o3);

            List<Vet> vets = new List<Vet>();
            // int id, string name, string surname, string phoneNumber, EnumSpecjalization specjalization, EnumSex sex, int price
            Vet v1 = new Vet("Jan", "Nowak", "334345546", EnumSpecjalization.dentysta, EnumSex.M, 123);
            vets.Add(v1);
            Vet v2 = new Vet("Ewa", "Nowak", "334567786", EnumSpecjalization.kardiolog, EnumSex.K, 150);
            vets.Add(v2);
            Vet v3 = new Vet("Iwona", "D¹browa", "888767897", EnumSpecjalization.chirurg, EnumSex.K, 230);
            vets.Add(v3);
            Vet v4 = new Vet("Ewa", "Machowska", "223134567", EnumSpecjalization.internista, EnumSex.K, 100);
            vets.Add(v4);


            List<Patient> patients = new List<Patient>();
            //int id, string name, int age, string species, Owner petOwner
            // (int id, string name, string surname, string phoneNumber, string townName
            Patient p1 = new Patient("Max", 4, "pies", o1.Id);
            patients.Add(p1);
            Patient p2 = new Patient("Felix", 2, "kot", o1.Id);
            patients.Add(p2);
            Patient p3 = new Patient("Filemon", 5, "kot", o2.Id);
            patients.Add(p3);
            Patient p4 = new Patient("Pere³ka", 1, "pies", o3.Id);
            patients.Add(p4);


            List<Visit> visits = new List<Visit>
            {
                // int id, DateTime date, Patient patient, Vet vet, string diagnosis
                new Visit(new DateTime(2022,7,23,11,45,00), p1,v1,"rak"),
                new Visit(new DateTime(2023,1,12,10,25,00), p3,v2,"brak"),
                new Visit(new DateTime(2022,8,13,13,40,00), p2,v4,"wymagana dalsza diagnoza"),
                new Visit(new DateTime(2022,6,29,12,30,00), p1,v4,"wymagane badania krwi")
            };


            vets.ForEach(v => context.Vets.Add(v));
            patients.ForEach(p => context.Patients.Add(p));
            visits.ForEach(v => context.Visits.Add(v));
            owners.ForEach(o => context.Owners.Add(o));
            context.SaveChanges();
        }
    }
}
