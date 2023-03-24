namespace APIwithRedis.Models
{
    public interface IErrorResponse
    {
        ErrorResponse GetErrorResponse(string errorCode);
    }
}