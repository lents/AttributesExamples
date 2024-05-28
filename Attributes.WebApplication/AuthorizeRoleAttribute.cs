using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Attributes.WebApplication
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,AllowMultiple = true)]
    public class AuthorizeRoleAttribute : Attribute, IAuthorizationFilter
    {
        public Roles Role { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context != null)
            {
                var rolesArray = Role.ToString().Split(new string[] { ", " }, StringSplitOptions.None);
                if (rolesArray.Any(r => context.HttpContext.User.IsInRole(r))) {
                    return;
                }
                context.Result = new ForbidResult();
            }
        }
    }

    public static class GetValueAttributeExtension { 
        public static string GetValueOfAttribute(this object o)
        {
            var attribute = Attribute.GetCustomAttribute(o.GetType(), typeof(AuthorizeRoleAttribute)) as AuthorizeRoleAttribute;
            if (attribute != null)
            {
                return attribute.Role.ToString();
            }
            return "Attribute is not applied";
        }

        public static string GetAllTypeAttribute(this object o)
        {
            var attributes = o.GetType().Attributes;
           
            return attributes.ToString();
        }
    }
}
