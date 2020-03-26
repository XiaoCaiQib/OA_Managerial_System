using OA_Managerial_System.BLL;
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
        public ActionResult GetRoleinfoList() {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["Rows"] != null ? int.Parse(Request["Rows"]) : 5;
            int total = 0;
            short delFlag = (short)DeleteType.Normarl;
          var roleinfos=  roleInfoService.PageEntity(pageSize, pageIndex, out total, r => r.DelFlag == delFlag, r => r.ID, true);
            var rows = from role in roleinfos
                       select new
                       {
                           ID = role.ID,
                           RoleName = role.RoleName,
                           Remark = role.Remark,
                           SubTime = role.SubTime
                       };
            return Json(new {rows, total });
        }
        public ActionResult AddRoleInfo(RoleInfo role) {
          
                role.SubTime = DateTime.Now;
                role.ModifiedOn = DateTime.Now;
                role.DelFlag = 0;
                roleInfoService.Addentity(role);
                return Content("ok");
          
         
          
        }
        public ActionResult DeleteInfo(int strId) {
            var roleinfo = roleInfoService.LoadEnity(r => r.ID == strId).FirstOrDefault();
            if (roleInfoService.Deleteeneity(roleinfo))
            {
                return Content("ok");
            }
            else
            {
                return Content("No");
            }
        }
    }
}