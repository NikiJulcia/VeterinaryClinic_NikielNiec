using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VeterinaryClinic.Models.DBModels
{
    [DisplayName("Właściciel")]
    public class Owner
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Imie")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Nazwisko")]
        [Required]
        public string Surname { get; set; }
        [DisplayName("Nr. telefonu")]
        [RegularExpression(@"^\d{9}$")]
        public string PhoneNumber { get; set; }
        [DisplayName("Miasto")]
        public string TownName { get; set; }
        private int CurrentOwnerId = 1;

        public Owner() { }

        public Owner(string name, string surname, string phoneNumber, string townName)
        {
            Id = CurrentOwnerId;
            CurrentOwnerId++;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            TownName = townName;
        }
    }
}