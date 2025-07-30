using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using boilerplate.web.Models;

namespace boilerplate.web
{
    public class MyAuthorization : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (filterContext.HttpContext.Session.GetString("email") == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "controller", "Account" }, { "action", "Login" } });
                return;
            }

            var access_permission = JsonConvert.DeserializeObject<List<MPermissions>>(filterContext.HttpContext.Session.GetString("access_permission"));
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            string url = "/" + controllerName + "/" + actionName;

            if (!access_permission.Where(s => s.Url == url).Any())

            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "controller", "Account" }, { "action", "Login" } });
                return;
            }
        }
    }
}
