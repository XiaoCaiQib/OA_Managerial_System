using OA_Managerial_System.IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Managerial_System.IDAL
{

        /// <summary>
        /// 业务层调用会话层的接口
        /// </summary>
        public partial interface IDBSession
        {
            DbContext dbcontext { get; }
          //  IUserInfoDal _userinfodal { get; set; }
            bool SaveChanges();

        
    }
}
