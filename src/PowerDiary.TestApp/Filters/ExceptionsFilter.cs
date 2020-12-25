using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using PowerDiary.TestApp.Core;
using System.Net;

namespace PowerDiary.TestApp.Web.Filters
{
    public class ExceptionsFilter: IExceptionFilter
    {
        private readonly ILogger<ExceptionsFilter> _logger;

        public ExceptionsFilter(ILogger<ExceptionsFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            context.ExceptionHandled = true;
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";

            var friendlyException = context.Exception as UserFriendlyException;

            context.Result = new JsonResult(new { Message = friendlyException != null ? friendlyException.Message : "Uknown Error" });
        }
    }
}
