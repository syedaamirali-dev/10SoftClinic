namespace _10SoftDental.Factory.Common
{
    public interface ICommonResponse
    {

        ResponseModel CreateResponse(bool status, string messageCode, string message,object data);
    }
}