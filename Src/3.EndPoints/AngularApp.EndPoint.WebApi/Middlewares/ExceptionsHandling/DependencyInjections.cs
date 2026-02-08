using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace AngularApp.EndPoint.WebApi.Middlewares.ExceptionsHandling;


public static class DependencyInjections
{
    public static WebApplication UseExceptionsHandling(this WebApplication app)
    {
        app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerFeature>()?
                    .Error;

                if (exception is null)
                    return;

                context.Response.ContentType = "application/json";

                var response = exception switch
                {
                    ValidationException validationException
                        => HandleValidationException(context, validationException),

                    UnauthorizedAccessException
                        => HandleUnauthorizedException(context),

                    _ => HandleServerException(context, exception)
                };

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(response)
                );
            });
        });

        return app;
    }

    // ===================== Handlers =====================

    private static object HandleValidationException(
        HttpContext context,
        ValidationException exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        return new
        {
            Type = "ValidationError",
            Errors = exception.Errors.Select(e => new
            {
                Field = e.PropertyName,
                Message = e.ErrorMessage
            })
        };
    }

    private static object HandleUnauthorizedException(HttpContext context)
    {
        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

        return new
        {
            Type = "Unauthorized",
            Message = "You are not authorized to perform this action."
        };
    }

    private static object HandleServerException(
        HttpContext context,
        Exception exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        return new
        {
            Type = "ServerError",
            Message = "An unexpected error occurred.",
            Detail = exception.Message // در صورت نیاز می‌تونی در Prod حذفش کنی
        };
    }
}
