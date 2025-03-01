using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Data.Entities;

public class AppUser : IdentityUser
{
    [MaxLength(50)]
    public required string FirstName { get; set; }
    
    [MaxLength(50)]
    public required string LastName { get; set; }
    
    public DateTime? Birthdate { get; set; }
    
    public DateTime CreatedOn { get; set; }
}