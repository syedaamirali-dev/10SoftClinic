using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SoftDental.BAL.Dental
{
     public class PatientMedication
    {

        public long? DoctorTreatmentMedicationId { get; set; }
        public long DentalAdultMainId { get ; set; }
        public long MedicineIdRef { get; set; }
        public long DosageIdRef { get; set; }
        public Int16 NoOfTimes { get; set; }
        public int Quantities { get; set; }
        public long DoctorTreatmentId { get; set; }
        public string MedicineAr { get; set; }
        public string MedicineEn { get; set; }
        public string DosageEn { get; set; }
        public string DosageAr { get; set; }
        public long DoctorTreatmentIdRef { get; set; }
    }


    public class PatientLabReport
    {
        public long? DentalLabReportId { get; set; }
        public long DentalAdultMainId { get; set; }
        public string LabReportRequestId { get; set; }
        public int ReportTypeId { get; set; }
        public int PreferredLabId { get; set; }
        public string Comments { get; set; }

    }
}
