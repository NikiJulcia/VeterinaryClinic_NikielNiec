using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VeterinaryClinic.Models.DBModels;

namespace VeterinaryClinic.Models.ViewModels
{
    public class VisitPatientVet
    {
        public Patient Patient { get; set; }
        public Vet Vet { get; set; }
        public Visit Visit { get; set; }

        public VisitPatientVet(Visit v, Patient p, Vet vet)
        {
            Patient = p;
            Vet = vet;
            Visit = v;
        }
    }
}