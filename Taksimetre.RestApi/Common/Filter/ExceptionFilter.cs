using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using Taksimeter.RestApi.Models.Response;

namespace Taksimeter.RestApi.Common.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        public ExceptionFilter()
        {

        }
        public void OnException(ExceptionContext context)
        {
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
        }
    }
}
