using Microsoft.EntityFrameworkCore;
using Supermarket.Data.Database;
using Supermarket.Data.Repository.Interface;
using Supermarket.Domain.Dto.AppUser;
using Supermarket.Domain.Entities;

namespace Supermarket.Data.Repository.Implementation;

public class AppUserRepository(SuperContext context) : Repository<AppUser>(context), IAppUserRepository
{
    private readonly SuperContext _context = context;

    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        var result = await _context.AppUsers.Select(user => new UserDto
        {
            Id = Guid.Parse(user.Id),
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email ?? "no email",
            EmailConfirmed = user.EmailConfirmed,
            CreatedOn = user.CreatedOn.Date,
            LastLogin = user.LastLogin.Date,
        }).ToListAsync();

        return result;
    }
}