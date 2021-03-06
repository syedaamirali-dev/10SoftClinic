﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using _10SoftDental.Factory.DentalClinic;
using _10SoftDental.Factory.DentalMaster;
using ApplicationUtility;

namespace _10SoftDental.DAL.Master
{
    public class DentalMaster : DataAccess
    {
        private string _storedProcedure;
        private DataSet dataSet;
        private SqlParameter[] _parameters;
        public DentalMaster() :
            base(ApplicationUtility.Utility.ConnectionString)
        {
        }

        public DataSet GetDentalChartNotations(int? dentalNotationId,int langId,string ApiUri)
        {
            _storedProcedure = "GetDentalChartNotations";
            _parameters = new SqlParameter[3];
            _parameters[0] = new SqlParameter("@DentalNotationId", SqlDbType.Int);
            _parameters[0].Value = dentalNotationId;
            _parameters[1] = new SqlParameter("@LangId", SqlDbType.Int);
            _parameters[1].Value = langId;
            _parameters[2] = new SqlParameter("@ApiUri", SqlDbType.VarChar);
            _parameters[2].Value = ApiUri;
            return RunProcedure(_storedProcedure, _parameters, true);
        }
        public DataSet SaveDentalChartNotations(IDentalMaster dentalMaster)
        {
            _storedProcedure = "SaveDentalChartNotations";
            _parameters = new SqlParameter[10];
            _parameters[0] = new SqlParameter("@DentalNotationId", SqlDbType.Int);
            _parameters[0].Value = dentalMaster.DentalNotationId;
            _parameters[1] = new SqlParameter("@PatientType", SqlDbType.Bit);
            _parameters[1].Value = dentalMaster.PatientType;
            _parameters[2] = new SqlParameter("@IconNameEn", SqlDbType.NVarChar);
            _parameters[2].Value = dentalMaster.IconNameEn;
            _parameters[3] = new SqlParameter("@IconNameAr", SqlDbType.NVarChar);
            _parameters[3].Value = dentalMaster.IconNameAr;
            _parameters[4] = new SqlParameter("@DescriptionEn", SqlDbType.NVarChar);
            _parameters[4].Value = dentalMaster.DescriptionEn;
            _parameters[5] = new SqlParameter("@DescriptionAr", SqlDbType.NVarChar);
            _parameters[5].Value = dentalMaster.DescriptionAr;
            _parameters[6] = new SqlParameter("@ImageURL", SqlDbType.VarChar);
            _parameters[6].Value = dentalMaster.ImageURL;
            _parameters[7] = new SqlParameter("@IsActive", SqlDbType.Bit);
            _parameters[7].Value = dentalMaster.IsActive;
            _parameters[8] = new SqlParameter("@CreatedBy", SqlDbType.Int);
            _parameters[8].Value = dentalMaster.CreatedBy;
            _parameters[9] = new SqlParameter("@LangId", SqlDbType.Int);
            _parameters[9].Value = dentalMaster.LangId;
            return RunProcedure(_storedProcedure, _parameters, true);
        }


