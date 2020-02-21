﻿using _10SoftDental.Factory.DentalClinic;
using System;
using System.Collections.Generic;
using System.Data;
using _10SoftDental.BAL.Helper;
using _10SoftDental.DAL.Common;

namespace _10SoftDental.BAL.Dental
{
    public class PatientAdultMain : IPatientAdultMainScreen
    {
        private PatientAdultMain patientBAL = null;
        DataSet dataSet = null;
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

        private CommonDAL commonDAL = null;

        public string SaveDentalAdultMain()
        {
            commonDAL = new CommonDAL();
            this.TeethSectionNotationMappingDT = new ListToDatatable().ToDataTableTeetNotationList(this.TeethSectionNotationMapping);
            return commonDAL.SaveDentalAdultMain(this);
        }

        public PatientAdultMain Dental_GetAdultMainScreeningData(int? clinicId, long patientId, string Mobile, long? doctorId, long? DoctorTreatmentId, long? dentalMainId)
        {
            patientBAL = new PatientAdultMain();
            dataSet = new DataSet();
            dataSet = new DAL.Master.DentalMaster().Dental_GetAdultMainScreeningData(clinicId, patientId, Mobile, doctorId, DoctorTreatmentId, dentalMainId);
            if(dentalMainId>0)
            { 
                patientBAL.visitRegisterId = Convert.ToInt64(dataSet.Tables[0].Rows[0]["VisitRegisterId"]);
                patientBAL.VisitRegisterNumber= dataSet.Tables[0].Rows[0]["VRNo"].ToString();
                patientBAL.DoctorTreatmentId = Convert.ToInt64(dataSet.Tables[0].Rows[0]["DoctorTreatmentId"]);
                patientBAL.DoctorTreatmentNumber = dataSet.Tables[0].Rows[0]["DTNo"].ToString();
                patientBAL.PatientCode = dataSet.Tables[0].Rows[0]["PatientCode"].ToString();
                patientBAL.PatientNameEn = dataSet.Tables[0].Rows[0]["ForeignName"].ToString();
                patientBAL.PatientNameAr = dataSet.Tables[0].Rows[0]["LocalName"].ToString();
                patientBAL.DocumentTypeId = Convert.ToInt64(dataSet.Tables[0].Rows[0]["DocumentTypeId"]);
                patientBAL.IssueDate =Convert.ToDateTime(dataSet.Tables[0].Rows[0]["VRIssueDate"].ToString());
                patientBAL.DoctorAssignedTo = Convert.ToInt64(dataSet.Tables[0].Rows[0]["DoctorAssignedTo"]);
                patientBAL.Comments =dataSet.Tables[0].Rows[0]["Comments"].ToString();
                patientBAL.TeethSectionNotationMapping = new Helper.DatatableToList().TeethList(dataSet.Tables[1]);
                patientBAL.IsAdult = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["IsAdult"]);
            }
            return patientBAL;
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