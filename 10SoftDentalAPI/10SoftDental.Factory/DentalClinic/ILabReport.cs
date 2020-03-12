using _10SoftDental.Factory.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SoftDental.Factory.DentalClinic
{
    public interface ILabReport
    {
        long? DoctorTreatmentLabReportRequestId { get; set; }
        int? MasterNumberId { get; set; }
        string DoctorTreatmentLabReportRequestNumber { get; set; }
        long? DoctorTreatmentId { get; set; }
        int? LabReportTypeId { get; set; }
        string Comments { get; set; }
        int? PreferredLabId { get; set; }
        string ReportStatus { get; set; }

        ResponseModel SaveLabReport();
    }
}
