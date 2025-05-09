﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Domain.Entities;

public class ProductCategory : Audit
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [MaxLength(50)]
    public required string Name { get; set; }
    
    [MaxLength(255)]
    public required string Description { get; set; }
}