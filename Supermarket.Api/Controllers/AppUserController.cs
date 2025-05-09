﻿using Microsoft.AspNetCore.Antiforgery;
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
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        

        return Ok("Successfully logged in.");
    }
    
    [AllowAnonymous]
    [HttpGet(nameof(AuthenticateUser))]
    public async Task<IActionResult> AuthenticateUser()
    {
        var user = await _appUserService.AuthenticateUser(User);
        // var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return Unauthorized();
        }

        return Ok("Authenticated");
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