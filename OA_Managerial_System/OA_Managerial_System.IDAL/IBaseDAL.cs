using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace OA_Managerial_System.IDAL
{
    public interface IBaseDAL<T> where T:class,new()
    {
        //按条件查询
        IQueryable<T> LoadEnity(Expression<Func<T, bool>> where);
        //按条件分页
        IQueryable<T> PageEntity<s>(int pagesize, int pageindex, out int total, Expression<Func<T, bool>> where, Expression<Func<T, s>> orderbywhere, bool istrue);
        //添加用户信息
        T Addentity(T userinfo);
        //删除用户信息
        bool Deleteeneity(T userinfo);
        //修改用户信息
        bool Updateentity(T userinfo);
    }
}
