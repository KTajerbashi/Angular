using FluentValidation.Results;

namespace AngularApp.Core.Application.Exceptions;

public static class ExceptionExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="exception"></param>
    /// <returns></returns>
    public static AppException ThrowAppException(this Exception exception) => new AppException(exception.Message);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static AppException ThrowAppException(this Exception exception, string message) => new AppException(message, exception);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="exception"></param>
    /// <returns></returns>
    public static ValidationException ThrowValidationException(this Exception exception) => new ValidationException(exception.Message);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="errors"></param>
    /// <returns></returns>
    public static ValidationException ThrowValidationException(this IEnumerable<ValidationFailure> errors) => new ValidationException(errors);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="errors"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static ValidationException ThrowValidationException(this IEnumerable<ValidationFailure> errors, string message) => new ValidationException(message, errors);
}
