using _10SoftDental.DAL.Common;
using _10SoftDental.Factory.Common;
using _10SoftDental.Factory.DentalClinic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SoftDental.BAL.Dental
{
    public class EquipmentMaterial: IEquipmentMaterial
    {

        public EquipmentMaterial()
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
        CommonDAL commonDAL =null;
        long? equipmentMaterialId;
        long? doctorStudentId;
        int? year;
        DateTime? checkInDate;
        DateTime? checkOutDate;
        bool? session;

        string comments;
        long? approvedBy;

        DateTime? approvedDate;

        bool? isApproved;
        string jsonObjectData;
        string requestType;

        public long? EquipmentMaterialId { get => equipmentMaterialId; set => equipmentMaterialId = value; }
        public long? DoctorStudentId { get => doctorStudentId; set => doctorStudentId = value; }
        public int? Year { get => year; set => year = value; }
        public DateTime? CheckInDate { get => checkInDate; set => checkInDate = value; }
        public DateTime? CheckOutDate { get => checkOutDate; set => checkOutDate = value; }
        public bool? Session { get => session; set => session = value; }
        public string Comments { get => comments; set => comments = value; }
        public long? ApprovedBy { get => approvedBy; set => approvedBy = value; }
        public DateTime? ApprovedDate { get => approvedDate; set => approvedDate = value; }
        public bool? IsApproved { get => isApproved; set => isApproved = value; }
        public string JsonObjectData { get => jsonObjectData; set => jsonObjectData = value; }
        public string RequestType { get => requestType; set => requestType = value; }


        public ResponseModel SaveEquipmentMaterial()
        {
            try
            {
                commonDAL = new CommonDAL();
                dataSet = commonDAL.SaveEquipmentMaterial(this);
                return CreateResponse(Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? true : false, Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? "Success" : "Failed", dataSet.Tables[0].Rows[0]["Message"].ToString(), dataSet);
            }
            catch (Exception ex)
            {
                return CreateResponse(false, "Error", ex.InnerException.ToString(), "");
            }
        }

        public DataSet GetEquipmentMaterial(long? equipmentMaterialId, long? doctorStudentId)
        {
            dataSet = new DataSet();
            dataSet = new DAL.Common.CommonDAL().GetEquipmentMaterial(equipmentMaterialId, doctorStudentId);
            return dataSet;
        }

    }
}
