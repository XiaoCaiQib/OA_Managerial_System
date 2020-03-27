using OA_Managerial_System.IBLL;
using OA_Managerial_System.Model;
using OA_Managerial_System.Model.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA_Managerial_System.Webapp.Controllers
{
    public class RoleInfoController : BaseController
    {
        public IRoleInfoService roleInfoService;
        public RoleInfoController(IRoleInfoService _roleInfoService)
        {
            roleInfoService = _roleInfoService;
        }
        // GET: RoleInfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetRoleInfoList() {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 1;
            int totalcount = 0;
            short delFlag = (short)DeleteType.Normarl;
            var userinfolist = roleInfoService.PageEntity<int>(pageSize, pageIndex, out totalcount, u => u.DelFlag == delFlag, c => c.ID, true);
            var temp = from u in userinfolist
                       select new
                       {
                           ID = u.ID,
                           RoleName = u.RoleName,
                           Sort = u.Sort,
                           Remark = u.Remark,
                       };
            return Json(new { rows = temp, total = totalcount }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddRoleinfo(RoleInfo roleInfo) {
            roleInfo.ModifiedOn = DateTime.Now;
            roleInfo.SubTime = DateTime.Now;
            roleInfo.DelFlag = 0;
            roleInfoService.Addentity(roleInfo);
            return Content("ok");

        }
    }
}