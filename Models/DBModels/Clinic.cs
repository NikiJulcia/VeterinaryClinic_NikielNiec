using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VeterinaryClinic.Models.DBModels
{
    [DisplayName("Przychodnia")]
    public class Clinic
    {
        public int Id { get; set; }
        [DisplayName("Nazwa kliniki")]
        public string Name { get; set; }
        [DisplayName("godziny otwarcia")]
        public string OpeningHours { get; set; }
        public Clinic(int id, string name, string openingHours)
        {
            Id = id;
            Name = name;
            OpeningHours = openingHours;
        }
    }
}