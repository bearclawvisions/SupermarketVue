using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Business.Services.Interface;
using Supermarket.Domain.Dto.AppUser;

namespace Supermarket.Api.Controllers;

public class AppUserController : BaseController
{
    private readonly IAppUserService _appUserService;

    public AppUserController(IAppUserService appUserService)
    {
        _appUserService = appUserService;
    }
    
    [AllowAnonymous]
    [HttpGet("GetSuperMarketCookie")]
    public IActionResult GetSuperMarketCookie()
    {
        // Response.Cookies.Append("TestCookie", "Hello", new CookieOptions
        // {
        //     HttpOnly = true,
        //     Secure = true,
        //     SameSite = SameSiteMode.None
        // });
        return Ok();
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
        
        return Ok(result);
    }

    [HttpPost("Logout")]
    public IActionResult Logout()
    {
        return Ok();
    }
}