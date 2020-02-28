using _10SoftDental.BAL.Dental;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SoftDental.BAL.Helper
{
   public class DatatableToList
    {
            public List<TeethSectionNotationMapping> TeethList(DataTable dt)
            {
                var convertedList = (from col in dt.AsEnumerable()
                                     select new TeethSectionNotationMapping()
                                     {
                                         TeethSectionNotationMappingId = Convert.ToInt32(col["TeethSectionNotationMappingId"]),
                                         DentalTeethMasterId = Convert.ToInt32(col["DentalTeethMasterId"]),
                                         DentalTeethSectionMasterId = Convert.ToInt32(col["DentalTeethSectionMasterId"]),
                                         DentalNotationId = Convert.ToInt32(col["DentalNotationId"]),
                                         DentalAdultMainId = Convert.ToInt64(col["DentalAdultMainId"]),
                                         VisitRegisterId = Convert.ToInt64(col["VisitRegisterId"]),
                                         Color = Convert.ToString(col["Color"])
                                     }).ToList();
                return convertedList.ConvertAll<TeethSectionNotationMapping>(o => (TeethSectionNotationMapping)o);
            }

        public List<PatientMedication> PatientMedicationList(DataTable dt)
        {
            var convertedList = (from col in dt.AsEnumerable()
                                 select new PatientMedication()
                                 {
                                     DoctorTreatmentMedicationId = Convert.ToInt64(col["DoctorTreatmentMedicationId"]),
                                     NoOfTimes = Convert.ToInt16(col["NoOfTimes"]),
                                     DosageIdRef = Convert.ToInt32(col["DosageIdRef"]),
                                     Quantities = Convert.ToInt32(col["Quantities"]),
                                     MedicineIdRef = Convert.ToInt64(col["MedicineIdRef"]),
                                     DentalAdultMainId = Convert.ToInt64(col["DentalAdultMainId"]),
                                     MedicineAr = Convert.ToString(col["MedicineAr"]),
                                     MedicineEn = Convert.ToString(col["MedicineEn"]),
                                     DosageEn = Convert.ToString(col["DosageEn"]),
                                     DosageAr = Convert.ToString(col["DosageAr"]),
                                 }).ToList();
            return convertedList.ConvertAll<PatientMedication>(o => (PatientMedication)o);
        }

        public List<PatientClinicalExamination> PatientClinicalExamincationList(DataTable dt)
        {
            var convertedList = (from col in dt.AsEnumerable()
                                 select new PatientClinicalExamination()
                                 {
                                     PatientClinicalExaminationId = Convert.ToInt64(col["PatientClinicalExaminationId"]),
                                     DentalAdultMainId = Convert.ToInt64(col["DentalAdultMainId"]),
                                     Lips = Convert.ToBoolean(col["Lips"]),
                                     Cheek = Convert.ToBoolean(col["Cheek"]),
                                     Tongue = Convert.ToBoolean(col["Tongue"]),
                                     Palat = Convert.ToBoolean(col["Palat"]),
                                     LymphNodes = Convert.ToBoolean(col["LymphNodes"]),
                                     OralHygiene_Good = Convert.ToBoolean(col["OralHygiene_Good"]),
                                     OralHygiene_Fair = Convert.ToBoolean(col["OralHygiene_Fair"]),
                                     OralHygiene_Poor = Convert.ToBoolean(col["OralHygiene_Poor"]),
                                     OralHygiene_Plaque = Convert.ToBoolean(col["OralHygiene_Plaque"]),
                                     OralHygiene_Stain = Convert.ToBoolean(col["OralHygiene_Stain"]),
                                     Gingiva_Normal = Convert.ToBoolean(col["Gingiva_Normal"]),
                                     Gingiva_Inflamed = Convert.ToBoolean(col["Gingiva_Inflamed"]),
                                     Gingiva_HyperPlastic = Convert.ToBoolean(col["Gingiva_HyperPlastic"]),
                                     Profile_ClassI = Convert.ToBoolean(col["Profile_ClassI"]),
                                     Profile_ClassII = Convert.ToBoolean(col["Profile_ClassII"]),
                                     Profile_ClassIII = Convert.ToBoolean(col["Profile_ClassIII"])
                                 }).ToList();
            return convertedList.ConvertAll<PatientClinicalExamination>(o => (PatientClinicalExamination)o);
        }
    }
}
