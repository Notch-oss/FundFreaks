
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace UserAuthenticationService.Logging
{
    public class Logger:ActionFilterAttribute
    {

            readonly string logFilePath;
            DateTime startTime;
            public Logger(IHostingEnvironment environment)
            {
                logFilePath = environment.ContentRootPath + @"/LogFile.txt";

            }
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                using (StreamWriter streamWriter = new StreamWriter(logFilePath, true))
                {
                    startTime = DateTime.Now;
                    ControllerBase controllerBase = (ControllerBase)context.Controller;
                    string controllerName = controllerBase.ControllerContext.ActionDescriptor.ControllerName;
                    string actionName = controllerBase.ControllerContext.ActionDescriptor.ActionName;

                    streamWriter.Write($"ControllerName:::{controllerName}\t" +
                         $"ActionName:::{actionName}\t StartTime:::{startTime}\t");
                    streamWriter.Close();
                }

            }
            public override void OnActionExecuted(ActionExecutedContext context)
            {
                using (StreamWriter streamWriter = new StreamWriter(logFilePath, true))
                {

                    DateTime endTime = DateTime.Now;
                    TimeSpan totalTime = endTime - startTime;
                    streamWriter.Write($"\tTotal Time :::{totalTime.TotalMilliseconds}\n");
                    streamWriter.Close();


                }
            }
        }
}
