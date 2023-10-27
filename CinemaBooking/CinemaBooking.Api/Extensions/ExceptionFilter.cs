using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CinemaBooking.Domain.Exceptions;

namespace CinemaBooking.Api.Extensions
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case EntityNotFoundException:
                    context.Result = new NotFoundObjectResult(context.Exception.Message);
                    break;
                case MovieDuplicateException:
                    context.Result = new BadRequestObjectResult(context.Exception.Message);
                    break;
                case TheaterInvalidOperationException:
                    context.Result = new BadRequestObjectResult(context.Exception.Message);
                    break;
                default:
                    context.Result = new ObjectResult(context.Exception.Message)
                    {
                        StatusCode = 500
                    };
                    break;
            }

            // Prevent other exception filters from being executed.
            context.ExceptionHandled = true;
        }
    }
}
