using OA_Managerial_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA_Managerial_System.DAL
{
    public  class BaseDAL<T> where T:class,new()
    {
        OAEntities db =(OAEntities)DBContextFactory.CreateContext();
        //添加用户信息
        public T Addentity(T entry)
        {

            T Userinfo = db.Set<T>().Add(entry);
            return entry;
        }
        //删除用户信息
        public bool Deleteeneity(T entry)
        {
            db.Set<T>().Remove(entry);
            return true;
        }
        //加载用户信息
        public IQueryable<T> LoadEnity(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().Where<T>(where);
        }
        //分页加载
        public IQueryable<T> PageEntity<s>(int pagesize, int pageindex, out int total, Expression<Func<T, bool>> where, Expression<Func<T, s>> orderbywhere, bool istrue)
        {
            var entity = db.Set<T>().Where<T>(where);
            total = entity.Count();
            if (istrue)
            {
                entity = entity.OrderBy<T, s>(orderbywhere).Skip((pageindex-1) * pagesize).Take<T>(pagesize);
            }
            else
            {
                entity = entity.OrderByDescending<T, s>(orderbywhere).Skip((pageindex-1) * pagesize).Take<T>(pagesize);
            }
            return entity;

        }
        //修改用户信息
        public bool Updateentity(T entry)
        {
            db.Entry<T>(entry).State = System.Data.EntityState.Modified;
            return true;
        }
    }
}
