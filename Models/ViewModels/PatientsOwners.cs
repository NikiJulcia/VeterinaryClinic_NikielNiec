using System;
using System.Collections.Generic;
using VeterinaryClinic.Models.DBModels;

namespace VeterinaryClinic.Models.ViewModels
{
    public class PatientOwner
    {
        public Patient Patient { get; set; }
        public Owner Owner {get; set;}

        public PatientOwner(Patient p, Owner o)
        {
            Patient = p;
            Owner = o;
        }
    }
}