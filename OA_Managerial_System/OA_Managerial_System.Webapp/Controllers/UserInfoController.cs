using OA_Managerial_System.BLL;
using OA_Managerial_System.IBLL;
using OA_Managerial_System.Model.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA_Managerial_System.Webapp.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: UserInfo
        IUserinfoService userinfoService = new Userinfoservice();
        public ActionResult Index()
        {

            return View();
        }
        //加载数据
        public ActionResult GetUserInfoList()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 1;
            int totalcount=0;
            short delFlag = (short)DeleteType.Normarl;
            var userinfolist = userinfoService.PageEntity<int>(pageSize, pageIndex, out totalcount, u => u.DelFlag== delFlag, c => c.ID, true);
            var temp = from u in userinfolist
                       select new
                       {
                           ID=u.ID,
                           UName = u.UName,
                           UPwd = u.UPwd,
                           Remark = u.Remark,
                           SubTime=u.SubTime
                       };
            return Json(new { rows = temp, total = totalcount },JsonRequestBehavior.AllowGet);
        }
        //删除数据
        public ActionResult DeleteInfo()
        {
            var rowsId = Request["strId"];
            var  rows = rowsId.Split(',');
            List<int> arry = new List<int>();
            foreach (var id in rows) {
                arry.Add(int.Parse(id));
            }
            if (userinfoService.DleteuserInfo(arry))
            {
                return Content("ok");
            }
            else {
                return Content("No");
            }

        }
    }
}