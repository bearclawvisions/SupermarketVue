using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Business.Services.Interface;
using Supermarket.Domain.Dto.AppUser;
using Supermarket.Domain.Entities;

namespace Supermarket.Api.Controllers;

public class AppUserController : BaseController
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IAppUserService _appUserService;

    public AppUserController(IAppUserService appUserService, SignInManager<AppUser> signInManager)
    {
        _signInManager = signInManager;
        _appUserService = appUserService;
    }
    
    [AllowAnonymous]
    [HttpGet("GetXsrfToken")]
    public IActionResult GetXsrfToken()
    {
        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto userLogin)
    {
        try
        {
            var appUser = await _appUserService.GetUserForLogin(userLogin);
            await _signInManager.SignInAsync(appUser, false);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        

        return Ok("Successfully logged in.");
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