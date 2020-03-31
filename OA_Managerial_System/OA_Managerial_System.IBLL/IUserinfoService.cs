using OA_Managerial_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Managerial_System.IBLL
{
    public interface IUserinfoService:IBaseService<UserInfo>
    {
        bool DleteuserInfo(List<int> arry);
        bool SetUserRoleInfo(int userId, List<int> roleIdList);
        //"Istrue": Istrue, "UserId": UserId, actionId: actionId
        bool SetUserAction(int userid, int actionId, bool Istrue);
    }
}
