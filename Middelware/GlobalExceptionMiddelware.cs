
using Abp.Json;
using Azure;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AcademyManager.Middelware
{
    public class GlobalExceptionMiddelware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException ex)
            {

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";


                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Validation Error",
                    Detail = "There was an error with the data provided.",
                    Instance = context.Request.Path
                };


                problemDetails.Extensions["errors"] = ex.Errors
                    .Select(error => new { Field = error.PropertyName, Error = error.ErrorMessage });


                await context.Response.WriteAsJsonAsync(problemDetails);
            }
            catch (Exception ex)
            {

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";


                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Internal Server Error",
                    Detail = ex.Message,
                    Instance = context.Request.Path
                };

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }

    }
}
