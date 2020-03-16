using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SoftDental.Factory.DentalClinic
{
    public interface IVisitHistory
    {
        int? VisitID { get; set; }
        DateTime? VisitDate { get; set; }
        DateTime? IssueDate { get; set; }
        int? PatientId { get; set; }
        int? DoctorId { get; set; }    
        
        string BloodPressure { get; set; }

        bool? IsPregnant { get; set; }

        string Diabetes { get; set; }

        bool? IsFreeVisit { get; set; }

    }
}
