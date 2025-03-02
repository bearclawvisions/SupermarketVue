using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Data.Database;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Enums;

namespace Supermarket.Api.Controllers;

public class AccountController : Controller
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

    [HttpGet("login")]
    public IActionResult Login()
    {
        return Ok();
    }
    
    [HttpGet("register")]
    public IActionResult Register()
    {
        return Ok();
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        var test = _context.Products.ToList();
        
        return Ok();
    }
}