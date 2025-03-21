using Supermarket.Domain.Dto.Account;

namespace Supermarket.Business.Services.Interface;

public interface IAppUserService
{
    Task<string> CreateNewUser(RegisterDto newUser);
}