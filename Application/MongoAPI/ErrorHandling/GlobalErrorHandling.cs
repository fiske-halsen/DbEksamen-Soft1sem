using Common.ErrorHandling;
using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoAPI.ErrorHandling
{
    public static class GlobalErrorHandling
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
                            // TODO Maybe do error logs to db
                            //dbLogger.Error(errorType.Message, errorType.StatusCode);
                            context.Response.StatusCode = errorType.StatusCode;
                            await context.Response.WriteAsync(new ExceptionDTO()
                            {
                                StatusCode = errorType.StatusCode,
                                Message = errorType.Message
                            }.ToString());
                        }
                        else
                        {
                            //dbLogger.Error(error.Message, StatusCodes.Status500InternalServerError);
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
