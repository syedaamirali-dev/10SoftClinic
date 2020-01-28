using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _10SoftDental.BAL.DentalMaster;

namespace _10SoftDental.Controllers
{
    public class DentalMasterController : ApiController
    {
        private DentalMaster dentalMassterBAL;
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
        public IHttpActionResult SaveDentalChartNotations(DentalMaster dentalMaster)
        {
            var result = dentalMaster.SaveDentalChartNotations();
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
