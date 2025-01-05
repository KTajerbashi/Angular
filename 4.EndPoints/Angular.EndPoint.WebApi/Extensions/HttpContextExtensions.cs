﻿using Angular.ApplicationLibrary.Providers;

namespace Angular.EndPoint.WebApi.Extensions;

public static class HttpContextExtensions
{
    public static ProviderServices ApplicationContext(this HttpContext httpContext) =>
        (ProviderServices)httpContext.RequestServices.GetService(typeof(ProviderServices));
}