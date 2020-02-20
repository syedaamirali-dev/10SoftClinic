using _10SoftDental.BAL.Dental;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SoftDental.BAL.Helper
{
   public class DatatableToList
    {
            public List<TeethSectionNotationMapping> TeethList(DataTable dt)
            {
                var convertedList = (from col in dt.AsEnumerable()
                                     select new TeethSectionNotationMapping()
                                     {
                                         TeethSectionNotationMappingId = Convert.ToInt32(col["TeethSectionNotationMappingId"]),
                                         DentalTeethMasterId = Convert.ToInt32(col["DentalTeethMasterId"]),
                                         DentalTeethSectionMasterId = Convert.ToInt32(col["DentalTeethSectionMasterId"]),
                                         DentalNotationId = Convert.ToInt32(col["DentalNotationId"]),
                                         DentalAdultMainId = Convert.ToInt64(col["DentalAdultMainId"]),
                                         VisitRegisterId = Convert.ToInt64(col["VisitRegisterId"]),
                                         Color = Convert.ToString(col["Color"])
                                     }).ToList();
                return convertedList.ConvertAll<TeethSectionNotationMapping>(o => (TeethSectionNotationMapping)o);
            }
    }
}
