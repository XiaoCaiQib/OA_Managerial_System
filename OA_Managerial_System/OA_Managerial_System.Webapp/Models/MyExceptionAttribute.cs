using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA_Managerial_System.Webapp.Models
{
    public class MyExceptionAttribute:HandleErrorAttribute
    {
        public static Queue<Exception> queue = new Queue<Exception>();
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Exception ex = filterContext.Exception;
            queue.Enqueue(ex);
            filterContext.HttpContext.Response.Redirect("/Error.html");
        }
    }
}