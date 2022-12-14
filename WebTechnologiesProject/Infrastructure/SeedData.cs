using Microsoft.EntityFrameworkCore;
using WebTechnologiesProject.Models;

namespace WebTechnologiesProject.Infrastructure
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();
            if(!context.Products.Any())
            {
                Category fruits = new Category { Name = "fruits"};
                Category vegetables = new Category { Name = "vegetables" };

                context.Products.AddRange(
                    new Product
                    {
                        Name = "Apples",
                        Price = 1.50M,
                        Description = "Red apples",
                        Category = fruits,
                    },
                    new Product
                    {
                        Name = "Bananas",
                        Price = 2M,
                        Description = "Yellow bananas",
                        Category = fruits
                    },
                    new Product
                    {
                        Name = "Lemons",
                        Price = 3M,
                        Description = "Yellow lemons",
                        Category = fruits
                    },
                    new Product
                    {
                        Name = "Cucumbers",
                        Price = 3M,
                        Description = "Green cucumbers",
                        Category = vegetables
                    },
                    new Product
                    {
                        Name = "Tomatos",
                        Price = 3M,
                        Description = "Red tomatos",
                        Category = vegetables
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
