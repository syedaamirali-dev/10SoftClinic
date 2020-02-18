using System;
using System.Data;
using System.Web.Http;
using _10SoftDental.BAL.Dental;

namespace _10SoftDental.Controllers
{
    public class TransactionController : ApiController
    {

        PatientAdultMain patientBAL = null;
        AdultMainTreatment adultMainTreatmentBAL = null;
        DataSet dataSet = null;
        [HttpPost]
        public IHttpActionResult SaveDentalAdultMain(PatientAdultMain adultMain)
        {
            try
            {
                string result = "";
                result=adultMain.SaveDentalAdultMain();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public IHttpActionResult SaveDentalAdultTreatmentDiagnosis(AdultMainTreatment adultMainTreatment)
        {
            try
            {
                string result = "";
                adultMainTreatment.SaveDentalAdultTreatmentDiagnosis();
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public IHttpActionResult GetDentalAdultTreatmentDetails(long? DentalTreatmentId)
        {
            try
            {
                adultMainTreatmentBAL = new AdultMainTreatment();
                dataSet = new DataSet();
                dataSet=adultMainTreatmentBAL.GetDentalAdultTreatmentDetails(DentalTreatmentId);
                dataSet.Tables[0].TableName = "LevelManager";
                dataSet.Tables[1].TableName = "IllnessMaster";
                dataSet.Tables[2].TableName = "SymptomMaster";
                dataSet.Tables[3].TableName = "DoctorTreatmentDiagnosis";
                dataSet.Tables[4].TableName = "DoctorTreatmentIllness";
                dataSet.Tables[5].TableName = "DoctorTreatmentSymptom";
                dataSet.Tables[6].TableName = "DoctorTreatmentPatientProblem";
                return Ok(dataSet);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public IHttpActionResult GetDentalAdultTreatmentMaster(string diagnosis)
        {
            try
            {
                adultMainTreatmentBAL = new AdultMainTreatment();
                dataSet = new DataSet();
                dataSet = adultMainTreatmentBAL.GetDentalAdultTreatmentMaster(diagnosis);
                return Ok(dataSet);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
