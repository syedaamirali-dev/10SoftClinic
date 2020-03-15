using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SoftDental.Factory.DentalClinic
{
    public interface IPeriodentalChart
    {
         int? PeriodontalChartId { get; set; }
         long DentalAdultMainId { get; set; }

         long? PatientId { get; set; }
         string JsonObject { get; set; }
        long? UpdatedBy { get; set; }
    }
}
