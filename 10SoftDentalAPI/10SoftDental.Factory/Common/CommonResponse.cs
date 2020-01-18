namespace _10SoftDental.Factory.Common
{
    public class CommonResponse : ICommonResponse
    {
        ResponseModel responseModel;
        public CommonResponse()
        {
            this.responseModel = new ResponseModel();
        }

        public ResponseModel CreateResponse(bool status, string messageCode, string message, object data)
        {
            this.responseModel.IsSuccess = status;
            this.responseModel.ErrorCode = messageCode;
            this.responseModel.Message = message;
            this.responseModel.data = data;
            return this.responseModel;
        }
    }
}