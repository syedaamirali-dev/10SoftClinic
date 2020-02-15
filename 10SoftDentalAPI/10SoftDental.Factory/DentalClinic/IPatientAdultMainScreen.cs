using System;
using System.Collections.Generic;
using System.Data;

namespace _10SoftDental.Factory.DentalClinic
{
    public interface IPatientAdultMainScreen
    {
        long? DentalAdultMainId { get; set; }
        long VisitRegisterId { get; set; }
        long? DoctorTreatmentId { get; set; }
        long? DoctorAssignedTo { get; set; }
        string Comments { get; set; }
        DateTime? IssueDate { get; set; }
        long? UpdatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        long? PatientId { get; set; }
        long? ClinicId { get; set; }
        long? DocumentBookId { get; set; }
        long? DocumentTypeId { get; set; }
        //List<ITeethSectionNotationMapping> ITeethSectionNotationMapping { get; set; }
        DataTable TeethSectionNotationMappingDT { get; set; } 
    }
}
