using _10SoftDental.Factory.DentalClinic;
using System;
using System.Collections.Generic;
using System.Data;
using _10SoftDental.BAL.Helper;
using _10SoftDental.DAL.Common;
using _10SoftDental.Factory.Common;

namespace _10SoftDental.BAL.Dental
{
    public class PatientAdultMain : IPatientAdultMainScreen, ICommonResponse
    {
        public PatientAdultMain()
        {
            this.commonResponseResult = new CommonResponse();
            this.dataSet = new DataSet();
        }
        public ResponseModel CreateResponse(bool status, string messageCode, string message, object data)
        {
            return this.commonResponseResult.CreateResponse(status, messageCode, message, data);
        }
        private PatientAdultMain patientBAL = null;
        private CommonResponse commonResponseResult;
        private List<PatientMedication> patientMedicationList = null;
        DataSet dataSet = null;
        DataTable dataTable = null;
        private long? dentalAdultMainId;
        private string doctorTreatmentNumber;
        private long visitRegisterId;
        private string visitRegisterNumber;
        private long? doctorTreatmentId;
        private long? doctorAssignedTo;
        private string comments;
        private DateTime? issueDate;
        private long? updatedBy;
        private DateTime? updatedDate;
        private long? patientId;
        private long? clinicId;
        private long? documentBookId;
        private long? documentTypeId;
        private string patientCode;
        private string patientNameEn;
        private string patientNameAr;
        private bool? isAdult;
        private List<TeethSectionNotationMapping> teethSectionNotationMapping;
        private DataTable teethSectionNotationMappingDT;
        private bool? isPatientTreatedPreviously;
        private bool? isPatientHaveMedicalCondition;
        private string detailsHistoryTreatment ;
        private string medicalConditionDetails ;
        private string caseChiefComplaint ;
        private string historyOfIllness ;
        private string dentalHistory ;
        private string medicalHistory ;
        private string socialHistory ;
        private string familyHistory ;
        private string bloodPressure ;
        private string pulseRate ;
        private string respiratoryRate ;
        private bool? isSentForApproval ;
        private string temperature ;
        private string approvedStatus ;
        private long? caseAssignedStudentId ;
        private bool isSentforCaseStudy;
        private long? vRDoctorIdRef;
        private string doctorAssignedEn;
        private string doctorAssignedAr;
        private string caseSheetComments;
        
        private long? patientClinicalExaminationId;



        
        public long? DentalAdultMainId { get => dentalAdultMainId; set => dentalAdultMainId = value; }
        public long VisitRegisterId { get => visitRegisterId; set => visitRegisterId = value; }
        public long? DoctorTreatmentId { get => doctorTreatmentId; set => doctorTreatmentId = value; }
        public long? DoctorAssignedTo { get => doctorAssignedTo; set => doctorAssignedTo = value; }
        public string Comments { get => comments; set => comments = value; }
        public DateTime? IssueDate { get => issueDate; set => issueDate = value; }
        public long? UpdatedBy { get => updatedBy; set => updatedBy = value; }
        public DateTime? UpdatedDate { get => updatedDate; set => updatedDate = value; }
        public long? PatientId { get => patientId; set => patientId = value; }
        public long? ClinicId { get => clinicId; set => clinicId = value; }
        public long? DocumentBookId { get => documentBookId; set => documentBookId = value; }
        public long? DocumentTypeId { get => documentTypeId; set => documentTypeId = value; }
        public List<TeethSectionNotationMapping> TeethSectionNotationMapping { get => teethSectionNotationMapping; set => teethSectionNotationMapping = value; }
        public DataTable TeethSectionNotationMappingDT { get => teethSectionNotationMappingDT; set => teethSectionNotationMappingDT = value; }
        public string VisitRegisterNumber { get => visitRegisterNumber; set => visitRegisterNumber = value; }
        public string DoctorTreatmentNumber { get => doctorTreatmentNumber; set => doctorTreatmentNumber = value; }
        public string PatientCode { get => patientCode; set => patientCode = value; }
        public string PatientNameEn { get => patientNameEn; set => patientNameEn = value; }
        public string PatientNameAr { get => patientNameAr; set => patientNameAr = value; }
        public bool? IsAdult { get => isAdult; set => isAdult = value; }
        public bool? IsPatientTreatedPreviously { get => isPatientTreatedPreviously; set => isPatientTreatedPreviously = value; }
        public bool? IsPatientHaveMedicalCondition { get => isPatientHaveMedicalCondition; set => isPatientHaveMedicalCondition = value; }
        public string DetailsHistoryTreatment { get => detailsHistoryTreatment; set => detailsHistoryTreatment = value; }
        public string MedicalConditionDetails { get => medicalConditionDetails; set => medicalConditionDetails = value; }
        public string CaseChiefComplaint { get => caseChiefComplaint; set => caseChiefComplaint = value; }
        public string HistoryOfIllness { get => historyOfIllness; set => historyOfIllness = value; }
        public string DentalHistory { get => dentalHistory; set => dentalHistory = value; }
        public string MedicalHistory { get => medicalHistory; set => medicalHistory = value; }
        public string SocialHistory { get => socialHistory; set => socialHistory = value; }
        public string FamilyHistory { get => familyHistory; set => familyHistory = value; }
        public string BloodPressure { get => bloodPressure; set => bloodPressure = value; }
        public string PulseRate { get => pulseRate; set => pulseRate = value; }
        public string RespiratoryRate { get => respiratoryRate; set => respiratoryRate = value; }
        public bool? IsSentForApproval { get => isSentForApproval; set => isSentForApproval = value; }
        public string Temperature { get => temperature; set => temperature = value; }
        public string ApprovedStatus { get => approvedStatus; set => approvedStatus = value; }
        public long? CaseAssignedStudentId { get => caseAssignedStudentId; set => caseAssignedStudentId = value; }
        public bool IsSentforCaseStudy { get => isSentforCaseStudy; set => isSentforCaseStudy = value; }
        public long? VRDoctorIdRef { get => vRDoctorIdRef; set => vRDoctorIdRef = value; }
        public string DoctorAssignedEn { get => doctorAssignedEn; set => doctorAssignedEn = value; }
        public string DoctorAssignedAr { get => doctorAssignedAr; set => doctorAssignedAr = value; }
        public long? PatientClinicalExaminationId { get => patientClinicalExaminationId; set => patientClinicalExaminationId = value; }

