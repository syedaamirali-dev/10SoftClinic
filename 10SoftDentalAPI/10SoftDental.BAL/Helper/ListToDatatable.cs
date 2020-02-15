using System;
using System.Collections.Generic;
using System.Data;
using _10SoftDental.BAL.Dental;
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
    }
}
