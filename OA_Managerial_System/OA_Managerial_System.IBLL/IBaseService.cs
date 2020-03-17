using OA_Managerial_System.DAL;
using OA_Managerial_System.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA_Managerial_System.IBLL
{
    public interface IBaseService<T> where T:class,new()
    {
        IDBSession currentdbsession { get; }
        IBaseDAL<T> currentdal { get; set; }
        IQueryable<T> LoadEnity(Expression<Func<T, bool>> where);
        T Addentity(T entry);
        bool Deleteeneity(T entry);
        IQueryable<T> PageEntity<s>(int pagesize, int pageindex, out int total, Expression<Func<T, bool>> where, Expression<Func<T, s>> orderbywhere, bool istrue);
        bool Updateentity(T entry);
    }
}
