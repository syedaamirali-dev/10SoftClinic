using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SoftDental.BAL.Common
{
   public class DentalResources
    {
        public int ResourceId { get; set; }

        public string ResourceLabel { get; set; }
        public string EnglishText { get; set; }
        public string ArabicText { get; set; }
        public int LanguageID { get; set; }
        public int ScreenID { get; set; }
    }
}
