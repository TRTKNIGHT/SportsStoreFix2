using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

            /*if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }*/

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Kayak",
                        Description = "A boat for one person",
                        Category = "Watersports",
                        Price = 275,
                        Image = $"~/wwwroot/images/1"
                    },

                    new Product
                    {
                        Name = "LifeJacket",
                        Description = "Protective and fashionable",
                        Category = "Watersports",
                        Price = 48.95m,
                        Image = $"~/wwwroot/images/1"
                    },

                    new Product
                    {
                        Name = "Soccer Ball",
                        Description = "FIFA-approved size and weight",
                        Category = "Soccer",
                        Price = 19.50m,
                        Image = $"~/wwwroot/images/1"
                    },

                    new Product
                    {
                        Name = "Corner Flags",
                        Description = "Give your playing field a profesional touch",
                        Category = "Soccer",
                        Price = 34.95m,
                        Image = $"~/wwwroot/images/1"
                    },

                    new Product
                    {
                        Name = "Stadium",
                        Description = "Flat-packed 35,000-seat stadium",
                        Category = "Soccer",
                        Price = 79_500,
                        Image = $"~/wwwroot/images/1"
                    },

                    new Product
                    {
                        Name = "Thiking Cap",
                        Description = "Improve brain efficiency by 75%",
                        Category = "Chess",
                        Price = 16,
                        Image = $"~/wwwroot/images/1"
                    },

                    new Product
                    {
                        Name = "Usteady Chair",
                        Description = "Secretly give your opponent a disadvantage",
                        Category = "Chess",
                        Price = 29.95m,
                        Image = $"~/wwwroot/images/1"
                    },
                    
                    new Product
                    {
                        Name = "Human Chess board",
                        Description = "A fun game for the family",
                        Category = "Chess",
                        Price = 75,
                        Image = $"~/wwwroot/images/1"
                    },

                    new Product
                    {
                        Name = "Bling-Bling King",
                        Description = "Gold-plated, diamond-studded King",
                        Category = "Chess",
                        Price = 1200,
                        Image = $"wwwroot/images/1"
                    }
                );
            }
            context.SaveChanges();
        }
    }
}
