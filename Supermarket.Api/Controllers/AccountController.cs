using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Data.Database;
using Supermarket.Domain.Dto.Account;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Enums;

namespace Supermarket.Api.Controllers;

public class AccountController : BaseController
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SuperContext _context;

    public AccountController(UserManager<AppUser> userManager, 
        SignInManager<AppUser> signInManager, 
        RoleManager<IdentityRole> roleManager, SuperContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _context = context;
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public IActionResult Login()
    {
        return Ok();
    }
    
    [AllowAnonymous]
    [HttpPost("Register")]
    public IActionResult Register([FromBody] RegisterDto user)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return BadRequest(new { Errors = errors });
        }
        // return Ok(new { message = "User registered successfully!" });
        return Ok();
    }

    [HttpPost("Logout")]
    public IActionResult Logout()
    {
        return Ok();
    }
}