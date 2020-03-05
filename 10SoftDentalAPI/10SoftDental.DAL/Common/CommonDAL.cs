﻿using _10SoftDental.Factory.DentalClinic;
using System;
using System.Data;
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
        public DataSet GetAllVisitList(int? userId)
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
            _parameters[4].Value = userId;
            return RunProcedure(_storedProcedure, _parameters, true);
        }      
        public DataSet GetAllVisitHistoyList(bool? isLocal,int? clinicId,int? doctorId,int? loginUserId,int? visitId,int? patientId)
        {
            _storedProcedure = "Dental_GetVisitHistory";
            _parameters = new SqlParameter[6];
            _parameters[0] = new SqlParameter("@IsLocal", SqlDbType.Bit);
            _parameters[0].Value = isLocal;
            _parameters[1] = new SqlParameter("@ClinicIdRef", SqlDbType.Int);
            _parameters[1].Value = clinicId;
            _parameters[2] = new SqlParameter("@DoctorIdRef", SqlDbType.BigInt);
            _parameters[2].Value = doctorId;
            _parameters[3] = new SqlParameter("@UserID", SqlDbType.Int);
            _parameters[3].Value = loginUserId;
            _parameters[4] = new SqlParameter("@VisitID", SqlDbType.BigInt);
            _parameters[4].Value = visitId;
            _parameters[5] = new SqlParameter("@PatientID", SqlDbType.BigInt);
            _parameters[5].Value = patientId;
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


        public DataSet SaveDentalAdultMain(IPatientAdultMainScreen patient)
        {
            try
            {
                dataSet = new DataSet();
                _storedProcedure = "SaveDentalAdultMain";
                _parameters = new SqlParameter[13];
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
                _parameters[11] = new SqlParameter("@IsAdult", SqlDbType.Bit);
                _parameters[11].Value = patient.IsAdult;
                _parameters[12] = new SqlParameter("@TblTeethSectionNotationMappingType", SqlDbType.Structured);
                _parameters[12].Value = patient.TeethSectionNotationMappingDT;
                dataSet= RunProcedure(_storedProcedure, _parameters, true);
                return dataSet;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public DataSet SavePatientMedication(DataTable patientMedicationDt)
        {
            _storedProcedure = "Dental_SavePatientMedication";
            _parameters = new SqlParameter[1];
            _parameters[0] = new SqlParameter("@Diagnosis", SqlDbType.Structured);
            _parameters[0].Value = patientMedicationDt;
            return RunProcedure(_storedProcedure, _parameters, true);
        }

        public DataSet GetDentalAdultDropdownMaster()
        {
            _storedProcedure = "GetDentalAdultDropdownMaster";
            return RunProcedure(_storedProcedure, true);
        }
        public DataSet Dental_GetPatienDropdownData()
        {
            _storedProcedure = "Dental_GetPatienDropdownData";
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
                _parameters[0] = new SqlParameter("@DoctorTreatmentDiagnosisTypeTbl", SqlDbType.Structured);
                _parameters[0].Value = dentalTreatment.DoctorTreatmentsDT;
                _parameters[1] = new SqlParameter("@DoctorTreatmentIllnessTypeTbl", SqlDbType.Structured);
                _parameters[1].Value = dentalTreatment.DoctorTreatmentIllnessesDT;
                _parameters[2] = new SqlParameter("@DoctorTreatmentSymptomTypeTbl", SqlDbType.Structured);
                _parameters[2].Value = dentalTreatment.DoctorTreatmentSymptonsDT;
                _parameters[3] = new SqlParameter("@DoctorTreatmentPatientProblemTypeTbl", SqlDbType.Structured);
                _parameters[3].Value = dentalTreatment.DoctorTreatmentPatientProblemsDT;
                _parameters[4] = new SqlParameter("@DoctorTreatmentId", SqlDbType.BigInt);
                _parameters[4].Value = dentalTreatment.DoctorTreatmentId;
                _parameters[5] = new SqlParameter("@VisitRegisterId", SqlDbType.BigInt);
                _parameters[5].Value = dentalTreatment.VisitRegisterid;
                dataSet = RunProcedure(_storedProcedure, _parameters, true);
                return (dataSet.Tables[0].Rows[0][0].ToString());
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public DataSet GetAdultMainScreeningData(int patientId, int? clinicId, string patientMobile, int? doctorTreatmentId, int? dentalMainId)
        {
            _storedProcedure = "GetAdultMainScreeningData";
            _parameters = new SqlParameter[5];
            _parameters[0] = new SqlParameter("@PatientId", SqlDbType.Int);
            _parameters[0].Value = patientId;
            _parameters[1] = new SqlParameter("@ClinicIdRef", SqlDbType.Int);
            _parameters[1].Value = clinicId;
            _parameters[2] = new SqlParameter("@PatientMobile", SqlDbType.NVarChar);
            _parameters[2].Value = patientMobile;
            _parameters[3] = new SqlParameter("@DoctorTreatmentId", SqlDbType.BigInt);
            _parameters[3].Value = doctorTreatmentId;
            _parameters[4] = new SqlParameter("@DentalMainId", SqlDbType.BigInt);
            _parameters[4].Value = dentalMainId;
            return RunProcedure(_storedProcedure, _parameters, true);
        }


        public DataSet Dental_SavePatientHistory(IPatientAdultMainScreen patientAdultMain)
        {
            dataSet = new DataSet();
            _storedProcedure = "Dental_SavePatientHistory";
            _parameters = new SqlParameter[5];
            _parameters[0] = new SqlParameter("@DentalAdultMainId", SqlDbType.BigInt);
            _parameters[0].Value = patientAdultMain.DentalAdultMainId;
            _parameters[1] = new SqlParameter("@IsPatientTreatedPreviously", SqlDbType.Bit);
            _parameters[1].Value = patientAdultMain.IsPatientTreatedPreviously;
            _parameters[2] = new SqlParameter("@DetailsHistoryTreatment", SqlDbType.NVarChar);
            _parameters[2].Value = patientAdultMain.DetailsHistoryTreatment;
            _parameters[3] = new SqlParameter("@IsPatientHaveMedicalCondition", SqlDbType.Bit);
            _parameters[3].Value = patientAdultMain.IsPatientHaveMedicalCondition;
            _parameters[4] = new SqlParameter("@MedicalConditionDetails", SqlDbType.NVarChar);
            _parameters[4].Value = patientAdultMain.MedicalConditionDetails;
            dataSet = RunProcedure(_storedProcedure, _parameters, true);
            return dataSet;
        }

        public DataSet Dental_PatientMedication(long dentalAdultMainId)
        {
            dataSet = new DataSet();
            _storedProcedure = "Dental_PatientMedication";
            _parameters = new SqlParameter[1];
            _parameters[0] = new SqlParameter("@DentalAdultMainId", SqlDbType.BigInt);
            _parameters[0].Value = dentalAdultMainId;
            dataSet = RunProcedure(_storedProcedure, _parameters, true);
            return dataSet;
        }

        public DataSet Dental_SendforApproval(long dentalAdultMainId,bool IsSentforApproval)
        {
             dataSet = new DataSet();
            _storedProcedure = "Dental_SendforApproval";
            _parameters = new SqlParameter[2];
            _parameters[0] = new SqlParameter("@DentalAdultMainId", SqlDbType.BigInt);
            _parameters[0].Value = dentalAdultMainId;
            _parameters[1] = new SqlParameter("@Status", SqlDbType.Bit);
            _parameters[1].Value = IsSentforApproval;
            dataSet = RunProcedure(_storedProcedure, _parameters, true);
            return dataSet;
        }
        public DataSet Dental_SendforCaseStudy(IPatientAdultMainScreen patientAdultMainScreen)
        {
            dataSet = new DataSet();
            _storedProcedure = "Dental_SendforCaseStudy";
            _parameters = new SqlParameter[3];
            _parameters[0] = new SqlParameter("@DentalAdultMainId", SqlDbType.BigInt);
            _parameters[0].Value = Convert.ToInt64(patientAdultMainScreen.DentalAdultMainId);
            _parameters[1] = new SqlParameter("@Status", SqlDbType.Bit);
            _parameters[1].Value = Convert.ToBoolean(patientAdultMainScreen.IsSentforCaseStudy);
            _parameters[2] = new SqlParameter("@CaseAssignedStudentId", SqlDbType.BigInt);
            _parameters[2].Value = Convert.ToInt64(patientAdultMainScreen.CaseAssignedStudentId);
            dataSet = RunProcedure(_storedProcedure, _parameters, true);
            return dataSet;
        }

        public DataSet Dental_ApproveCaseStudy(IPatientAdultMainScreen patientAdultMainScreen)
        {
            dataSet = new DataSet();
            _storedProcedure = "Dental_ApproveCaseStudy";
            _parameters = new SqlParameter[3];
            _parameters[0] = new SqlParameter("@DentalAdultMainId", SqlDbType.BigInt);
            _parameters[0].Value = Convert.ToInt64(patientAdultMainScreen.DentalAdultMainId);
            _parameters[1] = new SqlParameter("@ApprovedStatus", SqlDbType.NVarChar);
            _parameters[1].Value = patientAdultMainScreen.ApprovedStatus;
            _parameters[2] = new SqlParameter("@CaseSheetComments", SqlDbType.NVarChar);
            _parameters[2].Value = patientAdultMainScreen.CaseSheetComments;
            dataSet = RunProcedure(_storedProcedure, _parameters, true);
            return dataSet;
        }


        public DataSet Dental_SavePatientCaseSheet(IPatientAdultMainScreen patientAdultMain)
        {
            dataSet = new DataSet();
            _storedProcedure = "Dental_SavePatientCaseSheet";
            _parameters = new SqlParameter[11];
            _parameters[0] = new SqlParameter("@DentalAdultMainId", SqlDbType.BigInt);
            _parameters[0].Value = patientAdultMain.DentalAdultMainId;
            _parameters[1] = new SqlParameter("@Temperature", SqlDbType.NVarChar);
            _parameters[1].Value = patientAdultMain.Temperature;
            _parameters[2] = new SqlParameter("@RespiratoryRate", SqlDbType.NVarChar);
            _parameters[2].Value = patientAdultMain.RespiratoryRate;
            _parameters[3] = new SqlParameter("@PulseRate", SqlDbType.NVarChar);
            _parameters[3].Value = patientAdultMain.PulseRate;
            _parameters[4] = new SqlParameter("@FamilyHistory", SqlDbType.NVarChar);
            _parameters[4].Value = patientAdultMain.FamilyHistory;
            _parameters[5] = new SqlParameter("@SocialHistory", SqlDbType.NVarChar);
            _parameters[5].Value = patientAdultMain.SocialHistory;
            _parameters[6] = new SqlParameter("@MedicalHistory", SqlDbType.NVarChar);
            _parameters[6].Value = patientAdultMain.MedicalHistory;
            _parameters[7] = new SqlParameter("@DentalHistory", SqlDbType.NVarChar);
            _parameters[7].Value = patientAdultMain.DentalHistory;
            _parameters[8] = new SqlParameter("@HistoryOfIllness", SqlDbType.NVarChar);
            _parameters[8].Value = patientAdultMain.HistoryOfIllness;
            _parameters[9] = new SqlParameter("@CaseChiefComplaint", SqlDbType.NVarChar);
            _parameters[9].Value = patientAdultMain.CaseChiefComplaint;
            _parameters[10] = new SqlParameter("@BloodPressure", SqlDbType.NVarChar);
            _parameters[10].Value = patientAdultMain.BloodPressure;
            dataSet = RunProcedure(_storedProcedure, _parameters, true);
            return dataSet;
        }


        public DataSet Dental_SavePatientLabReport(IPatientAdultMainScreen patientAdultMainScreen)
        {
            dataSet = new DataSet();
            _storedProcedure = "Dental_SavePatientLabReport";
            _parameters = new SqlParameter[7];
            _parameters[0] = new SqlParameter("@DentalLabReportId", SqlDbType.BigInt);
            _parameters[0].Value = patientAdultMainScreen.DentalAdultMainId;
            _parameters[1] = new SqlParameter("@DentalAdultMainId", SqlDbType.BigInt);
            _parameters[1].Value = patientAdultMainScreen.ApprovedStatus;
            _parameters[2] = new SqlParameter("@LabReportRequestId", SqlDbType.VarChar);
            _parameters[2].Value = patientAdultMainScreen.ApprovedStatus;
            _parameters[3] = new SqlParameter("@ReportTypeId", SqlDbType.Int);
            _parameters[3].Value = patientAdultMainScreen.ApprovedStatus;
            _parameters[4] = new SqlParameter("@PreferredLabId", SqlDbType.Int);
            _parameters[4].Value = patientAdultMainScreen.ApprovedStatus;
            _parameters[5] = new SqlParameter("@Comments", SqlDbType.NVarChar);
            _parameters[5].Value = patientAdultMainScreen.ApprovedStatus;
            _parameters[6] = new SqlParameter("@UpdatedBy", SqlDbType.BigInt);
            _parameters[6].Value = patientAdultMainScreen.ApprovedStatus;
            dataSet = RunProcedure(_storedProcedure, _parameters, true);
            return dataSet;
        }


        public DataSet GetPatientClinicalExamination(long dentalAdultMainId, long? ClinicalExaminationId)
        {
            dataSet = new DataSet();
            _storedProcedure = "Dental_GetPatientClinicalExamination";
            _parameters = new SqlParameter[2];
            _parameters[0] = new SqlParameter("@DentalAdultMainId", SqlDbType.BigInt);
            _parameters[0].Value = dentalAdultMainId;
            _parameters[1] = new SqlParameter("@PatientClinicalExaminationId", SqlDbType.BigInt);
            _parameters[1].Value = ClinicalExaminationId;
            dataSet = RunProcedure(_storedProcedure, _parameters, true);
            return dataSet;
        }

        public DataSet SavePatientClinicalExamination(IPatientClinicalExamination patientClinical)
        {
            dataSet = new DataSet();
            _storedProcedure = "Dental_SavePatientClinicalExamination";
            _parameters = new SqlParameter[19];
            _parameters[0] = new SqlParameter("@PatientClinicalExaminationId", SqlDbType.BigInt);
            _parameters[0].Value = patientClinical.PatientClinicalExaminationId;
            _parameters[1] = new SqlParameter("@DentalAdultMainId", SqlDbType.BigInt);
            _parameters[1].Value = patientClinical.DentalAdultMainId;
            _parameters[2] = new SqlParameter("@Lips", SqlDbType.Bit);
            _parameters[2].Value = patientClinical.Lips;
            _parameters[3] = new SqlParameter("@Cheek", SqlDbType.Bit);
            _parameters[3].Value = patientClinical.Cheek;
            _parameters[4] = new SqlParameter("@Tongue", SqlDbType.Bit);
            _parameters[4].Value = patientClinical.Tongue;
            _parameters[5] = new SqlParameter("@Palat", SqlDbType.Bit);
            _parameters[5].Value = patientClinical.Palat;
            _parameters[6] = new SqlParameter("@LymphNodes", SqlDbType.Bit);
            _parameters[6].Value = patientClinical.LymphNodes;
            _parameters[7] = new SqlParameter("@OralHygiene_Good", SqlDbType.Bit);
            _parameters[7].Value = patientClinical.OralHygiene_Good;
            _parameters[8] = new SqlParameter("@OralHygiene_Fair", SqlDbType.Bit);
            _parameters[8].Value = patientClinical.OralHygiene_Fair;
            _parameters[9] = new SqlParameter("@OralHygiene_Poor", SqlDbType.Bit);
            _parameters[9].Value = patientClinical.OralHygiene_Poor;
            _parameters[10] = new SqlParameter("@OralHygiene_Plaque", SqlDbType.Bit);
            _parameters[10].Value = patientClinical.OralHygiene_Plaque;
            _parameters[11] = new SqlParameter("@OralHygiene_Stain", SqlDbType.Bit);
            _parameters[11].Value = patientClinical.OralHygiene_Stain;
            _parameters[12] = new SqlParameter("@Gingiva_Normal", SqlDbType.Bit);
            _parameters[12].Value = patientClinical.Gingiva_Normal;
            _parameters[13] = new SqlParameter("@Gingiva_Inflamed", SqlDbType.Bit);
            _parameters[13].Value = patientClinical.Gingiva_Inflamed;
            _parameters[14] = new SqlParameter("@Gingiva_HyperPlastic", SqlDbType.Bit);
            _parameters[14].Value = patientClinical.Gingiva_HyperPlastic;
            _parameters[15] = new SqlParameter("@Profile_ClassI", SqlDbType.Bit);
            _parameters[15].Value = patientClinical.Profile_ClassI;
            _parameters[16] = new SqlParameter("@Profile_ClassII", SqlDbType.Bit);
            _parameters[16].Value = patientClinical.Profile_ClassII;
            _parameters[17] = new SqlParameter("@Profile_ClassIII", SqlDbType.Bit);
            _parameters[17].Value = patientClinical.Profile_ClassIII;
            _parameters[18] = new SqlParameter("@UpdatedBY", SqlDbType.BigInt);
            _parameters[18].Value = patientClinical.UpdatedBY;
            dataSet = RunProcedure(_storedProcedure, _parameters, true);
            return dataSet;
        }
        public DataSet GetResources(int? resourceId)
        {
            _storedProcedure = "Dental_GetResources";
            _parameters = new SqlParameter[1];
            _parameters[0] = new SqlParameter("@ResourcesId", SqlDbType.Int);
            _parameters[0].Value = resourceId;
            return RunProcedure(_storedProcedure, _parameters, true);
        }
    }
}
