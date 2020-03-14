using _10SoftDental.BAL.Helper;
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

        public DataSet ValidateUser(string userName, string password)
        {
            return new DAL.Common.CommonDAL().ValidateUser(userName, password);
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
        public ResponseModel GetAllVisitList(int? userId)
        {
            try
            {
                _dataSet = this.commonDAL.GetAllVisitList(userId);
                return CreateResponse(true, "Success", "GetAllVisitList", _dataSet);
            }
            catch (Exception ex)
            {
                return this.commonResponseResult.CreateResponse(false, "Error", ex.Message.ToString(), "");
            }

        }
        public ResponseModel GetAllVisitHistoyList(bool? isLocal, int? clinicId, int? doctorId, int? loginUserId, int? visitId, int? patientId)
        {
            try
            {
                _dataSet = this.commonDAL.GetAllVisitHistoyList(isLocal,clinicId,doctorId,loginUserId,visitId,patientId);
                return CreateResponse(true, "Success", "GetAllVisitHistoyList", _dataSet);
            }
            catch (Exception ex)
            {
                return this.commonResponseResult.CreateResponse(false, "Error", ex.Message.ToString(), "");
            }

        }
        public ResponseModel GetResources(int? screenId)
        {
            try
            {
                _dataSet = this.commonDAL.GetResources(screenId);
                return CreateResponse(true, "Success", "GetAllResourceList", _dataSet);
            }
            catch (Exception ex)
            {
                return this.commonResponseResult.CreateResponse(false, "Error", ex.Message.ToString(), "");
            }

        }

        public ResponseModel SaveDentalResources(List<DentalResources> dentalResourcesList)
        {
            try
            {
                commonDAL = new CommonDAL();
                _dataTable = new DataTable();
                _dataSet = new DataSet();
                _dataTable = new ListToDatatable().ToDataTableDentalResources(dentalResourcesList);
                _dataSet = commonDAL.SaveDentalResources(_dataTable);
                return CreateResponse(Convert.ToInt32(_dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? true : false, Convert.ToInt32(_dataSet.Tables[0].Rows[0]["IsSuccess"]) == 1 ? "Success" : "Failed", _dataSet.Tables[0].Rows[0]["Message"].ToString(), _dataSet);
            }
            catch (Exception ex)
            {
                return CreateResponse(false, "Error", ex.InnerException.ToString(), "");
            }
        }
    }
}
