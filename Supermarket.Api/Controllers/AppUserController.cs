using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Business.Services.Interface;
using Supermarket.Domain.Dto.Account;

namespace Supermarket.Api.Controllers;

public class AppUserController : BaseController
{
    private readonly IAppUserService _appUserService;

    public AppUserController(IAppUserService appUserService)
    {
        _appUserService = appUserService;
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public IActionResult Login()
    {
        return Ok();
    }
    
    [AllowAnonymous]
    [RequireAntiforgeryToken]
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto user)
    {
        var result =  await _appUserService.CreateNewUser(user);
        
        if (!ModelState.IsValid)
        {
            return BadRequest(result);
        }
        // return Ok(new { message = "User registered successfully!" });
        return Ok(result);
    }

    [HttpPost("Logout")]
    public IActionResult Logout()
    {
        return Ok();
    }
}