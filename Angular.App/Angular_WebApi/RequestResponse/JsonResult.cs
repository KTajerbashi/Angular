namespace Angular_WebApi.RequestResponse;

public class JsonResult
{
    public static JsonResult<T> Success<T>(T data)
    {
        return new JsonResult<T>()
        {
            Data = data,
            Error = null,
            Message = "عملیات با موفقیت انجام گردید.",
            Success = true,
            Token = ""
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
