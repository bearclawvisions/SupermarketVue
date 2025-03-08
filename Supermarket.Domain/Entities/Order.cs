using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Domain.Entities;

public class Order
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [ForeignKey("AppUser")]
    public int AppUserId { get; set; }
    
    public DateTime? OrderDate { get; set; }
    
    [Range(0, 10000)]
    public double TotalPrice { get; set; }
}