        //public string SaveVisitRegister(long? visitRegisterId, DateTime IssueDate, long? doctorId, long? patientId, long? modifiedBy)
        //{
        //    dataSet = new DataSet();
        //    _storedProcedure = "Dental_SaveVisitRegister";
        //    _parameters = new SqlParameter[5];
        //    _parameters[0] = new SqlParameter("@VisitRegisterId", SqlDbType.BigInt);
        //    _parameters[0].Value = visitRegisterId;
        //    _parameters[1] = new SqlParameter("@IssueDate", SqlDbType.Date);
        //    _parameters[1].Value = IssueDate;
        //    _parameters[2] = new SqlParameter("@DoctorIdRef", SqlDbType.BigInt);
        //    _parameters[2].Value = doctorId;
        //    _parameters[3] = new SqlParameter("@PatientId", SqlDbType.BigInt);
        //    _parameters[3].Value = patientId;
        //    _parameters[4] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
        //    _parameters[4].Value = modifiedBy;
        //    dataSet = RunProcedure(_storedProcedure, _parameters, true);
        //    return (dataSet.Tables[0].Rows[0][0].ToString());
        //}
        public DataSet SaveVisitRegister(IDentalMaster visitHistory)
        {
            dataSet = new DataSet();
            _storedProcedure = "Dental_SaveVisitRegister";
            _parameters = new SqlParameter[9];
            _parameters[0] = new SqlParameter("@VisitRegisterId", SqlDbType.BigInt);
            _parameters[0].Value = visitHistory.VisitID;
            _parameters[1] = new SqlParameter("@IssueDate", SqlDbType.Date);
            _parameters[1].Value = visitHistory.IssueDate;
            _parameters[2] = new SqlParameter("@DoctorIdRef", SqlDbType.BigInt);
            _parameters[2].Value = visitHistory.DoctorId;
            _parameters[3] = new SqlParameter("@PatientId", SqlDbType.BigInt);
            _parameters[3].Value = visitHistory.PatientId;
            _parameters[4] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
            _parameters[4].Value = visitHistory.CreatedBy;
            _parameters[5] = new SqlParameter("@BloodPressure", SqlDbType.NVarChar);
            _parameters[5].Value = visitHistory.BloodPressure;
            _parameters[6] = new SqlParameter("@IsPregnant", SqlDbType.Bit);
            _parameters[6].Value = visitHistory.IsPregnant;
            _parameters[7] = new SqlParameter("@Diabetes", SqlDbType.NVarChar);
            _parameters[7].Value = visitHistory.Diabetes;
            _parameters[8] = new SqlParameter("@IsFreeVisit", SqlDbType.Bit);
            _parameters[8].Value = visitHistory.IsFreeVisit;
            dataSet = RunProcedure(_storedProcedure, _parameters, true);
            return dataSet;
        }

        public DataSet GetPatientVisitRegister(long? patientId, long? doctorId)
        {
            dataSet = new DataSet();
            _storedProcedure = "Dental_GetPatientVisitRegister";
            _parameters = new SqlParameter[2];
            _parameters[0] = new SqlParameter("@PatientId", SqlDbType.BigInt);
            _parameters[0].Value = patientId;
            _parameters[1] = new SqlParameter("@DoctorId", SqlDbType.BigInt);
            _parameters[1].Value = doctorId;
            dataSet = RunProcedure(_storedProcedure, _parameters, true);
            return dataSet;
        }

        public DataSet GetPatientInsurance(long patientId)
        {
              dataSet = new DataSet();
            _storedProcedure = "Dental_GetPatientInsuranceDetails";
            _parameters = new SqlParameter[1];
            _parameters[0] = new SqlParameter("@PatientId", SqlDbType.BigInt);
            _parameters[0].Value = patientId;
            dataSet = RunProcedure(_storedProcedure, _parameters, true);
            return dataSet;
        }

        public DataSet Dental_GetDropdownMasterData()
        {
            dataSet = new DataSet();
            _storedProcedure = "Dental_GetDropdownMasterData";
            dataSet = RunProcedure(_storedProcedure, true);
            return dataSet;
        }

       

