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
[Route("app/[controller]")]
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

    // Return method simplified with a non-async version.
    // Async behavior is unnecessary since the result is a static value.
    protected virtual IActionResult Return(object? obj)
    {
        if (obj == null)
        {
            return Ok("");  // Return an empty string if obj is null
        }

        return Ok(obj);  // Return the object as an OK result
    }
}
