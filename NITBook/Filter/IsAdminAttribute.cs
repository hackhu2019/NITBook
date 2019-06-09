using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NITBook.Filter
{
    public class IsAdminAttribute: AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary {
                    { "controller","Reader"},
                    { "action","Index"}
                });
        } // 若权限不足则返回主界面

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.Session["root"].ToString().Equals("admin");
        }
    }
}