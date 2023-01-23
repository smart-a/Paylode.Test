using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Paylode.Test.API.Config;
using Paylode.Test.API.Interfaces;
using Paylode.Test.API.ViewModel;

namespace Paylode.Test.API.Services;

public class AuthService : IAuthService
{
    private readonly JwtCredentials _jwt;

    public AuthService(IOptions<JwtCredentials> jwt)
    {
        _jwt = jwt.Value;
    }
    
    public AuthViewModel AuthLogin(string email)
    {
        if (email != "user@paylodeservices.com")
        {
            return new AuthViewModel(false, "Invalid login");
        }

        var token = GenerateAuthToken(email);
        return new AuthViewModel
        {
            Email = email,
            Token = token
        };
    }
    
    private string GenerateAuthToken(string email)
    {
        var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey));
        var signingCredential = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, email),
        };
        var expire = DateTime.Now.AddMinutes(int.Parse(_jwt.Lifetime));
        
        var token = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            expires:  expire,
            signingCredentials: signingCredential,
            claims: claims
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}