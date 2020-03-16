using System.Web;
using System.Web.Mvc;

namespace OA_Managerial_System.Webapp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
