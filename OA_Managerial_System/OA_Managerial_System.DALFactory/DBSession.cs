using OA_Managerial_System.DAL;
using OA_Managerial_System.IDAL;
using OA_Managerial_System.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Managerial_System.DALFactory
{
    /// <summary>
    /// 数据会话层,负责完成所有所有数据操作类实例的创建，然后业务层通过数据会话层来获取需要操作数据类的实例,实际上
    /// 就是将业务层和数据层进行解耦
    /// </summary>
    public partial class DBSession:IDBSession
    {
        public DbContext dbcontext
        {
            get
            {
                return DBContextFactory.CreateDbContext();
            }
        }
        //private IUserInfoDal userinfodal;
        //public IUserInfoDal _userinfodal
        //{
        //    get
        //    {
        //        if (userinfodal == null)
        //        {
        //            userinfodal = AbstractFactory.CreateIntanceDal();
        //        }
        //        return userinfodal;
        //    }
        //    set
        //    {
        //        userinfodal = value;

        //    }
        //}
        //希望只连接一次数据库对多张表进行操作
        public bool SaveChanges()
        {
            return dbcontext.SaveChanges() > 0;
        }
    }
}
