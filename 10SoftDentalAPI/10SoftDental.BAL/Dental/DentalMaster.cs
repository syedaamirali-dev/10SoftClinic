using System;
using System.Data;
using _10SoftDental.Factory.DentalMaster;
using _10SoftDental.Factory.DentalClinic;
using _10SoftDental.Factory.Common;

namespace _10SoftDental.BAL.Dental
{
    public class DentalMaster : IDentalMaster,IVisitHistory, ICommonResponse
    {
        private CommonResponse commonResponseResult;
        private DAL.Master.DentalMaster dentalMaster;
        private DataSet dataSet;
        private int? dentalNotationId;
        private bool patientType;
        private string iconNameEn;
        private string iconNameAr;
        private string descriptionEn;
        private string descriptionAr;
        private string imageURL;
        private bool isActive;
        private int? createdBy;
        private int langId;

        private int? visitID;
        private DateTime? visitDate;
        private DateTime? issueDate;
        private int? doctorId;
        private int? patientId;

        public DentalMaster()
        {            
            this.commonResponseResult = new CommonResponse();
            this.dentalMaster = new DAL.Master.DentalMaster();
            this.dataSet = new DataSet();
        }
        public ResponseModel CreateResponse(bool status, string messageCode, string message, object data)
        {
            return this.commonResponseResult.CreateResponse(status, messageCode, message, data);
        }
        public int? VisitID { get => visitID; set => visitID = value; }
        public int? DoctorId { get => doctorId; set => doctorId = value; }
        public int? PatientId { get => patientId; set => patientId = value; }

        public DateTime? VisitDate { get => visitDate; set => visitDate = value; }

        public DateTime? IssueDate { get => issueDate; set => issueDate = value; }

        public int? DentalNotationId { get => dentalNotationId; set => dentalNotationId = value; }
        public bool PatientType { get => patientType; set => patientType = value; }
        public string IconNameEn { get => iconNameEn; set => iconNameEn = value; }
        public string IconNameAr { get => iconNameAr; set => iconNameAr = value; }
        public string DescriptionEn { get => descriptionEn; set => descriptionEn = value; }
        public string DescriptionAr { get => descriptionAr; set => descriptionAr = value; }
        public string ImageURL { get => imageURL; set => imageURL = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public int? CreatedBy { get => createdBy; set => createdBy = value; }
        public int LangId { get => langId; set => langId = value; }

        public DataSet SaveDentalChartNotations()
        {
            return new DAL.Master.DentalMaster().SaveDentalChartNotations(this);
        }

        public DataSet GetDentalChartNotations(int? dentalNotationId, int langId,string ApiUri)
        {
            return new DAL.Master.DentalMaster().GetDentalChartNotations(dentalNotationId, langId, ApiUri);
        }

        public DataSet GetPatientVisitRegister(long? patientId, long? doctorId)
        {
            return new DAL.Master.DentalMaster().GetPatientVisitRegister(patientId, doctorId);
        }

        public DataSet GetPatientInsurance(long patientId)
        {
            return new DAL.Master.DentalMaster().GetPatientInsurance(patientId);
        }


        public ResponseModel SaveVisitRegister(DentalMaster dentalMaster)
        {
            try
            {
                dataSet = this.dentalMaster.SaveVisitRegister(dentalMaster);
                return CreateResponse(Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? true : false, Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? "Success" : "Failed", dataSet.Tables[0].Rows[0]["Message"].ToString(), dataSet);
            }
            catch (Exception ex)
            {
                return CreateResponse(false, "Error", ex.InnerException.ToString(), "");
            }
                   
        }

        public DataSet Dental_GetDropdownMasterData()
        {
            return new DAL.Master.DentalMaster().Dental_GetDropdownMasterData();
        }

     


    }
}
