using _10SoftDental.Factory.DentalClinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SoftDental.BAL.Dental
{
    public class PatientClinicalExamination: IPatientClinicalExamination
    {
        public PatientClinicalExamination()
        {

            this.PatientClinicalExaminationId = null;
            this.DentalAdultMainId = null;
        }
        public long? PatientClinicalExaminationId { get; set; }
        public long DentalAdultMainId { get; set; }
        public bool? Lips { get; set; }
        public bool? Cheek { get; set; }
        public bool? Tongue { get; set; }
        public bool? Palat { get; set; }
        public bool? LymphNodes { get; set; }
        public bool? OralHygiene_Good { get; set; }
        public bool? OralHygiene_Fair { get; set; }
        public bool? OralHygiene_Poor { get; set; }
        public bool? OralHygiene_Plaque { get; set; }
        public bool? OralHygiene_Stain { get; set; }
        public bool? Gingiva_Normal { get; set; }
        public bool? Gingiva_Inflamed { get; set; }
        public bool? Gingiva_HyperPlastic { get; set; }
        public bool? Profile_ClassI { get; set; }
        public bool? Profile_ClassII { get; set; }
        public bool? Profile_ClassIII { get; set; }
        public long? UpdatedBY { get; set; }
    }
}
