using _10SoftDental.DAL.Common;
using _10SoftDental.Factory.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SoftDental.BAL.Common
{
   public class CommonBAL : ICommonResponse
    {
        private DataTable _dataTable;
        private CommonDAL commonDAL;
        private CommonResponse commonResponseResult;
        private DataSet _dataSet;

        public CommonBAL()
        {
            _dataTable = new DataTable();
            _dataSet = new DataSet();
            this.commonResponseResult = new CommonResponse();
            this.commonDAL = new CommonDAL();
        }
        public ResponseModel CreateResponse(bool status, string messageCode, string message, object data)
        {
            return this.commonResponseResult.CreateResponse(status, messageCode, message, data);
        }

        public ResponseModel GetAllWaitingList()
        {
            try
            {
                _dataSet = this.commonDAL.GetAllWaitingList();
                return CreateResponse(true, "Success", "GetAllWaitingList", _dataSet);
            }
            catch (Exception ex)
            {
                return this.commonResponseResult.CreateResponse(false, "Error", ex.Message.ToString(), "");
            }

        }
        public ResponseModel GetAllVisitList()
        {
            try
            {
                _dataSet = this.commonDAL.GetAllVisitList();
                return CreateResponse(true, "Success", "GetAllVisitList", _dataSet);
            }
            catch (Exception ex)
            {
                return this.commonResponseResult.CreateResponse(false, "Error", ex.Message.ToString(), "");
            }

        }
    }
}
