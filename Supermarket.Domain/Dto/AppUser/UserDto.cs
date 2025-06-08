using Supermarket.Domain.Enums;

namespace Supermarket.Domain.Dto.AppUser;

public class UserDto
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public bool EmailConfirmed { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime LastLogin { get; set; }
    public List<ApplicationRole> Roles { get; set; } = [ApplicationRole.None];
}