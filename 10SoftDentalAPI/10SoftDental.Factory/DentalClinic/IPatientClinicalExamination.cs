using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SoftDental.Factory.DentalClinic
{
    public interface IPatientClinicalExamination
    {
         long? PatientClinicalExaminationId { get; set; }
         long DentalAdultMainId { get; set; }
         bool? Lips { get; set; }
         bool? Cheek { get; set; }
         bool? Tongue { get; set; }
         bool? Palat { get; set; }
         bool? LymphNodes { get; set; }
         bool? OralHygiene_Good { get; set; }
         bool? OralHygiene_Fair { get; set; }
         bool? OralHygiene_Poor { get; set; }
         bool? OralHygiene_Plaque { get; set; }
         bool? OralHygiene_Stain { get; set; }
         bool? Gingiva_Normal { get; set; }
         bool? Gingiva_Inflamed { get; set; }
         bool? Gingiva_HyperPlastic { get; set; }
         bool? Profile_ClassI { get; set; }
         bool? Profile_ClassII { get; set; }
         bool? Profile_ClassIII { get; set; }
         long? UpdatedBY { get; set; }
    }
}
