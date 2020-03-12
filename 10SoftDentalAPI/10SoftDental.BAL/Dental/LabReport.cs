using _10SoftDental.Factory.Common;
using _10SoftDental.Factory.DentalClinic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SoftDental.BAL.Dental
{
    public class LabReport:ILabReport
    {
        private CommonResponse commonResponseResult;
        private DAL.Master.DentalMaster dentalMaster;
        private DataSet dataSet;
         public LabReport()
        {
            this.commonResponseResult = new CommonResponse();
            this.dentalMaster = new DAL.Master.DentalMaster();
            this.dataSet = new DataSet();
        }
        public ResponseModel CreateResponse(bool status, string messageCode, string message, object data)
        {
            return this.commonResponseResult.CreateResponse(status, messageCode, message, data);
        }
        private long? doctorTreatmentLabReportRequestId;
        private int? masterNumberId;
        private string doctorTreatmentLabReportRequestNumber;
        private long? doctorTreatmentId;
        private int? labReportTypeId;
        private string comments;
        private int? preferredLabId;
        private string reportStatus;

        public long? DoctorTreatmentLabReportRequestId { get => doctorTreatmentLabReportRequestId; set => doctorTreatmentLabReportRequestId = value; }
        public int? MasterNumberId { get => masterNumberId; set => masterNumberId = value; }
        public string DoctorTreatmentLabReportRequestNumber { get => doctorTreatmentLabReportRequestNumber; set => doctorTreatmentLabReportRequestNumber = value; }
        public long? DoctorTreatmentId { get => doctorTreatmentId; set => doctorTreatmentId = value; }
        public int? LabReportTypeId { get => labReportTypeId; set => labReportTypeId = value; }
        public string Comments { get => comments; set => comments = value; }
        public int? PreferredLabId { get => preferredLabId; set => preferredLabId = value; }
        public string ReportStatus { get => reportStatus; set => reportStatus = value; }

        public ResponseModel SaveLabReport()
        {
            try
            {
                this.dataSet = this.dentalMaster.Dental_SaveLabReport(this);
                return CreateResponse(Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? true : false, Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? "Success" : "Failed", dataSet.Tables[0].Rows[0]["Message"].ToString(), dataSet);
            }
            catch (Exception ex)
            {
                return CreateResponse(false, "Error", ex.InnerException.ToString(), "");
            }
        }
        public ResponseModel GetLabReport(long? doctorTreatmentId)
        {
            try
            {
                this.dataSet = this.dentalMaster.Dental_GetTreatmentLabReports(doctorTreatmentId);
                return CreateResponse(true, "Success" , "GetAllLabReports", dataSet);
            }
            catch (Exception ex)
            {
                return CreateResponse(false, "Error", ex.InnerException.ToString(), "");
            }
        }
    }
}
