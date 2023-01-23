using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Paylode.Test.API.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute  : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var claims = context.HttpContext.User.Claims.ToList();
        var email = claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        
        if (string.IsNullOrEmpty(email))
        {
            // login user not authorized/ user not login
            context.Result = new JsonResult(new 
            { 
                Status = "Failed", 
                Message = "Unauthorized User!" 
            })
            {
                StatusCode = StatusCodes.Status403Forbidden
            };
        }
    }
}