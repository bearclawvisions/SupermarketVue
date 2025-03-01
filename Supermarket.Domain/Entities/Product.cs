using Supermarket.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Domain.Entities;

public class Product
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    
    [ForeignKey("ProductCategory")]
    public int CategoryId { get; set; }
    
    [MaxLength(50)]
    public required string Name { get; set; }
    
    [MaxLength(255)]
    public string? Description { get; set; }
    
    [MaxLength(25)]
    public string? ProductSize { get; set; }
    
    [Range(0, 10000)]
    public double Price { get; set; }
    
    public int Quantity { get; set; }
    
    public ProductStatus Status { get; set; }
    
    public DateTime? ExpiryDate { get; set; }
    
    public DateTime? DateCreated { get; set; }
    
    [ForeignKey("ApplicationUser")]
    [MaxLength(10)]
    public required string CreatedBy { get; set; }
    
    public DateTime? LastModifiedDate { get; set; }
    
    [ForeignKey("ApplicationUser")]
    [MaxLength(10)]
    public string? ModifiedBy { get; set; }
}