using _10SoftDental.Factory.DentalClinic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SoftDental.Factory.DentalMaster
{
   public interface IDentalMaster : IVisitHistory
    {
        int? DentalNotationId { get; set; }
        bool PatientType { get; set; }
        string IconNameEn { get; set; }
        string IconNameAr { get; set; }
        string DescriptionEn { get; set; }
        string DescriptionAr { get; set; }
        string ImageURL { get; set; }
        bool IsActive { get; set; }
        int? CreatedBy { get; set; }
        int LangId { get; set; }


        DataSet SaveDentalChartNotations();
        
    }
}
