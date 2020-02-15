using System;
using System.Web.Http;
using _10SoftDental.BAL.Dental;

namespace _10SoftDental.Controllers
{
    public class TransactionController : ApiController
    {

        PatientAdultMain patientBAL = null;
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
    }
}