        public DataSet Dental_GetAdultMainScreeningData(int? clinicId,long patientId,long? doctorId,long? DoctorTreatmentId,long? dentalMainId,bool? isLocal,int? visitId)
        {
             dataSet = new DataSet();
            _storedProcedure = "GetAdultMainScreeningData";
            _parameters = new SqlParameter[8];
            _parameters[0] = new SqlParameter("@ClinicId", SqlDbType.Int);
            _parameters[0].Value = clinicId;
            _parameters[1] = new SqlParameter("@PatientId", SqlDbType.BigInt);
            _parameters[1].Value = patientId;
            _parameters[2] = new SqlParameter("@PatientMobile", SqlDbType.NVarChar);
            _parameters[2].Value = null;
            _parameters[3] = new SqlParameter("@DoctorId", SqlDbType.BigInt);
            _parameters[3].Value = doctorId;
            _parameters[4] = new SqlParameter("@DoctorTreatmentId", SqlDbType.BigInt);
            _parameters[4].Value = DoctorTreatmentId;
            _parameters[5] = new SqlParameter("@DentalMainId", SqlDbType.BigInt);
            _parameters[5].Value = dentalMainId;
            _parameters[6] = new SqlParameter("@IsLocal", SqlDbType.Bit);
            _parameters[6].Value = isLocal;
            _parameters[7] = new SqlParameter("@VisitID", SqlDbType.BigInt);
            _parameters[7].Value = visitId;
            dataSet = RunProcedure(_storedProcedure, _parameters, true);
            return dataSet;
        }
        public DataSet Dental_SaveLabReport(ILabReport labReport)
        {
            dataSet = new DataSet();
            _storedProcedure = "Dental_SaveTreatmentLabReport";
            _parameters = new SqlParameter[6];
            _parameters[0] = new SqlParameter("@DoctorTreatmentId", SqlDbType.BigInt);
            _parameters[0].Value = labReport.DoctorTreatmentId;
            _parameters[1] = new SqlParameter("@DoctorTreatmentLabReportRequestId", SqlDbType.BigInt);
            _parameters[1].Value = labReport.DoctorTreatmentLabReportRequestId;
            _parameters[2] = new SqlParameter("@MasterNumberId", SqlDbType.BigInt);
            _parameters[2].Value = labReport.MasterNumberId;
            _parameters[3] = new SqlParameter("@LabReportTypeId", SqlDbType.Int);
            _parameters[3].Value = labReport.LabReportTypeId;
            _parameters[4] = new SqlParameter("@PreferredLabId", SqlDbType.Int);
            _parameters[4].Value = labReport.PreferredLabId;
            _parameters[5] = new SqlParameter("@Comments", SqlDbType.NVarChar);
            _parameters[5].Value = labReport.Comments;
            dataSet = RunProcedure(_storedProcedure, _parameters, true);
            return dataSet;
        }
        public DataSet Dental_GetTreatmentLabReports(long? doctorTreatmentId)
        {
            dataSet = new DataSet();
            _storedProcedure = "Dental_GetTreatmentLabReports";
            _parameters = new SqlParameter[1];
            _parameters[0] = new SqlParameter("@DoctorTreatmentId", SqlDbType.BigInt);
            _parameters[0].Value = doctorTreatmentId;
            dataSet = RunProcedure(_storedProcedure, _parameters, true);
            return dataSet;
        }

        public DataSet Dental_ShowTreatmentLabReport(long? labReportRequestId)
        {
            dataSet = new DataSet();
            _storedProcedure = "Dental_ShowLabReportDetails";
            _parameters = new SqlParameter[1];
            _parameters[0] = new SqlParameter("@LabreportRequestId", SqlDbType.BigInt);
            _parameters[0].Value = labReportRequestId;
            dataSet = RunProcedure(_storedProcedure, _parameters, true);
            return dataSet;
        }

        public DataSet GetUserAccessMenu(long userIdRef,long moduleIdRef)
        {
            dataSet = new DataSet();
            _storedProcedure = "Dental_UserAccessMenu";
            _parameters = new SqlParameter[2];
            _parameters[0] = new SqlParameter("@UserIdRef", SqlDbType.BigInt);
            _parameters[0].Value = userIdRef;
            _parameters[1] = new SqlParameter("@ModuleIdRef", SqlDbType.BigInt);
            _parameters[1].Value = moduleIdRef;
            dataSet = RunProcedure(_storedProcedure, _parameters, true);
            return dataSet;
        }
    }
}
