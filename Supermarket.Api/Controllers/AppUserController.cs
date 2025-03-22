using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Business.Services.Interface;
using Supermarket.Data.Database;
using Supermarket.Domain.Dto.Account;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Enums;

namespace Supermarket.Api.Controllers;

public class AppUserController : BaseController
{
    private readonly IAppUserService _appUserService;
    private readonly IAntiforgery _antiforgery;

    public AppUserController(IAppUserService appUserService, IAntiforgery antiforgery)
    {
        _appUserService = appUserService;
        _antiforgery = antiforgery;
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