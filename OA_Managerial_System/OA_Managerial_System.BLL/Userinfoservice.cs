using OA_Managerial_System.IBLL;
using OA_Managerial_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Managerial_System.BLL
{
    /// <summary>
    /// 业务类
    /// </summary>
    public partial class UserInfoService : BaseService <UserInfo>,IUserinfoService
    {
     //批量删除
        public bool DleteuserInfo(List<int> arry)
        {
            var userinfoentity = this.CurrentDBSession.UserInfoDal.LoadEnity(u => arry.Contains(u.ID));
            foreach (var item in userinfoentity)
            {
                this.CurrentDBSession.UserInfoDal.Deleteeneity(item);
            }
            return CurrentDBSession.SaveChanges();
        }

        /// <summary>
        /// 为用户分配角色
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="roleIdList">要分配的角色的编号</param>
        /// <returns></returns>
        public bool SetUserRoleInfo(int userId, List<int> roleIdList)
        {
            var userInfo = this.CurrentDBSession.UserInfoDal.LoadEnity(u => u.ID == userId).FirstOrDefault();//根据用户的编号查找用户的信息
            if (userInfo != null)
            {
                userInfo.RoleInfo.Clear();
                foreach (int roleId in roleIdList)
                {
                    var roleInfo = this.CurrentDBSession.RoleInfoDal.LoadEnity(r => r.ID == roleId).FirstOrDefault();
                    userInfo.RoleInfo.Add(roleInfo);
                }
                return this.CurrentDBSession.SaveChanges();
            }
            return false;

        }
        //public override void SetCurrentDal()
        //{

        //    CurrentDal = this.CurrentDBSession.UserInfoDal;
        //}
    }
}
