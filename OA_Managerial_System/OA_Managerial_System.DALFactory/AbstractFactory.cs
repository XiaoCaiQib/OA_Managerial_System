using OA_Managerial_System.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OA_Managerial_System.DALFactory
{
    /// <summary>
    /// 反射加载程序集，创建数据层接口实例
    /// </summary>
   public  class AbstractFactory
    {
        //命名空间
        private static readonly string NameSpace = ConfigurationManager.AppSettings["NameSpace"];
        //程序集信息
        private static readonly string AssembyPath = ConfigurationManager.AppSettings["AssembyPath"];
        public static IUserInfoDal CreateIntanceDal() {
            string fullNamespance = NameSpace + ".UserInfoDAL";
         return   CreateIntance(fullNamespance) as IUserInfoDal;
         
        }
        private static object CreateIntance(string fullNamespance) {
          var assembly=   Assembly.Load(AssembyPath);
          var obj=  assembly.CreateInstance(fullNamespance);
            return obj;
        }

    }
}
