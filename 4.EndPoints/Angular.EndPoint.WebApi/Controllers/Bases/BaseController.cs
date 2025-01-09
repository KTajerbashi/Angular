using Angular.ApplicationLibrary.BaseApplication.Pattern.MediatR.Commands;
using Angular.ApplicationLibrary.BaseApplication.Pattern.MediatR.Queries;
using Angular.ApplicationLibrary.Providers;
using Angular.ApplicationLibrary.Providers.Serializers;
using Angular.EndPoint.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Angular.EndPoint.WebApi.Controllers.Bases;

// Abstract base controller with general functionality
public abstract class BaseController : Controller
{
    protected IMediator mediator;
    protected ProviderServices ApplicationContext => HttpContext.ApplicationContext();

    protected BaseController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    public IActionResult ExcelAsync<T>(List<T> list)
    {
        var serializer = (IExcelSerializer)HttpContext.RequestServices.GetRequiredService(typeof(IExcelSerializer));
        var bytes = serializer.ListToExcelByteArray(list);
        return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
    }

    public IActionResult ExcelAsync<T>(List<T> list, string fileName)
    {
        var serializer = (IExcelSerializer)HttpContext.RequestServices.GetRequiredService(typeof(IExcelSerializer));
        var bytes = serializer.ListToExcelByteArray(list);
        return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{fileName}.xlsx");
    }

    protected virtual async Task<IActionResult> CreateAsync<TCommand, TCommandResult>(TCommand command)
        where TCommand : Command<TCommandResult>
        => Ok(await mediator.Send(command));

    protected virtual async Task<IActionResult> EditAsync<TCommand, TCommandResult>(TCommand command)
        where TCommand : Command<TCommandResult>
        => Ok(await mediator.Send(command));


    protected async Task<IActionResult> DeleteAsync<TCommand, TCommandResult>(TCommand command)
        where TCommand : Command<TCommandResult>
        => Ok(await mediator.Send(command));

    protected async Task<IActionResult> CommandAsync<TCommand, TCommandResult>(TCommand command)
       where TCommand : Command<TCommandResult>
       => Ok(await mediator.Send(command));

    protected async Task<IActionResult> QueryListAsync<TQuery, TQueryResult>(TQuery query)
        where TQuery : Query<List<TQueryResult>>
        => Ok(await mediator.Send(query));

    protected async Task<IActionResult> QueryAsync<TQuery, TQueryResult>(TQuery query)
    where TQuery : Query<TQueryResult>
        => Ok(await mediator.Send(query));




    //protected async Task<IActionResult> ReadTreeList<TQuery, TQueryResult>(TQuery query)
    //    where TQuery : IQuery<List<TQueryResult>>
    //    where TQueryResult : class, ITreeViewModel<TQueryResult> => Ok(await mediator.Send(query));

    //protected async Task<IActionResult> ReadDropDown<TQuery, TKey>(TQuery query)
    //    where TQuery : IQuery<List<DropDownList<TKey>>>
    //    where TKey : struct, IComparable, IComparable<TKey>, IConvertible, IEquatable<TKey>, IFormattable
    //    => Ok(await mediator.Send(query));

    protected async Task<IActionResult> ReturnResponse<TModel>(TModel model)
        => await Task.FromResult(Ok(model));


    public override OkObjectResult Ok([ActionResultObjectValue] object? value)
        => base.Ok(Models.ApiResponse.JsonResult.Success(value ?? true));

    public OkObjectResult OkWithMessage<T>(T data, string message)
        => base.Ok(Models.ApiResponse.JsonResult.Success(data, message));

    public ObjectResult Error(string message, Exception ex = null)
        => base.BadRequest(Models.ApiResponse.JsonResult.Failure<object>(message, ex));

    public ObjectResult CustomError(string message, Exception ex = null, string token = "")
        => base.BadRequest(Models.ApiResponse.JsonResult.FromException(ex, message, token));


    // Return method simplified with a non-async version.
    // Async behavior is unnecessary since the result is a static value.
    protected virtual ObjectResult Return<T>(T data, string message, ApiResultType type, Exception exception = null)
    {
        switch (type)
        {
            case ApiResultType.Success:
                return base.Ok(Models.ApiResponse.JsonResult.Success(data, message));
            case ApiResultType.Failed:
                return base.BadRequest(Models.ApiResponse.JsonResult.Failure<object>(message, exception)); ;
            case ApiResultType.FromException:
                return base.BadRequest(Models.ApiResponse.JsonResult.FromException(exception, message));
            case ApiResultType.UnAuthorize:
                return base.Unauthorized(Models.ApiResponse.JsonResult.Failure<object>(message,new UnauthorizedAccessException("You Have Not Access !!!")));
            default:
                return base.NotFound("Not Found Data");
        }
    }
}
