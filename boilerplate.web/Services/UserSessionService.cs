using boilerplate.web.Models.Dto;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace boilerplate.web.Services
{
    public interface IUserSessionService
    {
        public bool IsLive { get; }
        LoggedInUser? GetUserSession();
        bool SetUserSession(LoggedInUser userSession);

        List<LoggeInUserRolePermission> GetRolePermissionSession();
        bool SetRolePermissionSession(List<LoggeInUserRolePermission> userSession);
    }

    public class UserSessionService : IUserSessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        string sessionUserObject = "SessionLoggedInUser";
        string sessionUserRolePermissionObject = "SessionUserRolePermission";
        public UserSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsLive
        {
            get => (_httpContextAccessor.HttpContext?.Session.Keys.Count() > 0);
        }

        public List<LoggeInUserRolePermission> GetRolePermissionSession()
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            if (session == null) return null;

            var userSessionJson = session.GetString(sessionUserRolePermissionObject);
            return string.IsNullOrEmpty(userSessionJson) ? null : JsonConvert.DeserializeObject<List<LoggeInUserRolePermission>>(userSessionJson);
        }

        public LoggedInUser GetUserSession()
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            if (session == null) return null;

            var userSessionJson = session.GetString(sessionUserObject);
            return string.IsNullOrEmpty(userSessionJson) ? null : JsonConvert.DeserializeObject<LoggedInUser>(userSessionJson);
        }

        public bool SetRolePermissionSession(List<LoggeInUserRolePermission> loggeInUserRolePermission)
        {
            if (loggeInUserRolePermission != null)
            {
                _httpContextAccessor.HttpContext?.Session.SetString(sessionUserRolePermissionObject, JsonConvert.SerializeObject(loggeInUserRolePermission));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetUserSession(LoggedInUser userSession)
        {
            if (userSession != null)
            {
                _httpContextAccessor.HttpContext?.Session.SetString(sessionUserObject, JsonConvert.SerializeObject(userSession));
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
