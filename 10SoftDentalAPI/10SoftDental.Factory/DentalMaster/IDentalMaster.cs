using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SoftDental.Factory.DentalMaster
{
   public interface IDentalMaster
    {
        int? DentalNotationId { get; set; }
        int PatientType { get; set; }
        string IconNameEn { get; set; }
        string IconNameAr { get; set; }
        string DescriptionEn { get; set; }
        string DescriptionAr { get; set; }
        string ImageURL { get; set; }
        bool IsActive { get; set; }
        int? CreatedBy { get; set; }
        int LangId { get; set; }
    }
}
