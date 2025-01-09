namespace Angular.EndPoint.WebApi.Models.ApiResponse;

public enum ApiResultType : byte
{
    Success = 1, 
    Failed = 2,
    FromException = 3,
    UnAuthorize = 4,
}

public class JsonResult
{
    public static JsonResult<T> Success<T>(T data, string message = "Success", string token = "")
    {
        return new JsonResult<T>
        {
            Data = data,
            Error = null,
            Message = message,
            Success = true,
            Token = token
        };
    }

    public static JsonResult<T> Failure<T>(string message, Exception error = null, string token = "")
    {
        return new JsonResult<T>
        {
            Data = default,
            Error = error,
            Message = message,
            Success = false,
            Token = token
        };
    }

    public static JsonResult<object> FromException(Exception ex, string message = "An error occurred", string token = "")
    {
        return new JsonResult<object>
        {
            Data = { },
            Error = ex,
            Message = $"{message}: {ex.Message}",
            Success = false,
            Token = token
        };
    }
}

public class JsonResult<T> : JsonResult
{
    public bool Success { get; set; }
    public T Data { get; set; }
    public string Message { get; set; }
    public Exception Error { get; set; }
    public string Token { get; set; }
}
