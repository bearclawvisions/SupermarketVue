using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Domain.Entities;

public class Audit
{
    public DateTime? DateCreated { get; set; }
    
    [ForeignKey("ApplicationUser")]
    [MaxLength(10)]
    public required string CreatedBy { get; set; }
    
    public DateTime? LastModifiedDate { get; set; }
    
    [ForeignKey("ApplicationUser")]
    [MaxLength(10)]
    public string? ModifiedBy { get; set; }
}