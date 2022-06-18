using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VeterinaryClinic.Models.DBModels
{
    public enum EnumSpecjalization { okulista, kardiolog,internista, chirurg, dentysta}
    public enum EnumSex { M,K}
    [DisplayName("Weterynarz")]
    public class Vet
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
        [DisplayName("Specjalizacja")]
        public EnumSpecjalization Specjalization { get; set; }
        [DisplayName("Płeć")]
        public EnumSex Sex { get; set; }
        [DisplayName("Cena wizyty")]
        public int Price { get; set; }
        private int CurrentId = 1; 

        public Vet( ) { }
        public Vet(string name, string surname, string phoneNumber, EnumSpecjalization specjalization, EnumSex sex, int price)
        {
            Id = CurrentId;
            CurrentId++;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Specjalization = specjalization;
            Sex = sex;
            Price = price;
        }
    }
}