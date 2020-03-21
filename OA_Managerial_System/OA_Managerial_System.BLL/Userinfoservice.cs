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
        //public override void SetCurrentDal()
        //{

        //    CurrentDal = this.CurrentDBSession.UserInfoDal;
        //}
    }
}
