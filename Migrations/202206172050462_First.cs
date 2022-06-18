namespace VeterinaryClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clinics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OpeningHours = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        TownName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Species = c.String(),
                        PetOwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Specjalization = c.Int(nullable: false),
                        Sex = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        PatientFK = c.Int(nullable: false),
                        VetFK = c.Int(nullable: false),
                        Diagnosis = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientFK, cascadeDelete: true)
                .ForeignKey("dbo.Vets", t => t.VetFK, cascadeDelete: true)
                .Index(t => t.PatientFK)
                .Index(t => t.VetFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "VetFK", "dbo.Vets");
            DropForeignKey("dbo.Visits", "PatientFK", "dbo.Patients");
            DropIndex("dbo.Visits", new[] { "VetFK" });
            DropIndex("dbo.Visits", new[] { "PatientFK" });
            DropTable("dbo.Visits");
            DropTable("dbo.Vets");
            DropTable("dbo.Patients");
            DropTable("dbo.Owners");
            DropTable("dbo.Clinics");
        }
    }
}
