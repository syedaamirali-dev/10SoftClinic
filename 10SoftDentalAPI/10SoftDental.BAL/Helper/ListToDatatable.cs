﻿using System;
using System.Collections.Generic;
using System.Data;
using _10SoftDental.BAL.Dental;
using _10SoftDental.Factory.Models;
using ApplicationUtility;

namespace _10SoftDental.BAL.Helper
{
    public class ListToDatatable
    {
        DataTable dataTable = null;
        public DataTable ToDataTableTeetNotationList(List<TeethSectionNotationMapping> datalist)
        {
            dataTable = new DataTable();
            DataRow row = null;
            dataTable.Columns.Add("TeethSectionNotationMappingId", typeof(int));
            dataTable.Columns.Add("DentalTeethMasterId", typeof(int));
            dataTable.Columns.Add("DentalTeethSectionMasterId", typeof(int));
            dataTable.Columns.Add("DentalNotationId", typeof(bool));
            dataTable.Columns.Add("PatientId", typeof(long));
            dataTable.Columns.Add("DoctorId", typeof(long));
            dataTable.Columns.Add("UpdatedBy", typeof(long));
            dataTable.Columns.Add("DentalAdultMainId", typeof(long));
            dataTable.Columns.Add("VisitRegisterId", typeof(long));


            for (int i = 0; i < datalist.Count; i++)
            {
                row = dataTable.NewRow();
                row["TeethSectionNotationMappingId"] = DataTypesUtilities.IntNZ(datalist[i].TeethSectionNotationMappingId);
                row["DentalTeethMasterId"] = DataTypesUtilities.IntNZ(datalist[i].DentalTeethMasterId);
                row["DentalTeethSectionMasterId"] = DataTypesUtilities.IntNZ(datalist[i].DentalTeethSectionMasterId);
                row["DentalNotationId"] = DataTypesUtilities.BoolNZ(datalist[i].DentalNotationId);
                row["PatientId"] = DataTypesUtilities.LongNZ(datalist[i].PatientId);
                row["DoctorId"] = DataTypesUtilities.LongNZ(datalist[i].DoctorId);
                row["UpdatedBy"] = DataTypesUtilities.LongNZ(datalist[i].UpdatedBy);
                row["DentalAdultMainId"] = DataTypesUtilities.LongNZ(datalist[i].DentalAdultMainId);
                row["VisitRegisterId"] = DataTypesUtilities.LongNZ(datalist[i].VisitRegisterId);
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        public DataTable ToDataTableChiefCompliant(List<DoctorTreatment> datalist)
        {
            dataTable = new DataTable();
            DataRow row = null;
            dataTable.Columns.Add("DoctorTreatmentDiagnosisId", typeof(long));
            dataTable.Columns.Add("DoctorTreatmentIdRef", typeof(long));
            dataTable.Columns.Add("DiagnosisIdRef", typeof(int));
            dataTable.Columns.Add("Level", typeof(long));
            dataTable.Columns.Add("Comment", typeof(string));

            for (int i = 0; i < datalist.Count; i++)
            {
                row = dataTable.NewRow();
                row["DoctorTreatmentDiagnosisId"] = DataTypesUtilities.IntNZ(datalist[i].DoctorTreatmentDiagnosisId);
                row["DoctorTreatmentIdRef"] = DataTypesUtilities.IntNZ(datalist[i].DoctorTreatmentIdRef);
                row["DiagnosisIdRef"] = DataTypesUtilities.IntNZ(datalist[i].DiagnosisIdRef);
                row["Level"] = DataTypesUtilities.BoolNZ(datalist[i].Level);
                row["Comment"] = DataTypesUtilities.LongNZ(datalist[i].Comment);
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        public DataTable ToDataTableIllness(List<DoctorTreatmentIllness> datalist)
        {
            dataTable = new DataTable();
            DataRow row = null;
            dataTable.Columns.Add("DoctorTreatmentIllnessId", typeof(long));
            dataTable.Columns.Add("DoctorTreatmentIdRef", typeof(long));
            dataTable.Columns.Add("IllnessIdRef", typeof(int));
            dataTable.Columns.Add("Level", typeof(long));
            dataTable.Columns.Add("Comment", typeof(string));

            for (int i = 0; i < datalist.Count; i++)
            {
                row = dataTable.NewRow();
                row["DoctorTreatmentIllnessId"] = DataTypesUtilities.IntNZ(datalist[i].DoctorTreatmentIllnessId);
                row["DoctorTreatmentIdRef"] = DataTypesUtilities.IntNZ(datalist[i].DoctorTreatmentIdRef);
                row["IllnessIdRef"] = DataTypesUtilities.IntNZ(datalist[i].IllnessIdRef);
                row["Level"] = DataTypesUtilities.BoolNZ(datalist[i].Level);
                row["Comment"] = DataTypesUtilities.LongNZ(datalist[i].Comment);
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        public DataTable ToDataTableSympton(List<DoctorTreatmentSympton> datalist)
        {
            dataTable = new DataTable();
            DataRow row = null;
            dataTable.Columns.Add("DoctorTreatmentSymptomId", typeof(long));
            dataTable.Columns.Add("DoctorTreatmentIdRef", typeof(long));
            dataTable.Columns.Add("SymptonIdRef", typeof(int));
            dataTable.Columns.Add("Level", typeof(long));
            dataTable.Columns.Add("Comment", typeof(string));

            for (int i = 0; i < datalist.Count; i++)
            {
                row = dataTable.NewRow();
                row["DoctorTreatmentSymptomId"] = DataTypesUtilities.IntNZ(datalist[i].DoctorTreatmentSymptomId);
                row["DoctorTreatmentIdRef"] = DataTypesUtilities.IntNZ(datalist[i].DoctorTreatmentIdRef);
                row["SymptonIdRef"] = DataTypesUtilities.IntNZ(datalist[i].SymptonIdRef);
                row["Level"] = DataTypesUtilities.BoolNZ(datalist[i].Level);
                row["Comment"] = DataTypesUtilities.LongNZ(datalist[i].Comment);
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        public DataTable ToDataTablePatientProblem(List<DoctorTreatmentPatientProblem> datalist)
        {
            dataTable = new DataTable();
            DataRow row = null;
            dataTable.Columns.Add("DoctorTreatmentPatientProblemId", typeof(long));
            dataTable.Columns.Add("DoctorTreatmentIdRef", typeof(long));
            dataTable.Columns.Add("Problem", typeof(string));
            dataTable.Columns.Add("Level", typeof(long));
            dataTable.Columns.Add("Comment", typeof(string));

            for (int i = 0; i < datalist.Count; i++)
            {
                row = dataTable.NewRow();
                row["DoctorTreatmentPatientProblemId"] = DataTypesUtilities.IntNZ(datalist[i].DoctorTreatmentPatientProblemId);
                row["DoctorTreatmentIdRef"] = DataTypesUtilities.IntNZ(datalist[i].DoctorTreatmentIdRef);
                row["Problem"] = DataTypesUtilities.IntNZ(datalist[i].Problem);
                row["Level"] = DataTypesUtilities.BoolNZ(datalist[i].Level);
                row["Comment"] = DataTypesUtilities.LongNZ(datalist[i].Comment);
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
    }
}
