using Supermarket.Domain.Dto.AppUser;
using Supermarket.Domain.Entities;
using System.Security.Claims;

namespace Supermarket.Business.Services.Interface;

public interface IAppUserService
{
    Task<string> CreateNewUser(RegisterDto newUser);
    Task<AppUser> GetUserForLogin(LoginDto newUser);
    Task<AppUser?> AuthenticateUser(ClaimsPrincipal user);
}