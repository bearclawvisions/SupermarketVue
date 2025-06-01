using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Business.Services.Interface;
using Supermarket.Domain.Dto.AppUser;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Enums;

namespace Supermarket.Api.Controllers;

public class AppUserController : BaseController
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IAppUserService _appUserService;
    private readonly UserManager<AppUser> _userManager;

    public AppUserController(IAppUserService appUserService, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _signInManager = signInManager;
        _appUserService = appUserService;
        _userManager = userManager;
    }
    
    [AllowAnonymous]
    [HttpGet(nameof(GetXsrfToken))]
    public IActionResult GetXsrfToken()
    {
        return Ok();
    }

    [AllowAnonymous]
    [HttpPost(nameof(Login))]
    public async Task<IActionResult> Login([FromBody] LoginDto userLogin)
    {
        try
        {
            var appUser = await _appUserService.GetUserForLogin(userLogin);
            await _signInManager.SignInAsync(appUser, false); // todo op true zetten
            
            var userRoles = await _appUserService.GetUserRoles(appUser);
            
            return Ok(userRoles.First());
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [AllowAnonymous]
    [HttpGet(nameof(AuthenticateUser))]
    public async Task<IActionResult> AuthenticateUser()
    {
        var appUser = await _appUserService.AuthenticateUser(User);

        if (appUser == null)
            return Ok(ApplicationRole.None);
        
        var userRoles = await _appUserService.GetUserRoles(appUser);
        return Ok(userRoles.First());
    }
    
    [AllowAnonymous]
    [RequireAntiforgeryToken]
    [HttpPost(nameof(Register))]
    public async Task<IActionResult> Register([FromBody] RegisterDto user)
    {
        var result =  await _appUserService.CreateNewUser(user);
        
        if (!ModelState.IsValid)
        {
            return BadRequest(result);
        }
        
        return Ok(result);
    }

    [HttpPost(nameof(Logout))]
    public IActionResult Logout()
    {
        _signInManager.SignOutAsync();
        
        return Ok("Successfully logged out.");
    }
}