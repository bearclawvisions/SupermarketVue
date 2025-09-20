using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supermarket.Data.Database;
using Supermarket.Data.Repository.Implementation;
using Supermarket.Data.Repository.Interface;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Enums;
using Supermarket.Domain.Extensions;
using Supermarket.Domain.Models;
using System.Text.Json;

namespace UnitTests;

[TestClass]
public class UnitTestBase
{
    private IUnitOfWork _unit;
    
    [TestInitialize]
    public void Initialize()
    {
        var connectionString = "Host=localhost;Port=5432;Database=supermarket;User Id=supermarket;Password=DRQuWzDR@MVWswAmh5Kd;SSL Mode=Require;Trust Server Certificate=true";
    
        var options = new DbContextOptionsBuilder<SuperContext>()
            .UseNpgsql(connectionString)
            .Options;

        var context = new SuperContext(options);
        _unit = new UnitOfWork(context);
    }
    
    [TestMethod]
    public async Task SeedDatabase()
    {
        const string dataPath = "/home/bereklauw/RiderProjects/SupermarketVue/UnitTests/data.json";
        await using var file = File.OpenRead(dataPath);
        var jsonData = await JsonSerializer.DeserializeAsync<JsonElement>(file);

        if (jsonData.TryGetProperty("products", out var productsElement))
        {
            // if (jsonData.TryGetProperty("categories", out var categoriesElement))
            // {
            //     foreach (var categoryElement in categoriesElement.EnumerateArray())
            //     {
            //         var name = categoryElement.GetProperty("name").GetString();
            //         var description = categoryElement.GetProperty("description").GetString();
            //     
            //         var category = new ProductCategory()
            //         {
            //             Name = name, 
            //             Description = description,
            //             CreatedBy = "System",
            //             DateCreated = DateTime.UtcNow
            //         };
            //         await _unit.ProductCategory.CreateAsync(category);
            //     
            //         Console.WriteLine($"Category: {name} - Description: {description}");
            //     }
            // }
            // await _unit.SaveChangesAsync();
            
            foreach (var productElement in productsElement.EnumerateArray())
            {
                var name = productElement.GetProperty("name").GetString();
                var category = productElement.GetProperty("category").GetString();
                var type = productElement.GetProperty("type").GetString();
                var brand = productElement.GetProperty("brand").GetString();
                var description = productElement.GetProperty("description").GetString();
                var priceKg = decimal.Parse(productElement.GetProperty("price-kg").GetString() ?? "0");
                var allergen = productElement.GetProperty("allergen").GetString();
                var extraInfo = productElement.GetProperty("extra-info").GetString();
                
                var nutritionalValue = productElement.GetProperty("nutritional-value");
                var calories = int.Parse(nutritionalValue.GetProperty("calories").GetString() ?? "0");
                var protein = double.Parse(nutritionalValue.GetProperty("protein").GetString() ?? "0");
                var fat = double.Parse(nutritionalValue.GetProperty("fat").GetString() ?? "0");
                var carbohydrate = double.Parse(nutritionalValue.GetProperty("carbohydrate").GetString() ?? "0");

                var metadata = new ProductMetadata
                {
                    Name = name,
                    Brand = brand,
                    Description = description,
                    Image = "placeholder.jpg",
                    Price = priceKg,
                    ProductType = type,
                    NutritionalValue = new NutritionalValue
                    {
                        Calories = calories,
                        Protein = protein,
                        Carbohydrates = carbohydrate,
                        Fats = fat
                    },
                    Ingredients = new List<string>(),
                    Allergens = new List<string>() { allergen },
                    Tags = new List<string>(),
                    ExtraInfo = extraInfo
                }.ToXml();
                
                var catId = _unit.ProductCategory.Read().FirstOrDefault(x => x.Name.ToLower() == category.ToLower()).Id;
                
                var product = new Product
                {
                    CategoryId = catId,
                    Name = name,
                    Metadata = metadata,
                    Price = priceKg,
                    Quantity = 10,
                    Status = ProductStatus.InStock,
                    ExpiryDate = DateTime.UtcNow.Date.AddDays(30),
                    CreatedBy = "System",
                    DateCreated = DateTime.UtcNow
                };
                await _unit.Product.CreateAsync(product);
            }
            await _unit.SaveChangesAsync();
            
        }
    }

    [TestCleanup]
    public void Cleanup()
    {
        
    }
}