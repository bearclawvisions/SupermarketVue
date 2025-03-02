using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Domain.Entities;

public class AppUserAddress
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [ForeignKey("AppUser")]
    public Guid UserId { get; set; }
    
    [MaxLength(30)]
    public required string StreetName { get; set; }
    
    [MaxLength(5)]
    public int HouseNumber { get; set; }
    
    [MaxLength(3)]
    public string? HouseNumberAppendix { get; set; }
    
    [MaxLength(25)]
    public required string City { get; set; }
    
    [MaxLength(6)]
    public required string ZipCode { get; set; }
    
    [MaxLength(255)]
    public string? Remarks { get; set; }
}