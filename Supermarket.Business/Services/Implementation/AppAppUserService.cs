using Microsoft.AspNetCore.Identity;
using Supermarket.Business.Services.Interface;
using Supermarket.Domain.Dto.Account;
using Supermarket.Domain.Entities;

namespace Supermarket.Business.Services.Implementation;

public class AppAppUserService : IAppUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AppAppUserService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    
    public async Task<string> CreateNewUser(RegisterDto newUser)
    {
        throw new NotImplementedException();
    }
}