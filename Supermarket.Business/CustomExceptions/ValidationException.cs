using System.Net;

namespace Supermarket.Business.CustomExceptions;

public class ValidationException : Exception
{
    public int StatusCode { get; }

    public ValidationException(string message, int statusCode = (int)HttpStatusCode.NotAcceptable) : base(message)
    {
        StatusCode = statusCode;
    }
}