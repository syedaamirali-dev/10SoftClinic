namespace _10SoftDental.Factory.Common
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public object data;
    }
}