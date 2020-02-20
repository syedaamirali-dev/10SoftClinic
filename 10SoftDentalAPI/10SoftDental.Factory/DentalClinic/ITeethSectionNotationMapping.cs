﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SoftDental.Factory.DentalClinic
{
    public interface ITeethSectionNotationMapping
    {
        int? TeethSectionNotationMappingId { get; set; }
        int? DentalTeethMasterId { get; set; }
        int? DentalTeethSectionMasterId { get; set; }
        int? DentalNotationId { get; set; }
        long? PatientId { get; set; }
        long? DoctorId { get; set; }
        long? UpdatedBy { get; set; }
        long? DentalAdultMainId { get; set; }
        long? VisitRegisterId { get; set; }
        string Color { get; set; }

    }
}