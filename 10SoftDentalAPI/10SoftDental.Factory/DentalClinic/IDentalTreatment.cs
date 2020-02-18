using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SoftDental.Factory.DentalClinic
{
    public interface IDentalTreatment
    {
        long? DoctorTreatmentId { get; set; }
        long? VisitRegisterid { get; set; }
        DataTable DoctorTreatmentsDT { get; set; }
         DataTable DoctorTreatmentIllnessesDT { get; set; }
         DataTable DoctorTreatmentSymptonsDT { get; set; }
         DataTable DoctorTreatmentPatientProblemsDT { get; set; }

        void SaveDentalAdultTreatmentDiagnosis();
    }
}
