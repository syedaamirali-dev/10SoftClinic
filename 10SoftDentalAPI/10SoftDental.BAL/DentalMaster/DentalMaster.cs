using System;
using System.Data;
using _10SoftDental.Factory.DentalMaster;
namespace _10SoftDental.BAL.DentalMaster
{
    public class DentalMaster:IDentalMaster
    {
        private int? dentalNotationId;
        private bool patientType;
        private string iconNameEn;
        private string inconNameAr;
        private string descriptionEn;
        private string descriptionAr;
        private string imageURL;
        private bool isActive;
        private int? createdBy;
        private int langId;
        public int? DentalNotationId { get => dentalNotationId; set => dentalNotationId = value; }
        public bool PatientType { get => patientType; set => patientType = value; }
        public string IconNameEn { get => iconNameEn; set => iconNameEn = value; }
        public string InconNameAr { get => inconNameAr; set => inconNameAr = value; }
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

        public DataSet GetDentalChartNotations(int? dentalNotationId, int langId)
        {
            return new DAL.Master.DentalMaster().GetDentalChartNotations(dentalNotationId, langId);
        }
    }
}
