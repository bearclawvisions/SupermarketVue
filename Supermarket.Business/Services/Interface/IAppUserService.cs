using Supermarket.Domain.Dto.AppUser;

namespace Supermarket.Business.Services.Interface;

public interface IAppUserService
{
    Task<string> CreateNewUser(RegisterDto newUser);
}