using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;

namespace FilterExample.Filters
{
    public class UniqueUserFilter : ActionFilterAttribute
    {
        private static HashSet<string> uniqueUsers = new HashSet<string>();

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userIP = context.HttpContext.Connection.RemoteIpAddress?.ToString();

            if (!string.IsNullOrEmpty(userIP) && uniqueUsers.Add(userIP))
            {
                File.WriteAllText("UniqueUsersCount.txt", $"Unique users: {uniqueUsers.Count}");
            }

            base.OnActionExecuting(context);
        }
    }
}
