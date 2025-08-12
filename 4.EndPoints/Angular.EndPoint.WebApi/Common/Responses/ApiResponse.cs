namespace Angular.EndPoint.WebApi.Common.Responses;


public enum ApiResponseType : byte
{
    Success = 1,
    Faild = 2,
    Warning = 3,
    Error = 4
}

public class ApiResponse<T>
{
    public ApiResponseType Status { get; set; }
    public string Message { get; set; }
    public string Token { get; set; }
    public T Data { get; set; }
}

public static class ApiResponse
{
    public static ApiResponse<T> Success<T>(T data, string message = null, string token = null)
    {
        return new ApiResponse<T>
        {
            Status = ApiResponseType.Success,
            Data = data,
            Message = message,
            Token = token
        };
    }
    public static ApiResponse<string> Faild(string message = null, string token = null)
    {
        return new ApiResponse<string>
        {
            Status = ApiResponseType.Faild,
            Data = null,
            Message = message,
            Token = token
        };
    }
}