using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace YourBeautyEstetica.MVC.Extensions
{
    public class CustomAuthorize
    {
        public static bool ValidarRolesUsuario(HttpContext context, string role)
        {
            return context.User.Identity.IsAuthenticated
                && context.User.IsInRole(role);
        }
    }

    public class RoleAuthorizeAttribute : TypeFilterAttribute
    {
        public RoleAuthorizeAttribute(string role) : base(typeof(RequisitoRoleFilter))
        {
            Arguments = new object[] { role };
        }
    }

    public class RequisitoRoleFilter : IAuthorizationFilter
    {
        private readonly string _role;

        public RequisitoRoleFilter(string role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { area = "Identity", page = "/Account/Login", ReturnUrl = context.HttpContext.Request.Path.ToString() }));
                return;
            }

            if (!CustomAuthorize.ValidarRolesUsuario(context.HttpContext, _role))
            {
                context.Result = new StatusCodeResult(404);
            }
        }
    }
}