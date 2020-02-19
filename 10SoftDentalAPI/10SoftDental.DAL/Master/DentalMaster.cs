﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public DataSet GetDentalChartNotations(int? dentalNotationId,int langId)
        {
            _storedProcedure = "GetDentalChartNotations";
            _parameters = new SqlParameter[2];
            _parameters[0] = new SqlParameter("@DentalNotationId", SqlDbType.Int);
            _parameters[0].Value = dentalNotationId;
            _parameters[1] = new SqlParameter("@LangId", SqlDbType.Int);
            _parameters[1].Value = langId;
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


        public string SaveVisitRegister(long? visitRegisterId, DateTime IssueDate, long? doctorId, long? patientId, long? modifiedBy)
        {
            dataSet = new DataSet();
            _storedProcedure = "Dental_SaveVisitRegister";
            _parameters = new SqlParameter[5];
            _parameters[0] = new SqlParameter("@VisitRegisterId", SqlDbType.BigInt);
            _parameters[0].Value = visitRegisterId;
            _parameters[1] = new SqlParameter("@IssueDate", SqlDbType.Date);
            _parameters[1].Value = IssueDate;
            _parameters[2] = new SqlParameter("@DoctorIdRef", SqlDbType.BigInt);
            _parameters[2].Value = doctorId;
            _parameters[3] = new SqlParameter("@PatientId", SqlDbType.BigInt);
            _parameters[3].Value = patientId;
            _parameters[4] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
            _parameters[4].Value = modifiedBy;
            dataSet = RunProcedure(_storedProcedure, _parameters, true);
            return (dataSet.Tables[0].Rows[0][0].ToString());
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
    }
}
