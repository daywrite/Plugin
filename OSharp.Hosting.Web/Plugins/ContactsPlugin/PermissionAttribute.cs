using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactsPlugin
{
    public class PermissionAttribute : ActionFilterAttribute
    {
        public const string NoPermissionView = "NoPermission";

        public string[] Permissions { get; private set; }
        public PermissionAttribute(params string[] permissions)
        {
            Permissions = permissions;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool hasPermission = false;
            foreach (var permission in Permissions)
            {
                hasPermission = BundleActivator.PermissionServiceTracker.DefaultOrFirstService.Check(BundleActivator.Bundle, permission);
                if (hasPermission)
                {
                    break;
                }
            }
            if (hasPermission)
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                filterContext.Result = new ViewResult { ViewName = NoPermissionView };
            }
        }
    }
}