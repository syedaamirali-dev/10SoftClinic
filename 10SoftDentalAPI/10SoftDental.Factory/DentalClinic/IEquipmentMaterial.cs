using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SoftDental.Factory.DentalClinic
{
   public interface IEquipmentMaterial
    {
        long? EquipmentMaterialId { get; set; }
        long? DoctorStudentId { get; set; }
        int? Year { get; set; }
        DateTime? CheckInDate { get; set; }
        DateTime? CheckOutDate { get; set; }
        bool? Session { get; set; }

        string Comments { get; set; }
        long? ApprovedBy { get; set; }

        DateTime? ApprovedDate { get; set; }

        bool? IsApproved { get; set; }
        string JsonObjectData { get; set; }
        string RequestType { get; set; }
    }
}
