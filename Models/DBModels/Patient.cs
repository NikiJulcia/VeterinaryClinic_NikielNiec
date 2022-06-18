using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VeterinaryClinic.Models.DBModels
{
    [DisplayName("Pacjent")]
    public class Patient
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Imie")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Wiek")]
        [Required]
        public int Age { get; set; }
        [DisplayName("Gatunek")]
        public string Species { get; set; }
        [DisplayName("Właściciel (ID)")]
        [Required]
        public int PetOwnerId { get; set; }
        private int CurrentID = 1;
        public Patient() { }
        public Patient(string name, int age, string species, int petOwnerId)
        { 
            Id = CurrentID;
            CurrentID++;
            Name = name;
            Age = age;
            Species = species;
            PetOwnerId = petOwnerId;
        }
    }
}