using OA_Managerial_System.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace OA_Managerial_System.DALFactory
{
    /// <summary>
    /// DBSession线程内唯一
    /// </summary>
    public class DBSessionFactory
    {
        public static IDBSession CreateDBSession()
        {
            IDBSession DBSession = (IDBSession)CallContext.GetData("DBSession");
            if (DBSession == null)
            {
                DBSession = new DBSession();
                CallContext.SetData("DBSession", DBSession);
            }
            return DBSession;
        }
    }


}
