using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Portal.Handler
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class StudentPortalAuthorizeAttribute: AuthorizeAttribute, IAuthorizationFilter
    {
        private string[] AllowedPermissions { get; set; }

        public StudentPortalAuthorizeAttribute()
        {
            AllowedPermissions = null;
        }

        public StudentPortalAuthorizeAttribute(string someFilterParameter)
        {
            AllowedPermissions = someFilterParameter.Split(',');
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!context.Filters.Contains(new StudentPortalAllowAnonymousAttribute()))
            {
                if (!user.Identity.IsAuthenticated)
                {
                    context.Result = new JsonResult("Access is denied") { StatusCode = 401 };
                    return;
                }
                else
                {
                    if (AllowedPermissions != null)
                    {
                        if (!isAuthorized(context))
                        {
                            context.Result = new JsonResult("Sorry! You have no permission to access") { StatusCode = 403 };
                            return;
                        }
                    }

                    return;
                }
            }
        }

        private bool isAuthorized(AuthorizationFilterContext context)
        {
            // Customized Permission Logic Here Md. Nahid Hasan           

            //var actionName = context.ActionDescriptor.RouteValues.Where(p => p.Key == "action").Select(p => p.Value).FirstOrDefault();
            //var controllerName = context.ActionDescriptor.RouteValues.Where(p => p.Key == "controller").Select(p => p.Value).FirstOrDefault();

            //if(actionName.Equals("Login") && controllerName.Equals("Security"))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            foreach (var perm in AllowedPermissions)
            {
                if (HasPermission(perm, context.HttpContext))
                {
                    return true;
                }
            }
            return false;
        }

        private bool HasPermission(string permission, HttpContext context)
        {
            var result = context.User.IsInRole(permission);
            return result;
        }
    }
}
