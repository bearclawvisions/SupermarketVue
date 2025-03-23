using System.Net;

namespace Supermarket.Business.CustomExceptions;

public class BusinessException : System.Exception
{
    public int StatusCode { get; }

    public BusinessException(string message, int statusCode = (int)HttpStatusCode.BadRequest) : base(message)
    {
        StatusCode = statusCode;
    }
}