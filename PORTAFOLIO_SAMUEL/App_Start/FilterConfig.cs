using System.Web;
using System.Web.Mvc;

namespace PORTAFOLIO_SAMUEL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
