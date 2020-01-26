using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SoftDental.Factory.DentalClinic
{
   public interface IPatientScreeningSheet
    {

        string OPDNo { get; set; }
        string Name { get; set; }
        string MobileNo { get; set; }
        string Age { get; set; }
    }
}
