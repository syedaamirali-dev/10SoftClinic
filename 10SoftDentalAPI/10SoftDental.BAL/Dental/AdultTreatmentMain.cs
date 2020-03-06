using System.Collections.Generic;
using System.Data;
using _10SoftDental.BAL.Helper;
using _10SoftDental.DAL.Common;
using _10SoftDental.Factory.DentalClinic;
using _10SoftDental.Factory.Models;

namespace _10SoftDental.BAL.Dental
{
    public class AdultMainTreatment : IDentalTreatment
    {
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
        private CommonDAL commonDAL = null;

        public void SaveDentalAdultTreatmentDiagnosis()
        {
            commonDAL = new CommonDAL();
            //this.DoctorTreatmentsDT = new ListToDatatable().ToDataTableChiefCompliant(this.doctorTreatmentsList);
            this.DoctorTreatmentIllnessesDT = new ListToDatatable().ToDataTableIllness(this.doctorTreatmentIllnessesList);
            this.DoctorTreatmentSymptonsDT = new ListToDatatable().ToDataTableSympton(this.doctorTreatmentSymptonsList);
            this.DoctorTreatmentPatientProblemsDT = new ListToDatatable().ToDataTablePatientProblem(this.doctorTreatmentPatientProblemsList);
            commonDAL.SaveDentalAdultTreatmentDiagnosis(this);
        }

        public void SaveDentalTreatmentPlanning()
        {
            commonDAL = new CommonDAL();
            this.DoctorTreatmentsDT = new ListToDatatable().ToDataTableChiefCompliant(this.doctorTreatmentsList);
            commonDAL.SaveDentalTreatmentPlanning(this);
        }
        public DataSet GetDentalAdultTreatmentDetails(long? doctorTreatmentId)
        {
            commonDAL = new CommonDAL();
            return commonDAL.GetDentalAdultTreatmentDetails(doctorTreatmentId);
        }
        public DataSet GetDentalAdultTreatmentMaster(string diagnosis)
        {
            commonDAL = new CommonDAL();
            return commonDAL.GetDentalAdultTreatmentMaster(diagnosis);
        }
    }
}