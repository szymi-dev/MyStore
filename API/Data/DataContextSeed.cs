using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.Extensions.Logging;

namespace API.Data
{
    public class DataContextSeed
    {
        public static async Task SeedData(DataContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.ProductSizes.Any())
                {
                    var sizesData = File.ReadAllText("C:/Users/szzie/OneDrive/Pulpit/.netcore/MyApp/API/Data/SeedData/sizes.json");

                    var sizes = JsonSerializer.Deserialize<List<ProductSize>>(sizesData);

                    foreach (var size in sizes)
                    {
                        context.ProductSizes.Add(size);
                    }

                    await context.SaveChangesAsync();
                }     
                if(!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("C:/Users/szzie/OneDrive/Pulpit/.netcore/MyApp/API/Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var brand in brands)
                    {
                        context.ProductBrands.Add(brand);
                    }

                    await context.SaveChangesAsync();
                }
                if(!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("C:/Users/szzie/OneDrive/Pulpit/.netcore/MyApp/API/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var type in types)
                    {
                        context.ProductTypes.Add(type);
                    }

                    await context.SaveChangesAsync();
                }
                if(!context.Products.Any())
                {
                    var productsData = File.ReadAllText("C:/Users/szzie/OneDrive/Pulpit/.netcore/MyApp/API/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var product in products)
                    {
                        context.Products.Add(product);
                    }

                    await context.SaveChangesAsync();
                }       
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DataContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}