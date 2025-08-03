using System.Xml.Serialization;

namespace Supermarket.Domain.Models;

[XmlRoot("ProductMetadata")]
public class ProductMetadata
{
    public required string Name { get; set; }
    public required string Brand { get; set; }
    public required string Description { get; set; }
    public required string Image { get; set; }
    public decimal Price { get; set; }
    public required string ProductType { get; set; }
    public required NutritionalValue NutritionalValue { get; set; }
    public required List<string> Ingredients { get; set; }
    public required List<string> Allergens { get; set; }
    public required List<string> Tags { get; set; }
    public required string ExtraInfo { get; set; }
}

public class NutritionalValue
{
    public required double Calories { get; set; }
    public required double Protein { get; set; }
    public required double Carbohydrates { get; set; }
    public required double Fats { get; set; }
}