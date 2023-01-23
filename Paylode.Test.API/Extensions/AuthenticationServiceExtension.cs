using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Paylode.Test.API.Config;

namespace Paylode.Test.API.Extensions;

public static class AuthenticationServiceExtension
{
    public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration config)
    {
        var jwt = new JwtCredentials();
        config.GetSection("Jwt").Bind(jwt);
        
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                    
                ValidIssuer = jwt.Issuer,
                ValidAudience = jwt.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SecretKey)),
                ClockSkew = TimeSpan.Zero
            };
            options.Events = new JwtBearerEvents
            {
                OnChallenge = async (context) =>
                {
                    context.HandleResponse();
               
                    if (context.AuthenticateFailure != null)
                    {
                        context.Response.StatusCode = 401;
                        await context.HttpContext.Response.WriteAsJsonAsync(
                            new
                            {
                                Status = "Failed",
                                Message = "Token validation has failed. Request access denied!"
                            });
                    }
                }
            };
        });
    }
    
  
}