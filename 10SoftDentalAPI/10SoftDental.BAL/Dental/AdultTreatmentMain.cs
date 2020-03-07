using System;
using System.Collections.Generic;
using System.Data;
using _10SoftDental.BAL.Helper;
using _10SoftDental.DAL.Common;
using _10SoftDental.Factory.Common;
using _10SoftDental.Factory.DentalClinic;
using _10SoftDental.Factory.Models;

namespace _10SoftDental.BAL.Dental
{
    public class AdultMainTreatment : IDentalTreatment,ICommonResponse
    {
        private AdultMainTreatment adultMainTreatmentBal = null;
        private CommonResponse commonResponseResult;
        private DataSet dataSet;
        private CommonDAL commonDAL = null;
        public AdultMainTreatment()
        {
            this.commonDAL = new CommonDAL();
            this.commonResponseResult = new CommonResponse();
            this.dataSet = new DataSet();
        }
        public ResponseModel CreateResponse(bool status, string messageCode, string message, object data)
        {
            return this.commonResponseResult.CreateResponse(status, messageCode, message, data);
        }
        long? doctorTreatmentId;
        long? visitRegisterid;
        public List<DoctorTreatment> doctorTreatmentsList { get; set; }
        public List<DoctorTreatmentIllness> doctorTreatmentIllnessesList { get; set; }
        public List<DoctorTreatmentSympton> doctorTreatmentSymptonsList { get; set; }
        public List<DoctorTreatmentPatientProblem> doctorTreatmentPatientProblemsList { get; set; }
        public DataTable DoctorTreatmentsDT { get => doctorTreatmentsDT; set => doctorTreatmentsDT = value; }
        public DataTable DoctorTreatmentIllnessesDT { get => doctorTreatmentIllnessesDT; set => doctorTreatmentIllnessesDT = value; }
        public DataTable DoctorTreatmentSymptonsDT { get => doctorTreatmentSymptonsDT; set => doctorTreatmentSymptonsDT = value; }
        public DataTable DoctorTreatmentPatientProblemsDT { get => doctorTreatmentPatientProblemsDT; set => doctorTreatmentPatientProblemsDT = value; }
        public long? DoctorTreatmentId { get => doctorTreatmentId; set => doctorTreatmentId = value; }
        public long? VisitRegisterid { get => visitRegisterid; set => visitRegisterid = value; }

        private DataTable doctorTreatmentsDT;
        private DataTable doctorTreatmentIllnessesDT;
        private DataTable doctorTreatmentSymptonsDT;
        private DataTable doctorTreatmentPatientProblemsDT;
       

        public void SaveDentalAdultTreatmentDiagnosis()
        {
            //commonDAL = new CommonDAL();
            //this.DoctorTreatmentsDT = new ListToDatatable().ToDataTableChiefCompliant(this.doctorTreatmentsList);
            this.DoctorTreatmentIllnessesDT = new ListToDatatable().ToDataTableIllness(this.doctorTreatmentIllnessesList);
            this.DoctorTreatmentSymptonsDT = new ListToDatatable().ToDataTableSympton(this.doctorTreatmentSymptonsList);
            this.DoctorTreatmentPatientProblemsDT = new ListToDatatable().ToDataTablePatientProblem(this.doctorTreatmentPatientProblemsList);
            this.commonDAL.SaveDentalAdultTreatmentDiagnosis(this);
        }

        public ResponseModel SaveDentalTreatmentPlanning()
        {
            try
            {
               // commonDAL = new CommonDAL();
                this.DoctorTreatmentsDT = new ListToDatatable().ToDataTableChiefCompliant(this.doctorTreatmentsList);
                this.dataSet= this.commonDAL.SaveDentalTreatmentPlanning(this);               
                return CreateResponse(Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? true : false, Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? "Success" : "Failed", dataSet.Tables[0].Rows[0]["Message"].ToString(), dataSet);
            }
            catch (Exception ex)
            {
                return CreateResponse(false, "Error", ex.InnerException.ToString(), "");
            }
           
        }
        public DataSet GetDentalAdultTreatmentDetails(long? doctorTreatmentId)
        {           
            return this.commonDAL.GetDentalAdultTreatmentDetails(doctorTreatmentId);
        }
        public DataSet GetDentalAdultTreatmentMaster(string diagnosis)
        {            
            return this.commonDAL.GetDentalAdultTreatmentMaster(diagnosis);
        }
    }
}