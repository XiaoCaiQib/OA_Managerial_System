using OA_Managerial_System.Common;
using OA_Managerial_System.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA_Managerial_System.Webapp.Controllers
{

    public class LoginController : Controller
    {
        private IUserinfoService userinfoService;
        public LoginController(IUserinfoService _userinfoService)
        {
            userinfoService = _userinfoService;
        }
        public LoginController()
        {

        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowImg()
        {
            ValidateCode validateCode = new ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            Session["code"] = code;
            byte[] bt = validateCode.CreateValidateGraphic(code);
            return File(bt, "image/jpeg");

        }
        public ActionResult Login(string name, string pwd, string vcode)
        {
            string validatecode = Session["code"] == null ? string.Empty : Session["code"].ToString();
            if (validatecode==string.Empty)
            {
                return Redirect("~/Error.html");
            }
            Session["code"] = null;
            if (!validatecode.Equals(vcode, StringComparison.InvariantCultureIgnoreCase)) {
                return Redirect("~/Error.html");
            }
            else
            {
                var userinfo=userinfoService.LoadEnity(u => u.UName == name && u.UPwd == pwd).FirstOrDefault();
                if (userinfo == null)
                {
                    return Redirect("~/Error.html");
                }
                else {
                    Session["userinfo"] = userinfo;
                    return Content("ok");
                }
            }
        }
    }
}