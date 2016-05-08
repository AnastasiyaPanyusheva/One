using System.Web;
using System.Web.Mvc;
using Pan_lab6.Models;
namespace Pan_lab6
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ActionFilter());
        }
    }
}
