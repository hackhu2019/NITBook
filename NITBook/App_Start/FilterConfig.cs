using System.Web;
using System.Web.Mvc;
using NITBook.Filter; // 引入

namespace NITBook
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new IsAuthorizeAttribute());
        }
    }
}
