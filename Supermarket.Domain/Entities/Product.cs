﻿using Supermarket.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace Supermarket.Domain.Entities;

public class Product : Audit
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [ForeignKey("ProductCategory")]
    public int CategoryId { get; set; }
    
    [MaxLength(50)]
    public required string Name { get; set; }
    
    [Column(TypeName = "xml")]
    public required string Metadata { get; set; } // xml
    
    [Range(0, 10000)]
    public double Price { get; set; }
    
    public int Quantity { get; set; }
    
    public ProductStatus Status { get; set; }
    
    public DateTime? ExpiryDate { get; set; }
}