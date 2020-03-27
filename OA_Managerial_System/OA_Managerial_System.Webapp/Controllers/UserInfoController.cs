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
    public class UserInfoController : BaseController
    {
        public IUserinfoService userinfoService;
        public IRoleInfoService roleInfoService;
        public UserInfoController(IUserinfoService _userinfoService,IRoleInfoService _roleInfoService)
        {
            userinfoService = _userinfoService;
            roleInfoService = _roleInfoService;
        }
        // GET: UserInfo
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
        //添加用户信息
        public ActionResult AddUserInfo(UserInfo userinfo) {
            userinfo.DelFlag = 0;
            userinfo.SubTime = DateTime.Now;
            userinfo.ModifiedOn = DateTime.Now;
            userinfoService.Addentity(userinfo);
            return Content("ok");
        }
        //展示要修改的用户数据
        public ActionResult ShowUserinfo() {
            int id = int.Parse(Request["id"]);
            var userinfo = userinfoService.LoadEnity(u => u.ID == id).FirstOrDefault();
            return Json(userinfo);
        }
        //修改用户列表数据
        public ActionResult EditUserinfo(  UserInfo userinfo) {
            userinfo.ModifiedOn = DateTime.Now;
            userinfo.SubTime = DateTime.Now;
            if (userinfoService.Updateentity(userinfo)) {
                return Content("ok");
            }
            else
            {
                return Content("fail");
            }
          
        }
        //展示用户已有的角色
        public ActionResult ShowUserRoleInfo()
        {
            int id = int.Parse(Request["id"]);
            var userInfo = userinfoService.LoadEnity(u => u.ID == id).FirstOrDefault();
            ViewBag.UserInfo = userInfo;
            //查询所有的角色.
            short delFlag = (short)DeleteType.Normarl;
            var allRoleList = roleInfoService.LoadEnity(r => r.DelFlag == delFlag).ToList();
            //查询一下要分配角色的用户以前具有了哪些角色编号。
            var allUserRoleIdList = (from r in userInfo.RoleInfo
                                     select r.ID).ToList();
            ViewBag.AllRoleList = allRoleList;
            ViewBag.AllUserRoleIdList = allUserRoleIdList;
            return View();
        }
    }
}