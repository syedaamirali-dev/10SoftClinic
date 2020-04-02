using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using _10SoftDental.BAL.Dental;

namespace _10SoftDental.Controllers
{
    public class DentalMasterController : ApiController
    {
        public static string ApiUri = ConfigurationManager.AppSettings["AppURL"].ToString();
        private DentalMaster dentalMassterBAL;
        private string destinationPath { get; set; }
        public DentalMasterController()
        {
            this.dentalMassterBAL = new BAL.Dental.DentalMaster();
        }

        [HttpGet]
        public IHttpActionResult GetDentalChartNotations(int? dentalNotationId, int langId)
        {
            var result = this.dentalMassterBAL.GetDentalChartNotations(dentalNotationId, langId, ApiUri);
          
            if (result == null) return NotFound();
            return Ok(result);
        }

        //http://localhost:55453/api/DentalMaster/GetPatientVisitRegister?patientId=15&doctorId=
        [HttpGet]
        public IHttpActionResult GetPatientVisitRegister(long? patientId, long? doctorId)
        {
            var result = this.dentalMassterBAL.GetPatientVisitRegister(patientId, doctorId);
            if (result == null) return NotFound();
            return Ok(result);
        }

        //http://localhost:55453/api/DentalMaster/GetPatientInsurance?patientId=15
        [HttpGet]
        public IHttpActionResult GetPatientInsurance(long patientId)
        {
            var result = this.dentalMassterBAL.GetPatientInsurance(patientId);
            if (result == null) return NotFound();
            return Ok(result);
        }


        public IHttpActionResult GetUserAccessMenu(long userIdRef, long moduleIdRef)
        {
            var result = this.dentalMassterBAL.GetUserAccessMenu(userIdRef, moduleIdRef);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> SaveDentalChartNotations()//DentalMaster dentalMaster
        {
            DentalMaster dentalMaster = new DentalMaster();
            dentalMaster.DentalNotationId = Convert.ToInt32(HttpContext.Current.Request.Form["dentalNotationId"]);
            dentalMaster.PatientType = Convert.ToBoolean(HttpContext.Current.Request.Form["patientType"]);
            dentalMaster.IconNameEn = Convert.ToString(HttpContext.Current.Request.Form["iconNameEn"]);
            dentalMaster.IconNameAr = Convert.ToString(HttpContext.Current.Request.Form["iconNameAr"]);
            dentalMaster.DescriptionEn = Convert.ToString(HttpContext.Current.Request.Form["descriptionEn"]);
            dentalMaster.DescriptionAr = Convert.ToString(HttpContext.Current.Request.Form["descriptionAr"]);
            dentalMaster.IsActive = Convert.ToBoolean(HttpContext.Current.Request.Form["isActive"]);
            dentalMaster.CreatedBy = Convert.ToInt32(HttpContext.Current.Request.Form["createdBy"]);
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                this.destinationPath = "Images\\DentalNotationImgs\\"; 
                string ImageName = await UploadNotationImage(HttpContext.Current);
                dentalMaster.ImageURL = destinationPath + ImageName;
            }

            var result = dentalMaster.SaveDentalChartNotations();
            if (result == null) return NotFound();
            return Ok(result);
        }

        //http://localhost:55453/api/DentalMaster/SaveVisitRegister?visitRegisterId=40&IssueDate=2020-02-01&doctorId=13&patientId=15&modifiedBy=29
        //[HttpPost]
        //public IHttpActionResult SaveVisitRegister(long? visitRegisterId, DateTime IssueDate, long? doctorId, long? patientId, long? modifiedBy)
        //{
        //    try
        //    {
        //        string result = "";
        //        dentalMassterBAL = new DentalMaster();
        //        result=dentalMassterBAL.SaveVisitRegister(visitRegisterId, IssueDate, doctorId, patientId, modifiedBy);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        [HttpPost]
        public IHttpActionResult SaveVisitRegister(DentalMaster dentalMaster)
        {
            try
            {   
                var result = this.dentalMassterBAL.SaveVisitRegister(dentalMaster);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public IHttpActionResult Dental_GetDropdownMasterData()
        {
            try
            {
                var result = dentalMassterBAL.Dental_GetDropdownMasterData();
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<string> UploadNotationImage(HttpContext httpContext)
        {
            string path=string.Empty, newFilename=string.Empty;
            try
            {
                     var file =  HttpContext.Current.Request.Files[0];
                     path =  Path.Combine(HttpRuntime.AppDomainAppPath, destinationPath);
                     //string errorPath = Path.Combine(HttpRuntime.AppDomainAppPath, "logFiles\\");
                     newFilename = DateTime.Now.Ticks + file.FileName;
                     file.SaveAs(path+ newFilename);
                     return newFilename;
            }
            catch (Exception ex)
            {
                throw;
            }
        } 
    }
}
