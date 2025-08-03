using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using boilerplate.web.Models;
using boilerplate.web.Services;

namespace boilerplate.web
{
    public class MyAuthorization : ActionFilterAttribute
    {
        private readonly IUserSessionService _userSessionService;

        public MyAuthorization(IUserSessionService userSessionService)
        {
            _userSessionService = userSessionService;
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var controllerName = filterContext.RouteData.Values["controller"].ToString().ToLower();
            var actionName = filterContext.RouteData.Values["action"].ToString().ToLower();

            if (controllerName.ToString() != "auth" && controllerName.ToString() != "home")
            {
                if (_userSessionService.IsLive == false)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Auth" }, { "action", "Login" } });
                    return;
                }
                else
                {
                    var loggedInUserRolePermission = _userSessionService.GetRolePermissionSession();
                    if (!loggedInUserRolePermission.Where(s => s.ModuleName.ToLower() == controllerName && s.ActionName.ToLower() == actionName).Any())
                    {
                        filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary { { "controller", "Home" }, { "action", "AccessDenied" } });
                        return;
                    }

                }
            }
            //var access_permission = JsonConvert.DeserializeObject<List<MPermissions>>(filterContext.HttpContext.Session.GetString("access_permission"));
            //string url = "/" + controllerName + "/" + actionName;
            //if (!access_permission.Where(s => s.Url == url).Any())
            //{
            //    filterContext.Result = new RedirectToRouteResult(
            //        new RouteValueDictionary { { "controller", "Account" }, { "action", "Login" } });
            //    return;
            //}
        }
    }
}
