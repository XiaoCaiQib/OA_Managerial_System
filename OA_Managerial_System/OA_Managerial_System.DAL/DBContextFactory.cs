using OA_Managerial_System.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace OA_Managerial_System.DAL
{
    public class DBContextFactory
    {
        public static DbContext CreateDbContext()
        {
            DbContext db = (DbContext)CallContext.GetData("dbcontext");
            if (db == null)
            {
                db = new OAEntities();
                CallContext.SetData("dbcontext", db);
            }
            return db;
        }
    }
}
