using Angular_WebApi.ApplicationBases.Models;
using Angular_WebApi.Providers.HttpContexts.DI;
using Angular_WebApi.Providers.Serializer.Excel.Repository;
using Angular_WebApi.Utilities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Angular_WebApi.Controllers.BaseControllers;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController : Controller
{
    protected UtilitiesServices ApplicationContext => HttpContext.ApplicationContext();

    protected IMediator mediator;

    protected BaseController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public async Task<IActionResult> Excel<T>(List<T> list)
    {
        var serializer = (IExcelSerializer)HttpContext.RequestServices.GetRequiredService(typeof(IExcelSerializer));
        var bytes = await serializer.ListToExcelByteArray(list);
        return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
    }

    public async Task<IActionResult> Excel<T>(List<T> list, string fileName)
    {
        var serializer = (IExcelSerializer)HttpContext.RequestServices.GetRequiredService(typeof(IExcelSerializer));
        var bytes = await serializer.ListToExcelByteArray(list);
        return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{fileName}.xlsx");
    }

    protected virtual async Task<IActionResult> Create<TCommand, TCommandResult>(TCommand command)
        where TCommand : ICommand<TCommandResult> => Ok(await mediator.Send(command));

    protected virtual async Task<IActionResult> Edit<TCommand, TCommandResult>(TCommand command)
        where TCommand : ICommand<TCommandResult> => Ok(await mediator.Send(command));


    protected async Task<IActionResult> Delete<TCommand, TCommandResult>(TCommand command)
        where TCommand : class, ICommand<TCommandResult> => Ok(await mediator.Send(command));

    protected async Task<IActionResult> Command<TCommand, TCommandResult>(TCommand command)
        where TCommand : class, ICommand<TCommandResult> => Ok(await mediator.Send(command));

    protected async Task<IActionResult> QueryList<TQuery, TQueryResult>(TQuery query)
        where TQuery : class, IQuery<List<TQueryResult>> => Ok(await mediator.Send(query));

    protected async Task<IActionResult> Query<TQuery, TQueryResult>(TQuery query)
        where TQuery : class, IQuery<TQueryResult> => Ok(await mediator.Send(query));

    public override OkObjectResult Ok([ActionResultObjectValue] object? value)
        => base.Ok(RequestResponse.JsonResult.Success(value ?? true));




}
