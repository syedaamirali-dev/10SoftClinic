using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SoftDental.Factory.DentalClinic
{
    public interface IPatientOcclusion
    {
        long? OcclusionId { get; set; }
        long DentalAdultMainId { get; set; }
        string MidLine { get; set; }
        string OverJet { get; set; }
        string OverBite { get; set; }

        string OpenBite { get; set; }
        bool? RightMolars_ClassI { get; set; }
        bool? RightMolars_ClassII { get; set; }
        bool? RightMolars_ClassIII { get; set; }
        bool? RightCanine_ClassI { get; set; }
        bool? RightCanine_ClassII { get; set; }
        bool? RightCanine_ClassIII { get; set; }
        string Physiological { get; set; }
        string Primate { get; set; }
        string Crowding { get; set; }
        string Congental_Missing_Tooth { get; set; }
        string Crossbite_Anterior { get; set; }
        string Posterior { get; set; }
        string Describe { get; set; }
        string ThumbSucking { get; set; }
        string FingerSucking { get; set; }
        string TongueThrusting { get; set; }
        string AnyOther { get; set; }
        long? UpdatedBy { get; set; }

    }
}
