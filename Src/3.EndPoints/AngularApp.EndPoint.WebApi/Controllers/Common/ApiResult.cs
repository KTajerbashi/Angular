namespace AngularApp.EndPoint.WebApi.Controllers.Common;

public class ApiResult
{
    public static ApiResult<T> Success<T>(T data)
    {
        return new ApiResult<T>()
        {
            Data = data,
            Error = null!,
            Message = "Success",
            IsSuccess = true,
            Token = ""
        };
    }

    public static ApiResult<T> Return<T>(T data)
    {
        if (data is null || data is false)
            return Faild(data);
        return Success(data);
    }

    public static ApiResult<T> Faild<T>(T data)
    {
        return new ApiResult<T>()
        {
            Data = data,
            Error = null!,
            Message = "Faild",
            IsSuccess = false,
            Token = ""
        };
    }
    public static ApiResult<bool> UnAuthorize()
    {
        return new ApiResult<bool>()
        {
            Data = false,
            Error = null!,
            Message = "Unauthorized access. Please log in.",
            IsSuccess = false,
            Token = ""
        };
    }
}
public class ApiResult<T> : ApiResult
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public string Message { get; set; }
    public Exception Error { get; set; }
    public string Token { get; set; }
}