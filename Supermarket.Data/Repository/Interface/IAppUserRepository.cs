using Supermarket.Domain.Dto.AppUser;
using Supermarket.Domain.Entities;

namespace Supermarket.Data.Repository.Interface;

public interface IAppUserRepository : IRepository<AppUser>
{
    Task<List<UserDto>> GetAllUsersAsync();
}