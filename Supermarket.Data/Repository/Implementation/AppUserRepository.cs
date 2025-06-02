using Supermarket.Data.Database;
using Supermarket.Data.Repository.Interface;
using Supermarket.Domain.Entities;

namespace Supermarket.Data.Repository.Implementation;

public class AppUserRepository(SuperContext context) : Repository<AppUser>(context), IAppUserRepository
{
    private readonly SuperContext _context = context;
}