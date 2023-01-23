using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Paylode.Test.API.Interfaces;

namespace Paylode.Test.API.Controllers;

public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("login")]
    public IActionResult Login([EmailAddress] string email)
    {
        var result = _authService.AuthLogin(email);
        return result.IsSuccess ? 
            Ok(result) : BadRequest(result);
    }
}