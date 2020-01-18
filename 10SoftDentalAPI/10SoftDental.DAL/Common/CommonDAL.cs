using System.Data;
using System.Data.SqlClient;

namespace _10SoftDental.DAL.Common
{
    public class CommonDAL : ApplicationUtility.DataAccess
    {
        private string _storedProcedure;
        private DataSet dataSet;
        private SqlParameter[] _parameters;

        public CommonDAL() :
            base(ApplicationUtility.Utility.ConnectionString)
        {

        }
        public DataSet GetAllWaitingList()
        {
            _storedProcedure = "VisitRegister_SelectByCriteria";
            _parameters = new SqlParameter[5];
            _parameters[0] = new SqlParameter("@IsLocal", SqlDbType.Bit);
            _parameters[0].Value = 0;
            _parameters[1] = new SqlParameter("@ClinicIdRef", SqlDbType.Int);
            _parameters[1].Value = 3;
            _parameters[2] = new SqlParameter("@PageIndex", SqlDbType.Int);
            _parameters[2].Value = 1;
            _parameters[3] = new SqlParameter("@PageRecord", SqlDbType.Int);
            _parameters[3].Value = 100;
            _parameters[4] = new SqlParameter("@DoctorIdRef", SqlDbType.Int);
            _parameters[4].Value = 13;
            return RunProcedure(_storedProcedure, _parameters, true);
        }
    }
}
