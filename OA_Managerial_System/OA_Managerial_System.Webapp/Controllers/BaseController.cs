using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA_Managerial_System.Webapp.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (Session["userinfo"] == null) {
                filterContext.HttpContext.Response.Redirect("/login/index");
            }
            
        }
    }
}