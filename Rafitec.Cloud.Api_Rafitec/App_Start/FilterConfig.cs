using System.Web;
using System.Web.Mvc;

namespace Rafitec.Cloud.Api_Rafitec
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
