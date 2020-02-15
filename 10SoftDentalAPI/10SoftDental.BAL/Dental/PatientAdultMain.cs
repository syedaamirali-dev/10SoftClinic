using _10SoftDental.Factory.DentalClinic;
using System;
using System.Collections.Generic;
using System.Data;
using _10SoftDental.Factory.Helper;
using _10SoftDental.DAL.Common;

namespace _10SoftDental.BAL.Dental
{
    public class PatientAdultMain:IPatientAdultMainScreen
    {
        private long? dentalAdultMainId;
        private long visitRegisterId;
        private long? doctorTreatmentId;
        private long? doctorAssignedTo;
        private string comments;
        private DateTime issueDate;
        private long? updatedBy;
        private DateTime updatedDate;
        private long? patientId;
        private long? clinicId;
        private long? documentBookId;
        private long? documentTypeId;
        private List<ITeethSectionNotationMapping> iTeethSectionNotationMapping;
        private DataTable teethSectionNotationMappingDT;

        public long? DentalAdultMainId { get => dentalAdultMainId; set => dentalAdultMainId = value; }
        public long VisitRegisterId { get => visitRegisterId; set => visitRegisterId = value; }
        public long? DoctorTreatmentId { get => doctorTreatmentId; set => doctorTreatmentId = value; }
        public long? DoctorAssignedTo { get => doctorAssignedTo; set => doctorAssignedTo = value; }
        public string Comments { get => comments; set => comments = value; }
        public DateTime IssueDate { get => issueDate; set => issueDate = value; }
        public long? UpdatedBy { get => updatedBy; set => updatedBy = value; }
        public DateTime UpdatedDate { get => updatedDate; set => updatedDate = value; }
        public long? PatientId { get => patientId; set => patientId = value; }
        public long? ClinicId { get => clinicId; set => clinicId = value; }
        public long? DocumentBookId { get => documentBookId; set => documentBookId = value; }
        public long? DocumentTypeId { get => documentTypeId; set => documentTypeId = value; }
        public List<ITeethSectionNotationMapping> ITeethSectionNotationMapping { get => iTeethSectionNotationMapping; set => iTeethSectionNotationMapping = value; }
        public DataTable TeethSectionNotationMappingDT { get => teethSectionNotationMappingDT; set => teethSectionNotationMappingDT = value; }

        private CommonDAL commonDAL = null;

        public void SaveDentalAdultMain()
        {
            commonDAL = new CommonDAL();
            this.TeethSectionNotationMappingDT = new ListToDatatable().ToDataTableTeetNotationList(this.ITeethSectionNotationMapping);
            commonDAL.SaveDentalAdultMain(this);
        }
    }
}
