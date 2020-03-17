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
    public class Userinfoservice : BaseService <UserInfo>,IUserinfoService
    {
     //批量删除
        public bool DleteuserInfo(List<int> arry)
        {
            var userinfoentity = this.currentdbsession._userinfodal.LoadEnity(u => arry.Contains(u.ID));
            foreach (var item in userinfoentity)
            {
                this.currentdbsession._userinfodal.Deleteeneity(item);
            }
            return currentdbsession.SaveChanges();
        }
        public override void SetCurrent()
        {

            currentdal = this.currentdbsession._userinfodal;
        }
    }
}
