using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
<<<<<<< HEAD
using Microsoft.Extensions.Logging;
=======
>>>>>>> 3778121 (Custom Exception Filter Added)
using System;
using System.Net;
using Taksimeter.RestApi.Models.Response;

namespace Taksimeter.RestApi.Common.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
<<<<<<< HEAD
        private readonly ILogger<ExceptionFilter> _logger;
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            ControllerActionDescriptor controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
=======
        public ExceptionFilter()
        {

        }
        public void OnException(ExceptionContext context)
        {
>>>>>>> 3778121 (Custom Exception Filter Added)
            int httpStatus;
            if (context.Exception is ArgumentNullException)
            {
                httpStatus = (int)HttpStatusCode.BadRequest;
            } 
            else
            {
                httpStatus = (int)HttpStatusCode.InternalServerError;
            }
            BaseRestResponseContainer<object> response = new BaseRestResponseContainer<object>
            {
                ErrorMessage = context.Exception.Message,
                IsSucceed = false,
                Response = null
            };

            ObjectResult result = new ObjectResult(response)
            {
                StatusCode = httpStatus
            };

            context.Result = result;
<<<<<<< HEAD
      
            _logger.LogInformation("Status Code : {statusCode} -- Exception Message : {excMsg} -- Method Name : {methodName}", httpStatus, context.Exception.Message.ToString(), controllerActionDescriptor.MethodInfo.Name);
=======
>>>>>>> 3778121 (Custom Exception Filter Added)
        }
    }
}
