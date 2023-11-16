using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace CurrentAccountAPI.Api.Filters
{
    [ExcludeFromCodeCoverage]
    public class ExceptionFilterAttribute : Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute
    {
        private readonly ILogger<ExceptionFilterAttribute> logger;
        public ExceptionFilterAttribute(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<ExceptionFilterAttribute>();
        }

        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            string message;

            switch (exception)
            {
                default:
                    message = "An unexpected error occurred while performing the operation. Wait a few moments and try again.";
                    break;
            }

            logger.LogError(exception, message: message);

            context.Result = new JsonResult(new { message })
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
