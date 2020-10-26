using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace AdventureWorks.Web.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly ILogger logger;

        public ExceptionFilter(IWebHostEnvironment hostingEnvironment, ILogger logger)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            logger.LogDebug(context.Exception, "The exception has occured and been succesfully handled");

            context.ExceptionHandled = true;
        }
    }
}