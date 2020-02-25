using System;
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
            dataTable.Columns.Add("DentalNotationId", typeof(int));
            dataTable.Columns.Add("PatientId", typeof(long));
            dataTable.Columns.Add("DoctorId", typeof(long));
            dataTable.Columns.Add("UpdatedBy", typeof(long));
            dataTable.Columns.Add("DentalAdultMainId", typeof(long));
            dataTable.Columns.Add("VisitRegisterId", typeof(long));
            dataTable.Columns.Add("Color", typeof(string));


            for (int i = 0; i < datalist.Count; i++)
            {
                row = dataTable.NewRow();
                row["TeethSectionNotationMappingId"] = DataTypesUtilities.IntNZ(datalist[i].TeethSectionNotationMappingId);
                row["DentalTeethMasterId"] = DataTypesUtilities.IntNZ(datalist[i].DentalTeethMasterId);
                row["DentalTeethSectionMasterId"] = DataTypesUtilities.IntNZ(datalist[i].DentalTeethSectionMasterId);
                row["DentalNotationId"] = DataTypesUtilities.IntNZ(datalist[i].DentalNotationId);
                row["PatientId"] = DataTypesUtilities.LongNZ(datalist[i].PatientId);
                row["DoctorId"] = DataTypesUtilities.LongNZ(datalist[i].DoctorId);
                row["UpdatedBy"] = DataTypesUtilities.LongNZ(datalist[i].UpdatedBy);
                row["DentalAdultMainId"] = DataTypesUtilities.LongNZ(datalist[i].DentalAdultMainId);
                row["VisitRegisterId"] = DataTypesUtilities.LongNZ(datalist[i].VisitRegisterId);
                row["Color"] = DataTypesUtilities.StringNZ(datalist[i].Color);
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
                row["DoctorTreatmentDiagnosisId"] = DataTypesUtilities.LongNZ(datalist[i].DoctorTreatmentDiagnosisId);
                row["DoctorTreatmentIdRef"] = DataTypesUtilities.LongNZ(datalist[i].DoctorTreatmentIdRef);
                row["DiagnosisIdRef"] = DataTypesUtilities.IntNZ(datalist[i].DiagnosisIdRef);
                row["Level"] = DataTypesUtilities.LongNZ(datalist[i].Level);
                row["Comment"] = DataTypesUtilities.StringNZ(datalist[i].Comment);
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        public DataTable ToDataTablePatientMedication(List<PatientMedication> datalist)
        {
            dataTable = new DataTable();
            DataRow row = null;
            dataTable.Columns.Add("DoctorTreatmentMedicationId", typeof(long));
            dataTable.Columns.Add("DoctorTreatmentIdRef", typeof(long));
            dataTable.Columns.Add("MedicineIdRef", typeof(long));
            dataTable.Columns.Add("DosageIdRef", typeof(long));
            dataTable.Columns.Add("NoOfTimeInDay", typeof(int));
            dataTable.Columns.Add("Quantities", typeof(int));
            dataTable.Columns.Add("DentalAdultMainId", typeof(long));

            for (int i = 0; i < datalist.Count; i++)
            {
                row = dataTable.NewRow();
                row["DoctorTreatmentMedicationId"] = DataTypesUtilities.LongNZ(datalist[i].DoctorTreatmentMedicationId);
                row["DoctorTreatmentIdRef"] = DataTypesUtilities.LongNZ(datalist[i].DoctorTreatmentIdRef);
                row["MedicineIdRef"] = DataTypesUtilities.IntNZ(datalist[i].MedicineIdRef);
                row["DosageIdRef"] = DataTypesUtilities.LongNZ(datalist[i].DosageIdRef);
                row["NoOfTimeInDay"] = DataTypesUtilities.IntNZ(datalist[i].NoOfTimes);
                row["Quantities"] = DataTypesUtilities.IntNZ(datalist[i].Quantities);
                row["DentalAdultMainId"] = DataTypesUtilities.LongNZ(datalist[i].DentalAdultMainId);
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
                row["DoctorTreatmentIllnessId"] = DataTypesUtilities.LongNZ(datalist[i].DoctorTreatmentIllnessId);
                row["DoctorTreatmentIdRef"] = DataTypesUtilities.LongNZ(datalist[i].DoctorTreatmentIdRef);
                row["IllnessIdRef"] = DataTypesUtilities.IntNZ(datalist[i].IllnessIdRef);
                row["Level"] = DataTypesUtilities.LongNZ(datalist[i].Level);
                row["Comment"] = DataTypesUtilities.StringNZ(datalist[i].Comment);
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
                row["DoctorTreatmentSymptomId"] = DataTypesUtilities.LongNZ(datalist[i].DoctorTreatmentSymptomId);
                row["DoctorTreatmentIdRef"] = DataTypesUtilities.LongNZ(datalist[i].DoctorTreatmentIdRef);
                row["SymptonIdRef"] = DataTypesUtilities.IntNZ(datalist[i].SymptonIdRef);
                row["Level"] = DataTypesUtilities.LongNZ(datalist[i].Level);
                row["Comment"] = DataTypesUtilities.StringNZ(datalist[i].Comment);
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
                row["DoctorTreatmentPatientProblemId"] = DataTypesUtilities.LongNZ(datalist[i].DoctorTreatmentPatientProblemId);
                row["DoctorTreatmentIdRef"] = DataTypesUtilities.LongNZ(datalist[i].DoctorTreatmentIdRef);
                row["Problem"] = DataTypesUtilities.StringNZ(datalist[i].Problem);
                row["Level"] = DataTypesUtilities.LongNZ(datalist[i].Level);
                row["Comment"] = DataTypesUtilities.StringNZ(datalist[i].Comment);
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
    }
}
