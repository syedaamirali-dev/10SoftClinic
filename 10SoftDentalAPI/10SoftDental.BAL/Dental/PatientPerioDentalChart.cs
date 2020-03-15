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
   public class PatientPerioDentalChart: IPeriodentalChart
    {
        public PatientPerioDentalChart()
        {
            this.commonResponseResult = new CommonResponse();
            this.dataSet = new DataSet();
        }
        public ResponseModel CreateResponse(bool status, string messageCode, string message, object data)
        {
            return this.commonResponseResult.CreateResponse(status, messageCode, message, data);
        }
        private CommonResponse commonResponseResult;
        private int? periodontalChartId;
        private long dentalAdultMainId;
        private long? patientId;
        private string jsonObject;
        private long? updatedBy;
        CommonDAL commonDAL = null;
        DataSet dataSet = null;

        public int? PeriodontalChartId { get => periodontalChartId; set => periodontalChartId = value; }
        public long DentalAdultMainId { get => dentalAdultMainId; set => dentalAdultMainId = value; }
        public long? PatientId { get => patientId; set => patientId = value; }
        public string JsonObject { get => jsonObject; set => jsonObject = value; }
        public long? UpdatedBy { get => updatedBy; set => updatedBy = value; }


        public ResponseModel SavePeriodentalChart()
        {
            try
            {
                commonDAL = new CommonDAL();
                dataSet = commonDAL.SavePeriodentalChart(this);
                return CreateResponse(Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? true : false, Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? "Success" : "Failed", dataSet.Tables[0].Rows[0]["Message"].ToString(), dataSet);
            }
            catch (Exception ex)
            {
                return CreateResponse(false, "Error", ex.InnerException.ToString(), "");
            }
        }

        public DataSet GetPatientPeriodentalChart(int periodentalChartId, long dentalAdultMainId)
        {
            dataSet = new DataSet();
            dataSet = new DAL.Common.CommonDAL().GetPatientPeriodentalChart(periodentalChartId,dentalAdultMainId);
            return dataSet;
        }

        //public int? DentalTeethMasterId { get; set; }
        //public string DentalTeethMaster { get; set; }
        //public string a { get; set; }
        //public string b { get; set; }
        //public string c { get; set; }
        //public string ImageName { get; set; }
        //public bool? IsImplant { get; set; }
        //public string Notes { get; set; }
        //public List<MobilityData> mobilityData { get; set; }
        //public List<MarginData> marginData { get; set; }
        //public List<ProbingDepthData> probingDepthData { get; set; }
        //public List<FurcationData> furcationData { get; set; }

    }

    //public class Stages
    //{
    //    public string a { get; set; }
    //    public string b { get; set; }
    //    public string c { get; set; }

    //}
    //public class MobilityData
    //{
    //    public string TeethMaster { get; set; }
    //    public string Value { get; set; }

    //}
    //public class MarginData
    //{
    //    public string TeethMaster { get; set; }
    //    public List<Stages> stages { get; set; }

    //}

    //public class ProbingDepthData
    //{
    //    public string TeethMaster { get; set; }
    //    public List<Stages> stages { get; set; }
    //}

    //public class FurcationData
    //{
    //    public string A { get; set; }
    //    public List<string> TeethA { get; set; }
    //    public string B { get; set; }
    //    public List<string> TeethB { get; set; }
    //    public string C { get; set; }
    //    public List<string> TeethC { get; set; }
    //}

    //public class ImplantData
    //{
    //    public string TeethMaster { get; set; }
    //    public string ImageName { get; set; }
    //    public bool IsImplant { get; set; }
    //}

    //public class BleedingData
    //{
    //    public string TeethMaster { get; set; }
    //    public List<Stages> stages { get; set; }
    //}
    //public class PlaqueData
    //{
    //    public string TeethMaster { get; set; }
    //    public List<Stages> stages { get; set; }
    //}



}
