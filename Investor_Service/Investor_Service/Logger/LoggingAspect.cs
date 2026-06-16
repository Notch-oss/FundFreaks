using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Investor_Service.Logger
{
    public class LoggingAspect : ActionFilterAttribute
    {
        readonly string logFilePath;
        DateTime startTime;

        [Obsolete]
        public LoggingAspect(IHostingEnvironment environment)
        {
            logFilePath = environment.ContentRootPath + @"/LogFile.txt";


        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                using var streamWriter = new StreamWriter(logFilePath, true);
                startTime = DateTime.Now;
                var controllerBase = (ControllerBase)context.Controller;
                var controllerName = controllerBase.ControllerContext.ActionDescriptor.ControllerName;
                var actionName = controllerBase.ControllerContext.ActionDescriptor.ActionName;

                streamWriter.Write($"ControllerName:::{controllerName}\t" +
                     $"ActionName:::{actionName}\t StartTime:::{startTime}\t");
            }
            catch (Exception ex)
            {
                // Log to console if file logging fails
                Console.WriteLine($"Logging error: {ex.Message}");
            }
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            try
            {
                using var streamWriter = new StreamWriter(logFilePath, true);
                var endTime = DateTime.Now;
                var totalTime = endTime - startTime;
                streamWriter.Write($"\tTotal Time :::{totalTime.TotalMilliseconds}\n");
            }
            catch (Exception ex)
            {
                // Log to console if file logging fails
                Console.WriteLine($"Logging error: {ex.Message}");
            }
        }
    }
}
