namespace BWAF.Api.Controllers
{
    using BWAF.Core.ViewModels;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Net;

    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        private ILogger<ErrorsController> logger;

        public ErrorsController(ILogger<ErrorsController> logger)
        {
            this.logger = logger;
        }
        
        [Route("error")]
        public ErrorViewModel Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;

            Response.StatusCode = (int)GetErrorCode(exception); 
            
            return new ErrorViewModel(exception);
        }

        private HttpStatusCode GetErrorCode(Exception ex)
        {
            switch (ex)
            {
                case ArgumentNullException:
                    return HttpStatusCode.BadRequest;
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }

        private void LogExeption(ErrorViewModel error)
        {
            logger.LogError($"Type: {error.Type} \n " +
                $"Message: {error.Message} \n Inner Error Message: {error.InnerMessage} \n Stacktrace: {error.StackTrace}");
        }

    }
}