        public string CaseSheetComments { get => caseSheetComments; set => caseSheetComments = value; }

        private CommonDAL commonDAL = null;

        public ResponseModel SaveDentalAdultMain()
        {
            try
            {
                commonDAL = new CommonDAL();
                this.TeethSectionNotationMappingDT = new ListToDatatable().ToDataTableTeetNotationList(this.TeethSectionNotationMapping);
                dataSet = commonDAL.SaveDentalAdultMain(this);
                return CreateResponse(Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? true : false, Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? "Success" : "Failed", dataSet.Tables[0].Rows[0]["Message"].ToString(), dataSet);
            }
            catch (Exception ex)
            {
                return CreateResponse(false, "Error", ex.InnerException.ToString(), "");
            }

        }

        public ResponseModel SavePatientMedication(List<PatientMedication> patientMedicationList)
        {
            try
            {
                commonDAL = new CommonDAL();
                dataTable = new DataTable();
                dataTable = new ListToDatatable().ToDataTablePatientMedication(patientMedicationList);
                dataSet = commonDAL.SaveDentalAdultMain(this);
                return CreateResponse(Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? true : false, Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? "Success" : "Failed", dataSet.Tables[0].Rows[0]["Message"].ToString(), dataSet);
            }
            catch (Exception ex)
            {
                return CreateResponse(false, "Error", ex.InnerException.ToString(), "");
            }
        }
        public ResponseModel SavePatientHistory()
        {
            try
            {
                commonDAL = new CommonDAL();
                dataSet = commonDAL.Dental_SavePatientHistory(this);
                return CreateResponse(Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? true : false, Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? "Success" : "Failed", dataSet.Tables[0].Rows[0]["Message"].ToString(), dataSet);
            }
            catch (Exception ex)
            {
                return CreateResponse(false, "Error", ex.InnerException.ToString(), "");
            }

        }

        public ResponseModel SavePatientCaseSheet()
        {
            try
            {
                commonDAL = new CommonDAL();
                dataSet = commonDAL.Dental_SavePatientCaseSheet(this);
                return CreateResponse(Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? true : false, Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? "Success" : "Failed", dataSet.Tables[0].Rows[0]["Message"].ToString(), dataSet);
            }
            catch (Exception ex)
            {
                return CreateResponse(false, "Error", ex.InnerException.ToString(), "");
            }
        }

        public ResponseModel SavePatientClinicalExamination(PatientClinicalExamination patientClinical)
        {
            try
            {
                commonDAL = new CommonDAL();
                dataSet = commonDAL.SavePatientClinicalExamination(patientClinical);
                return CreateResponse(Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? true : false, Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? "Success" : "Failed", dataSet.Tables[0].Rows[0]["Message"].ToString(), dataSet);
            }
            catch (Exception ex)
            {
                return CreateResponse(false, "Error", ex.InnerException.ToString(), "");
            }
        }

