using OA_Managerial_System.DAL;
using OA_Managerial_System.DALFactory;
using OA_Managerial_System.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA_Managerial_System.BLL
{
    /// <summary>
    /// 业务会话层
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseService<T> where T : class, new()
    {
        public  IDBSession currentdbsession
        {
            get
            {
                return DBSessionFactory.CreateDBSession();
            }
        }
        public IBaseDAL<T> currentdal { get; set; }
        public abstract void SetCurrent();
        public BaseService()
        {
            //子类必须实现抽象方法
            SetCurrent();
        }
        //加载用户信息
        public IQueryable<T> LoadEnity(Expression<Func<T, bool>> where) {
            return currentdal.LoadEnity(where);
        }
        public T Addentity(T entry)
        {

             currentdal.Addentity(entry);
            return entry;
        }
        //删除用户信息
        public bool Deleteeneity(T entry)
        {
            currentdal.Deleteeneity(entry);
            return currentdbsession.SaveChanges();
        }
        //分页加载
        public IQueryable<T> PageEntity<s>(int pagesize, int pageindex, out int total, Expression<Func<T, bool>> where, Expression<Func<T, s>> orderbywhere, bool istrue)
        {
            return currentdal.PageEntity<s>(pagesize,pageindex,out total,where,orderbywhere,istrue);

        }
        //修改用户信息
        public bool Updateentity(T entry)
        {
            currentdal.Updateentity(entry);
            return currentdbsession.SaveChanges();
        }
    }
}
