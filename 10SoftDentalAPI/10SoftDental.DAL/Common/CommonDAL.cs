﻿using System.Data;
using System.Data.SqlClient;

namespace _10SoftDental.DAL.Common
{
    public class CommonDAL : ApplicationUtility.DataAccess
    {
        private string _storedProcedure;
        private DataSet dataSet;
        private SqlParameter[] _parameters;

        public CommonDAL() :
            base(ApplicationUtility.Utility.ConnectionString)
        {
        }
        public DataSet GetAllWaitingList()
        {
            _storedProcedure = "VisitRegister_SelectByCriteria";
            _parameters = new SqlParameter[5];
            _parameters[0] = new SqlParameter("@IsLocal", SqlDbType.Bit);
            _parameters[0].Value = 0;
            _parameters[1] = new SqlParameter("@ClinicIdRef", SqlDbType.Int);
            _parameters[1].Value = 3;
            _parameters[2] = new SqlParameter("@PageIndex", SqlDbType.Int);
            _parameters[2].Value = 1;
            _parameters[3] = new SqlParameter("@PageRecord", SqlDbType.Int);
            _parameters[3].Value = 100;
            _parameters[4] = new SqlParameter("@DoctorIdRef", SqlDbType.Int);
            _parameters[4].Value = 13;
            return RunProcedure(_storedProcedure, _parameters, true);
        }
        public DataSet GetAllVisitList()
        {
            _storedProcedure = "VisitRegister_SelectByCriteria";
            _parameters = new SqlParameter[4];
            _parameters[0] = new SqlParameter("@IsLocal", SqlDbType.Bit);
            _parameters[0].Value = 0;
            _parameters[1] = new SqlParameter("@ClinicIdRef", SqlDbType.Int);
            _parameters[1].Value = 3;
            _parameters[2] = new SqlParameter("@PageIndex", SqlDbType.Int);
            _parameters[2].Value = 1;
            _parameters[3] = new SqlParameter("@PageRecord", SqlDbType.Int);
            _parameters[3].Value = 100;
            //_parameters[4] = new SqlParameter("@DoctorIdRef", SqlDbType.Int);
            //_parameters[4].Value = 13;
            return RunProcedure(_storedProcedure, _parameters, true);
        }

      

        public DataSet ValidateUser(string userName, string password)
        {
            _storedProcedure = "User_ValidateLogin";
            _parameters = new SqlParameter[2];
            _parameters[0] = new SqlParameter("@Username", SqlDbType.NVarChar);
            _parameters[0].Value = userName;
            _parameters[1] = new SqlParameter("@Password", SqlDbType.NVarChar);
            _parameters[1].Value = password;
            return RunProcedure(_storedProcedure, _parameters, true);
        }
<<<<<<< HEAD

