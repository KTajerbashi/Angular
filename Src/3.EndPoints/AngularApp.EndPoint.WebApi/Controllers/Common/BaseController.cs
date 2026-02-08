namespace AngularApp.EndPoint.WebApi.Controllers.Common;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected ProviderServices ProviderServices => HttpContext.GetProviderServices();

    //public override OkObjectResult Ok([ActionResultObjectValue] object? value)
    //{
    //    return Ok(ApiResult.Success(value));
    //}


    //protected ObjectResult FailResult(string message, int statusCode = StatusCodes.Status400BadRequest)
    //{
    //    return StatusCode(statusCode, ApiResult.Faild(message));
    //}

    public virtual async Task<IActionResult> Command<TCommand>(TCommand command) 
        where TCommand : ICommand

    {
        await ProviderServices.Mediator.Send(command);
        return Ok();
    }

    public virtual async Task<IActionResult> Command<TCommand, TResponse>(TCommand command)
        where TCommand : ICommand<TResponse>
        => Ok(await ProviderServices.Mediator.Send(command));


    public virtual async Task<IActionResult> Query<TQuery, TResponse>(TQuery query)
        where TQuery : IQuery<TResponse>
        => Ok(await ProviderServices.Mediator.Send(query));

}
