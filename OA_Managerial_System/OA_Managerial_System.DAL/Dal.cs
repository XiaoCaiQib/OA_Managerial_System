 

using OA_Managerial_System.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA_Managerial_System.Model;
using System.Linq.Expressions;

namespace OA_Managerial_System.DAL
{
		
	public partial class ActionInfoDal :BaseDAL<ActionInfo>,IActionInfoDal
    {

    }
		
	public partial class DepartmentDal :BaseDAL<Department>,IDepartmentDal
    {

    }
		
	public partial class R_UserInfo_ActionInfoDal :BaseDAL<R_UserInfo_ActionInfo>,IR_UserInfo_ActionInfoDal
    {

    }
		
	public partial class RoleInfoDal :BaseDAL<RoleInfo>,IRoleInfoDal
    {

    }
		
	public partial class UserInfoDal :BaseDAL<UserInfo>,IUserInfoDal
    {

    }
	
}