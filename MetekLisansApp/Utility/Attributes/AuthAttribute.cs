using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MetekLisansApp.Utility;
using System.Linq;
using System.Threading.Tasks;

namespace MetekLisansApp.Utility.Attributes
{
    public class AuthAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string[] _roles;

        public AuthAttribute(string roles)
        {
            _roles = roles.Split(',', System.StringSplitOptions.RemoveEmptyEntries)
                          .Select(r => r.Trim())
                          .ToArray();
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var tokenHelper = context.HttpContext.RequestServices.GetService(typeof(TokenHelper)) as TokenHelper;
            if (tokenHelper == null)
            {
                context.Result = new ForbidResult();
                return;
            }

            bool isAuthenticated = await tokenHelper.CheckUserAuthhentication(context.HttpContext);
            if (!isAuthenticated)
            {
                context.Result = new ForbidResult();
                return;
            }

            var userRole = context.HttpContext.Session.GetString("UserRole");
            if (string.IsNullOrEmpty(userRole) || !_roles.Contains(userRole))
            {
                context.Result = new ForbidResult();
                return;
            }

            await next();
        }
    }
}
