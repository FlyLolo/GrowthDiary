using GrowthDiary.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FlyLolo.JWT.API.Authorize
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User.Claims.Any(m => m.Type.Equals("TokenType") && m.Value.Equals(TokenType.AccessToken.ToString())))
            {
                var code = context.User.Claims.FirstOrDefault(m => m.Type.Equals(ClaimTypes.NameIdentifier));
                if (null != code)
                {
                    UserPermissions userPermissions = requirement.UsePermissionList.FirstOrDefault(m => m.UserCode.Equals(code.Value.ToString()));
                    var routContext = (context.Resource as Microsoft.AspNetCore.Routing.RouteEndpoint);
                    
                    try
                    {
                        var x = context.Resource is AuthorizationFilterContext;
                        var Request = (context.Resource as AuthorizationFilterContext).HttpContext.Request;
                        if (null != userPermissions && userPermissions.Permissions.Any(m => m.Url.ToLower().Equals(Request.Path.Value.ToLower()) && m.Method.ToLower().Equals(Request.Method.ToLower())))
                        {
                            context.Succeed(requirement);
                        }
                        else
                        {
                            context.Fail();
                        }
                    }
                    catch (Exception ex)
                    {
                        var a = ex;
                        throw;
                    }
                    


                }
                else
                {
                    context.Fail();
                }
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
