using _10SoftDental.BAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            var result = this.commonBAL.GetAllWaitingList();
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
    }
}
