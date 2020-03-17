using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Http;
using _10SoftDental.BAL.Dental;
using Newtonsoft.Json;

namespace _10SoftDental.Controllers
{
    public class TransactionController : ApiController
    {

        PatientAdultMain patientBAL = null;
        AdultMainTreatment adultMainTreatmentBAL = null;
        PatientOcclusion patientOcclusion = null;
        PatientPerioDentalChart perioDentalChart = null;
        DataSet dataSet = null;
        private List<PatientMedication> patientMedicationList = null;
        private LabReport labReport = null;


        [HttpPost]
        public IHttpActionResult SaveDentalAdultMain(PatientAdultMain adultMain)
        {
            try
            {
                var result = adultMain.SaveDentalAdultMain();
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IHttpActionResult SavePatientHistory(PatientAdultMain adultMain)
        {
            try
            {
                var result = adultMain.SavePatientHistory();
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //http://localhost:55453/api/Transaction/GetAdultMainScreeningData?clinicId=3&patientId=15&Mobile=&doctorId=&DoctorTreatmentId=35&dentalMainId=1
        [HttpGet]
        public IHttpActionResult GetAdultMainScreeningData(long patientId, long? DoctorTreatmentId, long? dentalMainId, bool? isLocal, int? visitId)
        {
            try
            {
                var clinicId = HttpContext.Current.Request.Headers.GetValues("clinicId");
                var doctorId = HttpContext.Current.Request.Headers.GetValues("doctorId");
                var loginUserId = HttpContext.Current.Request.Headers.GetValues("userId");
                patientBAL = new PatientAdultMain();
                patientBAL = patientBAL.Dental_GetAdultMainScreeningData(Convert.ToInt32(clinicId[0]), patientId, Convert.ToInt32(doctorId[0]), DoctorTreatmentId, dentalMainId, isLocal, visitId);
                return Ok(patientBAL);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //Here goes 3 Grid Illness, Symptoms and Patient Problem
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

        //Here goes 1 Grid Chief Complaint
        [HttpPost]
        public IHttpActionResult SaveDentalTreatmentPlanning(AdultMainTreatment adultMainTreatment)
        {
            try
            {
                string result = "";
                adultMainTreatment.SaveDentalTreatmentPlanning();
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public IHttpActionResult SavePatientMedication(List<PatientMedication> patientMedicationList)
        {
            try
            {
                patientBAL = new PatientAdultMain();
                patientBAL.SavePatientMedication(patientMedicationList);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public IHttpActionResult SavePatientCaseSheet(PatientAdultMain patientAdultMain)
        {
            try
            {
                patientBAL = new PatientAdultMain();
                var result = patientAdultMain.SavePatientCaseSheet();
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //http://localhost:55453/api/Transaction/SavePatientOcclusion
        [HttpPost]
        public IHttpActionResult SavePatientOcclusion(PatientOcclusion patientOcclusion)
        {
            try
            {
                var result = patientOcclusion.SavePatientOcclusion();
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public IHttpActionResult SavePatientClinicalExamination(PatientClinicalExamination patientClinical)
        {
            try
            {
                patientBAL = new PatientAdultMain();
                var result = patientBAL.SavePatientClinicalExamination(patientClinical);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public IHttpActionResult SendforCaseStudy(PatientAdultMain patientAdultMain)
        {
            try
            {
                patientBAL = new PatientAdultMain();
                var result = patientAdultMain.SendforCaseStudy();//Convert.ToInt64(patientAdultMain.DentalAdultMainId),Convert.ToBoolean(patientAdultMain.IsSentforCaseStudy)
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        [HttpPost]
        public IHttpActionResult ApproveCaseStudy(PatientAdultMain patientAdultMain)
        {
            try
            {
                patientBAL = new PatientAdultMain();
                var result = patientAdultMain.ApproveCaseStudy();//Convert.ToInt64(patientAdultMain.DentalAdultMainId),Convert.ToBoolean(patientAdultMain.IsSentforCaseStudy)
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        public IHttpActionResult ApproveTreatmentPlan(PatientAdultMain patientAdultMain)
        {
            try
            {
                patientBAL = new PatientAdultMain();
                var result = patientAdultMain.ApproveTreatmentPlan();//Convert.ToInt64(patientAdultMain.DentalAdultMainId),Convert.ToBoolean(patientAdultMain.IsSentforCaseStudy)
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IHttpActionResult SendTreatmentPlanningforApproval(PatientAdultMain patientAdultMain)
        {
            try
            {
                patientBAL = new PatientAdultMain();
                var result = patientAdultMain.SendTreatmentPlanningforApproval(Convert.ToInt64(patientAdultMain.DentalAdultMainId), Convert.ToBoolean(patientAdultMain.IsTreatmentPlanSentForApproval));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        public IHttpActionResult SendforApproval(PatientAdultMain patientAdultMain)
        {
            try
            {
                patientBAL = new PatientAdultMain();
                var result = patientAdultMain.SendforApproval(Convert.ToInt64(patientAdultMain.DentalAdultMainId), Convert.ToBoolean(patientAdultMain.IsSentForApproval));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public IHttpActionResult GetPatientClinicalExamination(long dentalAdultMainId, long? ClinicalExaminationId)
        {
            try
            {
                List<PatientClinicalExamination> patientClinical = new List<PatientClinicalExamination>();
                patientBAL = new PatientAdultMain();
                patientClinical = patientBAL.GetPatientClinicalExamination(dentalAdultMainId, ClinicalExaminationId);
                return Ok(patientClinical);
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
                var req = HttpContext.Current.Request.Headers.GetValues("clinicId");
                var doctorId = HttpContext.Current.Request.Headers.GetValues("doctorId");
                var req2 = Request.Headers.GetValues("userId");
                adultMainTreatmentBAL = new AdultMainTreatment();
                dataSet = new DataSet();
                dataSet = adultMainTreatmentBAL.GetDentalAdultTreatmentDetails(DentalTreatmentId);
                dataSet.Tables[0].TableName = "LevelMaster";
                dataSet.Tables[1].TableName = "IllnessMaster";
                dataSet.Tables[2].TableName = "SymptomMaster";
                dataSet.Tables[3].TableName = "DoctorTreatmentDiagnosis";
                dataSet.Tables[4].TableName = "DoctorTreatmentIllness";
                dataSet.Tables[5].TableName = "DoctorTreatmentSymptom";
                dataSet.Tables[6].TableName = "DoctorTreatmentPatientProblem";
                dataSet.Tables[7].TableName = "DiagnosisList";
                return Ok(dataSet);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public IHttpActionResult GetPatientMedication(long dentalAdultMainId)
        {
            try
            {
                patientMedicationList = new List<PatientMedication>();
                patientBAL = new PatientAdultMain();
                patientMedicationList = patientBAL.Dental_PatientMedication(dentalAdultMainId);
                return Ok(patientMedicationList);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //http://localhost:55453/api/Transaction/GetPatientOcclusion?occlusionId=1
        [HttpGet]
        public IHttpActionResult GetPatientOcclusion(long occlusionId)
        {
            try
            {
                dataSet = new DataSet();
                patientOcclusion = new PatientOcclusion();
                dataSet = patientOcclusion.GetPatientOcclusion(occlusionId);
                return Ok(dataSet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public IHttpActionResult GetPatienDropdownData()
        {
            try
            {
                dataSet = new DataSet();
                patientBAL = new PatientAdultMain();
                dataSet = patientBAL.Dental_GetPatienDropdownData();
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
        [HttpGet]
        public IHttpActionResult GetLabReports(long? doctorTreatmentId)
        {
            try
            {
                labReport = new LabReport();
                var result = labReport.GetLabReport(doctorTreatmentId);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpGet]
        public IHttpActionResult Dental_ShowTreatmentLabReport(long? labReportRequestId)
        {
            try
            {
                labReport = new LabReport();
                var result = labReport.Dental_ShowTreatmentLabReport(labReportRequestId);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        public IHttpActionResult SaveLabReport(LabReport labReport)
        {
            try
            {
                //labReport = new LabReport();
                var result = labReport.SaveLabReport();
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //http://localhost:55453/api/Transaction/SavePeriodentalChart
        [HttpPost]
        public IHttpActionResult SavePeriodentalChart(dynamic obj)
        {
            try
            {
                perioDentalChart = new PatientPerioDentalChart();
                dynamic data = obj;
                perioDentalChart.PeriodontalChartId = Convert.ToInt32(JsonConvert.DeserializeObject(data["PeriodentalChartId"].ToString()));//((Newtonsoft.Json.Linq.JObject)data).ChildrenTokens[0]
                perioDentalChart.DentalAdultMainId = Convert.ToInt64(JsonConvert.DeserializeObject(data["DentalAdultMainId"].ToString()));
                perioDentalChart.PatientId = JsonConvert.DeserializeObject(data["PatientId"].ToString()) == 0 ? null : Convert.ToInt64(JsonConvert.DeserializeObject(data["PatientId"].ToString()));
                perioDentalChart.JsonObject = Convert.ToString(JsonConvert.DeserializeObject(data["JsonObject"].ToString()));
                perioDentalChart.UpdatedBy = Convert.ToInt64(JsonConvert.DeserializeObject(data["UpdatedBy"].ToString()));
                var result = perioDentalChart.SavePeriodentalChart();
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //http://localhost:55453/api/Transaction/GetPatientPeriodentalChart?periodentalChartId=1&dentalAdultMainId=24
        [HttpGet]
        public IHttpActionResult GetPatientPeriodentalChart(int periodentalChartId, long dentalAdultMainId)
        {
            try
            {
                perioDentalChart = new PatientPerioDentalChart();
                var result = perioDentalChart.GetPatientPeriodentalChart(periodentalChartId, dentalAdultMainId);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
