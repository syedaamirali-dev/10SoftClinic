﻿using System;
using System.Collections.Generic;
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
        private List<PatientMedication> patientMedicationList = null;

        [HttpPost]
        public IHttpActionResult SaveDentalAdultMain(PatientAdultMain adultMain)
        {
            try
            {                
               var result=adultMain.SaveDentalAdultMain();
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
        public IHttpActionResult GetAdultMainScreeningData(int? clinicId, long patientId, string Mobile, long? doctorId, long? DoctorTreatmentId, long? dentalMainId)
        {
            try
            {
                patientBAL = new PatientAdultMain();
                patientBAL = patientBAL.Dental_GetAdultMainScreeningData(clinicId, patientId, Mobile, doctorId, DoctorTreatmentId, dentalMainId);
                return Ok(patientBAL);
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
                var result= patientAdultMain.SavePatientCaseSheet();
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
        public IHttpActionResult SendforApproval(PatientAdultMain patientAdultMain)
        {
            try
            {
                patientBAL = new PatientAdultMain();
                var result = patientAdultMain.SendforApproval(Convert.ToInt64(patientAdultMain.DentalAdultMainId),Convert.ToBoolean(patientAdultMain.IsSentForApproval));
                if (result == null) return NotFound();
                return Ok(result);
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
                dataSet.Tables[0].TableName = "LevelMaster";
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
    }
}