        public List<PatientClinicalExamination> GetPatientClinicalExamination(long dentalAdultMainId, long? ClinicalExaminationId)
        {
            List<PatientClinicalExamination> patientClinical = new List<PatientClinicalExamination>();
            try
            {
                commonDAL = new CommonDAL();
               
                dataSet = commonDAL.GetPatientClinicalExamination(dentalAdultMainId, ClinicalExaminationId);
                if(dataSet.Tables.Count>0)
                patientClinical = new Helper.DatatableToList().PatientClinicalExamincationList(dataSet.Tables[0]);
                return patientClinical;
            }
            catch (Exception ex)
            {
                return patientClinical;
            }
        }
        public ResponseModel SendforApproval(long DentalAdultMainId,bool IsSentForApproval)
        {
            try
            {
                commonDAL = new CommonDAL();
                dataSet = commonDAL.Dental_SendforApproval(DentalAdultMainId, IsSentForApproval);
                return CreateResponse(Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? true : false, Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? "Success" : "Failed", dataSet.Tables[0].Rows[0]["Message"].ToString(), dataSet);
            }
            catch (Exception ex)
            {
                return CreateResponse(false, "Error", ex.InnerException.ToString(), "");
            }
        }

        public ResponseModel SendforCaseStudy()
        {
            try
            {
                commonDAL = new CommonDAL();
                dataSet = commonDAL.Dental_SendforCaseStudy(this);
                return CreateResponse(Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? true : false, Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? "Success" : "Failed", dataSet.Tables[0].Rows[0]["Message"].ToString(), dataSet);
            }
            catch (Exception ex)
            {
                return CreateResponse(false, "Error", ex.InnerException.ToString(), "");
            }
        }

