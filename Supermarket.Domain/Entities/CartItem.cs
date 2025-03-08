using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Domain.Entities;

public class CartItem
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [ForeignKey("Cart")]
    public int CartId { get; set; }
    
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    
    public int Quantity { get; set; }
    
    [Range(0, 10000)]
    public double TotalPrice { get; set; }
}