using _10SoftDental.BAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace _10SoftDental.Controllers
{
    public class CommonController : ApiController
    {
        private CommonBAL commonBAL;
        public CommonController()
        {
            this.commonBAL = new CommonBAL();
        }
        [HttpGet]
        public IHttpActionResult GetAllWaitingList()
        {
            var clinicId = HttpContext.Current.Request.Headers.GetValues("clinicId");
            var doctorId = HttpContext.Current.Request.Headers.GetValues("doctorId");
            var result = this.commonBAL.GetAllWaitingList(Convert.ToInt32(doctorId[0]), Convert.ToInt32(clinicId[0]));
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetAllVisitList()
        {
            var result = this.commonBAL.GetAllVisitList();
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetAllVisitList(int? userId)
        {
            var result = this.commonBAL.GetAllVisitList(userId);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult GetAllVisitHistoyList(bool? isLocal, int? visitId, int? patientId)
        {
            var clinicId = HttpContext.Current.Request.Headers.GetValues("clinicId");
            var doctorId = HttpContext.Current.Request.Headers.GetValues("doctorId");
            var loginUserId = HttpContext.Current.Request.Headers.GetValues("userId");
            var result = this.commonBAL.GetAllVisitHistoyList(isLocal, Convert.ToInt32(clinicId[0]), Convert.ToInt32(doctorId[0]), Convert.ToInt32(loginUserId[0]), visitId, patientId);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult GetResources(int? screenId)
        {
            var result = this.commonBAL.GetResources(screenId);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult SaveDentalResources(List<DentalResources> dentalResourcesList)
        {
            var result = this.commonBAL.SaveDentalResources(dentalResourcesList);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
