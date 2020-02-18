using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SoftDental.Factory.Models
{
   public  class DoctorTreatment
    {
        public long DoctorTreatmentDiagnosisId { get; set; }
        public long DoctorTreatmentIdRef { get; set; }

        public int DiagnosisIdRef { get; set; }
        public long Level { get; set; }
        public string Comment { get; set; }
    }

    public class DoctorTreatmentIllness
    {
        public long DoctorTreatmentIllnessId { get; set; }
        public long DoctorTreatmentIdRef { get; set; }

        public int IllnessIdRef { get; set; }
        public long Level { get; set; }
        public string Comment { get; set; }
    }

    public class DoctorTreatmentSympton
    {
        public long DoctorTreatmentSymptomId { get; set; }
        public long DoctorTreatmentIdRef { get; set; }

        public int SymptonIdRef { get; set; }
        public long Level { get; set; }
        public string Comment { get; set; }
    }

    public class DoctorTreatmentPatientProblem
    {
        public long DoctorTreatmentPatientProblemId { get; set; }
        public long DoctorTreatmentIdRef { get; set; }

        public string Problem { get; set; }
        public long Level { get; set; }
        public string Comment { get; set; }
    }
}
