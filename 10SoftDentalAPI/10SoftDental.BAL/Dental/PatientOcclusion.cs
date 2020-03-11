using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _10SoftDental.Factory.Common;
using _10SoftDental.Factory.DentalClinic;

namespace _10SoftDental.BAL.Dental
{
    public class PatientOcclusion : IPatientOcclusion
    {
        public PatientOcclusion()
        {
            this.commonResponseResult = new CommonResponse();
            this.dataSet = new DataSet();
        }
        public ResponseModel CreateResponse(bool status, string messageCode, string message, object data)
        {
            return this.commonResponseResult.CreateResponse(status, messageCode, message, data);
        }
        private CommonResponse commonResponseResult;
        private long? occlusionId;
        private long dentalAdultMainId;
        private string midLine;
        private string overJet;
        private string overBite;
        private string openBite;
        private bool? rightMolars_ClassI;
        private bool? rightMolars_ClassII;
        private bool? rightMolars_ClassIII;
        private bool? rightCanine_ClassI;
        private bool? rightCanine_ClassII;
        private bool? rightCanine_ClassIII;
        private string physiological;
        private string primate;
        private string crowding;
        private string congental_Missing_Tooth;
        private string crossbite_Anterior;
        private string posterior;
        private string describe;
        private string thumbSucking;
        private string fingerSucking;
        private string tongueThrusting;
        private string anyOther;
        private long? updatedBy;

        public long? OcclusionId { get => occlusionId; set => occlusionId = value; }
        public long DentalAdultMainId { get => dentalAdultMainId; set => dentalAdultMainId = value; }
        public string MidLine { get => midLine; set => midLine = value; }
        public string OverJet { get => overJet; set => overJet = value; }
        public string OverBite { get => overBite; set => overBite = value; }
        public string OpenBite { get => openBite; set => openBite = value; }
        public bool? RightMolars_ClassI { get => rightMolars_ClassI; set => rightMolars_ClassI = value; }
        public bool? RightMolars_ClassII { get => rightMolars_ClassII; set => rightMolars_ClassII = value; }
        public bool? RightMolars_ClassIII { get => rightMolars_ClassIII; set => rightMolars_ClassIII = value; }
        public bool? RightCanine_ClassI { get => rightCanine_ClassI; set => rightCanine_ClassI = value; }
        public bool? RightCanine_ClassII { get => rightCanine_ClassII; set => rightCanine_ClassII = value; }
        public bool? RightCanine_ClassIII { get => rightCanine_ClassIII; set => rightCanine_ClassIII = value; }
        public string Physiological { get => physiological; set => physiological = value; }
        public string Primate { get => primate; set => primate = value; }
        public string Crowding { get => crowding; set => crowding = value; }
        public string Congental_Missing_Tooth { get => congental_Missing_Tooth; set => congental_Missing_Tooth = value; }
        public string Crossbite_Anterior { get => crossbite_Anterior; set => crossbite_Anterior = value; }
        public string Posterior { get => posterior; set => posterior = value; }
        public string Describe { get => describe; set => describe = value; }
        public string ThumbSucking { get => thumbSucking; set => thumbSucking = value; }
        public string FingerSucking { get => fingerSucking; set => fingerSucking = value; }
        public string TongueThrusting { get => tongueThrusting; set => tongueThrusting = value; }
        public string AnyOther { get => anyOther; set => anyOther = value; }
        public long? UpdatedBy { get => updatedBy; set => updatedBy = value; }
        DataSet dataSet = null;

        public ResponseModel SavePatientOcclusion()
        {
            try
            {
                dataSet = new DataSet();
                dataSet = new DAL.Common.CommonDAL().SavePatientOcclusion(this);
                return CreateResponse(Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? true : false, Convert.ToInt32(dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? "Success" : "Failed", dataSet.Tables[0].Rows[0]["Message"].ToString(), dataSet);
            }
            catch (Exception ex)
            {
                return CreateResponse(false, "Error", ex.InnerException.ToString(), "");
            }
        }

        public DataSet GetPatientOcclusion(long occlusionId)
        {
            dataSet = new DataSet();
            dataSet = new DAL.Common.CommonDAL().GetPatientOcclusion(occlusionId);
            return dataSet;
        }
    }
}
