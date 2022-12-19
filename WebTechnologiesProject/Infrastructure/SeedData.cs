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
                Category action = new Category { Name = "Aksiyon", Slug = "action" };
                Category adventure = new Category { Name = "Macera", Slug = "adventure" };
                Category scienceFiction = new Category { Name = "Bilim Kurgu", Slug = "scienceFiction" };
                Category romantic = new Category { Name = "Romantik", Slug = "romantic" };
                Category animation = new Category { Name = "Animasyon", Slug = "animation" };
                Category dram = new Category { Name = "Dram", Slug = "dram" };

                context.Products.AddRange(
                    new Product
                    {
                        Name = "Avatar",
                        Slug = "scienceFiction",
                        Price = 20M,
                        Description = "Avatar bir bilim kurgu filmidir",
                        Category = scienceFiction,
                    },
                    new Product
                    {
                        Name = "X-Man",
                        Slug = "scienceFiction",
                        Price = 20M,
                        Description = "X-Man bir aksiyon filmidir",
                        Category = scienceFiction
                    },
                    new Product
                    {
                        Name = "Arı Maya",
                        Slug = "animation",
                        Price = 20M,
                        Description = "Arı Maya bir animasyon filmidir",
                        Category = animation,
                    },
                    new Product
                    {
                        Name = "Öğle Güneşinde Yıldızlar",
                        Slug = "romantic",
                        Price = 20M,
                        Description = "Öğle Güneşinde Yıldızlar bir bilim kurgu filmidir",
                        Category = romantic,
                    },
                    new Product
                    {
                        Name = "7. Koğuştaki Mucize",
                        Slug = "dram",
                        Price = 20M,
                        Description = "7. Koğuştaki Mucize bir bilim kurgu filmidir",
                        Category = dram,
                    }
                    ) ;
                context.SaveChanges();
            }
        }
    }
}