        public string SaveDentalAdultMain(IPatientAdultMainScreen patient)
        {
            try
            {
                dataSet = new DataSet();
                _storedProcedure = "SaveDentalAdultMain";
                _parameters = new SqlParameter[12];
                _parameters[0] = new SqlParameter("@DentalAdultMainId", SqlDbType.BigInt);
                _parameters[0].Value = patient.DentalAdultMainId;
                _parameters[1] = new SqlParameter("@PatientId", SqlDbType.BigInt);
                _parameters[1].Value = patient.PatientId;
                _parameters[2] = new SqlParameter("@ClinicRefId", SqlDbType.BigInt);
                _parameters[2].Value = patient.ClinicId;
                _parameters[3] = new SqlParameter("@VisitRegisterId", SqlDbType.BigInt);
                _parameters[3].Value = patient.VisitRegisterId;
                _parameters[4] = new SqlParameter("@DoctorTreatmentId", SqlDbType.BigInt);
                _parameters[4].Value = patient.DoctorTreatmentId;
                _parameters[5] = new SqlParameter("@DoctorAssignedTo", SqlDbType.BigInt);
                _parameters[5].Value = patient.DoctorAssignedTo;
                _parameters[6] = new SqlParameter("@Comments", SqlDbType.NVarChar);
                _parameters[6].Value = patient.Comments;
                _parameters[7] = new SqlParameter("@IssueDate", SqlDbType.DateTime);
                _parameters[7].Value = patient.IssueDate;
                _parameters[8] = new SqlParameter("@UpdatedBy", SqlDbType.BigInt);
                _parameters[8].Value = patient.UpdatedBy;
                _parameters[9] = new SqlParameter("@DocumentBookIdRef", SqlDbType.BigInt);
                _parameters[9].Value = patient.DocumentBookId;
                _parameters[10] = new SqlParameter("@DocumentTypeIdRef", SqlDbType.BigInt);
                _parameters[10].Value = patient.DocumentTypeId;
                _parameters[11] = new SqlParameter("@TblTeethSectionNotationMappingType", SqlDbType.Structured);
                _parameters[11].Value = patient.TeethSectionNotationMappingDT;
                dataSet= RunProcedure(_storedProcedure, _parameters, true);
                return (dataSet.Tables[0].Rows[0][0].ToString());
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        public DataSet GetDentalAdultDropdownMaster()
        {
            _storedProcedure = "GetDentalAdultDropdownMaster";
            return RunProcedure(_storedProcedure, true);
        }

        public DataSet GetDentalAdultTreatmentMaster(string diagnosis)
        {
            _storedProcedure = "GetDentalAdultTreatmentMaster";
            _parameters = new SqlParameter[1];
            _parameters[0] = new SqlParameter("@Diagnosis", SqlDbType.NVarChar);
            _parameters[0].Value = diagnosis;
            return RunProcedure(_storedProcedure, _parameters, true);
        }

        public DataSet GetDentalAdultTreatmentDetails(long? doctorTreatmentId)
        {
            _storedProcedure = "GetDentalAdultTreatmentDetails";
            _parameters = new SqlParameter[1];
            _parameters[0] = new SqlParameter("@DentalTreatmentId", SqlDbType.BigInt);
            _parameters[0].Value = doctorTreatmentId;
            return RunProcedure(_storedProcedure, _parameters, true);
        }


        public string SaveDentalAdultTreatmentDiagnosis(IDentalTreatment dentalTreatment)
        {
            try
            {
                dataSet = new DataSet();
                _storedProcedure = "SaveDentalAdultTreatmentDiagnosis";
                _parameters = new SqlParameter[6];
                _parameters[0] = new SqlParameter("@DentalAdultMainId", SqlDbType.BigInt);
                _parameters[0].Value = dentalTreatment.DoctorTreatmentsDT;
                _parameters[1] = new SqlParameter("@PatientId", SqlDbType.BigInt);
                _parameters[1].Value = dentalTreatment.DoctorTreatmentIllnessesDT;
                _parameters[2] = new SqlParameter("@ClinicRefId", SqlDbType.BigInt);
                _parameters[2].Value = dentalTreatment.DoctorTreatmentSymptonsDT;
                _parameters[3] = new SqlParameter("@VisitRegisterId", SqlDbType.BigInt);
                _parameters[3].Value = dentalTreatment.DoctorTreatmentPatientProblemsDT;
                _parameters[4] = new SqlParameter("@DoctorTreatmentId", SqlDbType.BigInt);
                _parameters[4].Value = dentalTreatment.DoctorTreatmentId;
                _parameters[5] = new SqlParameter("@DoctorAssignedTo", SqlDbType.BigInt);
                _parameters[5].Value = dentalTreatment.VisitRegisterid;
                dataSet = RunProcedure(_storedProcedure, _parameters, true);
                return (dataSet.Tables[0].Rows[0][0].ToString());
            }
            catch (System.Exception)
            {

                throw;
            }
        }
=======
>>>>>>> 7babb1366b6e380054a362701d197f3771697d9a
    }
}
