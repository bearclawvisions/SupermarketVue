using Supermarket.Domain.Dto.AppUser;
using Supermarket.Domain.Entities;

namespace Supermarket.Business.Services.Interface;

public interface IAppUserService
{
    Task<string> CreateNewUser(RegisterDto newUser);
    Task<AppUser> GetUserForLogin(LoginDto newUser);
}