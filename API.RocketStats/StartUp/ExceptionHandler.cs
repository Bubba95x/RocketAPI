using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace API.RocketStats.StartUp
{
    public class ExceptionHandler
    {
        public static Action<IApplicationBuilder> Handler()
        {
            return error =>
            {
                error.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;

                    ProblemDetails problem = null;
                    switch (exception)
                    {
                        case DbUpdateException dbUpdateException:
                            problem = new ProblemDetails()
                            {
                                Title = "DB Update Exception Occurred",
                                Type = nameof(DbUpdateException),
                                Status = 409,
                                Detail = dbUpdateException.InnerException.Message
                            };
                            break;

                        case Exception ex:
                            problem = new ProblemDetails()
                            {
                                Title = "An unexpected error has occured",
                                Type = nameof(Exception),
                                Status = 500,
                                Detail = ex.Message
                            };
                            break;
                    }

                    context.Response.StatusCode = problem?.Status ?? 500;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(problem));
                });
            };
        }
    }
}
