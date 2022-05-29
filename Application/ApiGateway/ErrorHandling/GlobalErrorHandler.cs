using Common.ErrorHandling;
using Microsoft.AspNetCore.Diagnostics;

namespace ApiGateway.ErrorHandling
{
    public static class GlobalErrorHandler
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var error = contextFeature.Error;

                    if (contextFeature != null)
                    {
                        if (error is HttpStatusException)
                        {
                            var errorType = (HttpStatusException)error;
                            context.Response.StatusCode = errorType.StatusCode;
                            await context.Response.WriteAsync(new ExceptionDTO()
                            {
                                StatusCode = errorType.StatusCode,
                                Message = errorType.Message
                            }.ToString());
                        }
                        else
                        {
                            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                            await context.Response.WriteAsync(new ExceptionDTO()
                            {
                                StatusCode = StatusCodes.Status500InternalServerError,
                                Message = "Internal Server Error."
                            }.ToString());
                        }
                    }
                });
            });
        }
    }
}
