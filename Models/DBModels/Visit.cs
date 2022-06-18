using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VeterinaryClinic.Models.DBModels
{
    [DisplayName("Wizyta")]
    public class Visit
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Data wizyty")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [DisplayName("Pacjent")]
        public Patient Patient { get; set; }
        [Required, ForeignKey("Patient")]
        public int PatientFK { get; set; }
        [DisplayName("Weterynarz")]
        public Vet Vet { get; set; }
        [Required, ForeignKey("Vet")]
        public int VetFK { get; set; }
        [DisplayName("Diagnoza")]
        public string Diagnosis { get; set; }
        private int CurrentId = 1;
        public Visit() { }
        public Visit(DateTime date, Patient patient, Vet vet, string diagnosis)
        {
            Id = CurrentId;
            CurrentId++;
            Date = date;
            Patient = patient;
            Vet = vet;
            PatientFK = patient.Id;
            VetFK = vet.Id;
            Diagnosis = diagnosis;
        }
    }
}