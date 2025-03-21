using Microsoft.AspNetCore.Identity;
using Supermarket.Business.Services.Interface;
using Supermarket.Domain.Dto.Account;
using Supermarket.Domain.Entities;

namespace Supermarket.Business.Services.Implementation;

public class AppAppUserService : IAppUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AppAppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }
    
    public async Task<string> CreateNewUser(RegisterDto newUser)
    {
        throw new NotImplementedException();
    }
}