        public ResponseModel ApproveCaseStudy()
        {
            try
            {
                commonDAL = new CommonDAL();
                dataSet = commonDAL.Dental_ApproveCaseStudy(this);
                return CreateResponse(Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? true : false, Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? "Success" : "Failed", dataSet.Tables[0].Rows[0]["Message"].ToString(), dataSet);
            }
            catch (Exception ex)
            {
                return CreateResponse(false, "Error", ex.InnerException.ToString(), "");
            }
        }
        public PatientAdultMain Dental_GetAdultMainScreeningData(int? clinicId, long patientId, string Mobile, long? doctorId, long? DoctorTreatmentId, long? dentalMainId)
        {
            patientBAL = new PatientAdultMain();
            dataSet = new DataSet();
            dataSet = new DAL.Master.DentalMaster().Dental_GetAdultMainScreeningData(clinicId, patientId, Mobile, doctorId, DoctorTreatmentId, dentalMainId);
            if (dentalMainId > 0)
            {
                patientBAL.DentalAdultMainId = Convert.ToInt64(dataSet.Tables[0].Rows[0]["DentalAdultMainId"]);
                patientBAL.PatientId = Convert.ToInt64(dataSet.Tables[0].Rows[0]["PatientIdRef"]);
                patientBAL.ClinicId = Convert.ToInt64(dataSet.Tables[0].Rows[0]["ClinicIdRef"]);
                patientBAL.visitRegisterId = Convert.ToInt64(dataSet.Tables[0].Rows[0]["VisitRegisterId"]);
                patientBAL.VisitRegisterNumber = dataSet.Tables[0].Rows[0]["VRNo"].ToString();
                patientBAL.DoctorTreatmentId = Convert.ToInt64(dataSet.Tables[0].Rows[0]["DoctorTreatmentId"]);
                patientBAL.DoctorTreatmentNumber = dataSet.Tables[0].Rows[0]["DTNo"].ToString();
                patientBAL.PatientCode = dataSet.Tables[0].Rows[0]["PatientCode"].ToString();
                patientBAL.PatientNameEn = dataSet.Tables[0].Rows[0]["ForeignName"].ToString();
                patientBAL.PatientNameAr = dataSet.Tables[0].Rows[0]["LocalName"].ToString();
                patientBAL.DocumentTypeId = Convert.ToInt64(dataSet.Tables[0].Rows[0]["DocumentTypeId"]);
                patientBAL.IssueDate = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["VRIssueDate"].ToString());
                patientBAL.DoctorAssignedTo = Convert.ToInt64(dataSet.Tables[0].Rows[0]["DoctorAssignedTo"]);
                patientBAL.Comments = dataSet.Tables[0].Rows[0]["Comments"].ToString();
                patientBAL.IsAdult = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["IsAdult"]);
                patientBAL.IsPatientHaveMedicalCondition = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["IsPatientHaveMedicalCondition"]);
                patientBAL.MedicalConditionDetails = dataSet.Tables[0].Rows[0]["MedicalConditionDetails"].ToString();
                patientBAL.IsPatientTreatedPreviously = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["IsPatientTreatedPreviously"]);
                patientBAL.DetailsHistoryTreatment = dataSet.Tables[0].Rows[0]["DetailsHistoryTreatment"].ToString();
                patientBAL.CaseChiefComplaint = dataSet.Tables[0].Rows[0]["CaseChiefComplaint"].ToString();
                patientBAL.HistoryOfIllness = dataSet.Tables[0].Rows[0]["HistoryOfIllness"].ToString();
                patientBAL.DentalHistory = dataSet.Tables[0].Rows[0]["DentalHistory"].ToString();
                patientBAL.MedicalHistory = dataSet.Tables[0].Rows[0]["MedicalHistory"].ToString();
                patientBAL.SocialHistory = dataSet.Tables[0].Rows[0]["SocialHistory"].ToString();
                patientBAL.FamilyHistory = dataSet.Tables[0].Rows[0]["FamilyHistory"].ToString();
                patientBAL.BloodPressure = dataSet.Tables[0].Rows[0]["BloodPressure"].ToString();
                patientBAL.PulseRate = dataSet.Tables[0].Rows[0]["PulseRate"].ToString();
                patientBAL.RespiratoryRate = dataSet.Tables[0].Rows[0]["RespiratoryRate"].ToString();
                patientBAL.Temperature = dataSet.Tables[0].Rows[0]["Temperature"].ToString();
                patientBAL.DoctorAssignedEn = dataSet.Tables[0].Rows[0]["DoctorAssignedEn"].ToString();
                patientBAL.DoctorAssignedAr = dataSet.Tables[0].Rows[0]["DoctorAssignedAr"].ToString();
                patientBAL.IsSentForApproval =Convert.ToBoolean(dataSet.Tables[0].Rows[0]["IsSentForApproval"]);
                patientBAL.ApprovedStatus = dataSet.Tables[0].Rows[0]["ApprovedStatus"].ToString();
                patientBAL.CaseAssignedStudentId = Convert.ToInt64(dataSet.Tables[0].Rows[0]["CaseAssignedStudentId"]);
                patientBAL.IsSentforCaseStudy = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["IsSentforCaseStudy"]);
                patientBAL.VRDoctorIdRef = Convert.ToInt64(dataSet.Tables[0].Rows[0]["VRDoctorIdRef"]);
                patientBAL.CaseSheetComments = Convert.ToString(dataSet.Tables[0].Rows[0]["CaseSheetComments"]);
                patientBAL.PatientClinicalExaminationId= dataSet.Tables[0].Rows[0]["PatientClinicalExaminationId"].ToString()=="0"?(long?)null:Convert.ToInt64(dataSet.Tables[0].Rows[0]["PatientClinicalExaminationId"]);
                if (dataSet.Tables.Count > 1)
                {
                    patientBAL.TeethSectionNotationMapping = new Helper.DatatableToList().TeethList(dataSet.Tables[1]);
                }
            }
            return patientBAL;
        }

        public List<PatientMedication> Dental_PatientMedication(long dentalAdultMainId)
        {
            patientMedicationList = new List<PatientMedication>();
            dataSet = new DataSet();
            dataSet = new DAL.Common.CommonDAL().Dental_PatientMedication(dentalAdultMainId);
            if (dataSet.Tables.Count > 0)
            {
                patientMedicationList = new Helper.DatatableToList().PatientMedicationList(dataSet.Tables[0]);
            }
            return patientMedicationList;
        }

        public DataSet Dental_GetPatienDropdownData()
        {
            dataSet = new DataSet();
            dataSet = new DAL.Common.CommonDAL().Dental_GetPatienDropdownData();
            return dataSet;
        }
    }


    public class TeethSectionNotationMapping : ITeethSectionNotationMapping
    {
        private int? teethSectionNotationMappingId;
        private int? dentalTeethMasterId;
        private int? dentalTeethSectionMasterId;
        private int? dentalNotationId;
        private long? patientId;
        private long? doctorId;
        private long? updatedBy;
        private long? dentalAdultMainId;
        private long? visitRegisterId;
        private string color;

        public int? TeethSectionNotationMappingId { get => teethSectionNotationMappingId; set => teethSectionNotationMappingId = value; }
        public int? DentalTeethMasterId { get => dentalTeethMasterId; set => dentalTeethMasterId = value; }
        public int? DentalTeethSectionMasterId { get => dentalTeethSectionMasterId; set => dentalTeethSectionMasterId = value; }
        public int? DentalNotationId { get => dentalNotationId; set => dentalNotationId = value; }
        public long? PatientId { get => patientId; set => patientId = value; }
        public long? DoctorId { get => doctorId; set => doctorId = value; }
        public long? UpdatedBy { get => updatedBy; set => updatedBy = value; }
        public long? DentalAdultMainId { get => dentalAdultMainId; set => dentalAdultMainId = value; }
        public long? VisitRegisterId { get => visitRegisterId; set => visitRegisterId = value; }
        public string Color { get => color; set => color = value; }
    }
}