using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using _10SoftDental.BAL.DentalMaster;

namespace _10SoftDental.Controllers
{
    public class DentalMasterController : ApiController
    {
        private DentalMaster dentalMassterBAL;
        private string destinationPath { get; set; }
        public DentalMasterController()
        {
            this.dentalMassterBAL = new BAL.DentalMaster.DentalMaster();
        }

        [HttpGet]
        public IHttpActionResult GetDentalChartNotations(int? dentalNotationId, int langId)
        {
            var result = this.dentalMassterBAL.GetDentalChartNotations(dentalNotationId, langId);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> SaveDentalChartNotations(DentalMaster dentalMaster)
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            { 
                this.destinationPath = "Images\\DentalNotationImgs\\"; 
                dentalMaster.ImageURL = await UploadNotationImage(HttpContext.Current);
            }
            var result = dentalMaster.SaveDentalChartNotations();
            if (result == null) return NotFound();
            return Ok(result);
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
                     return path + newFilename;
            }
            catch (Exception ex)
            {
                throw;
            }
        } 
    }
}
