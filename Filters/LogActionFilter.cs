using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace FilterExample.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {

            string actionName = context.ActionDescriptor.DisplayName;
            string logMessage = $"Method: {actionName}, Time: {DateTime.Now}\n";

            File.AppendAllText("ActionLog.txt", logMessage);

            base.OnActionExecuted(context);
        }
    }
}
