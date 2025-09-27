using FoodOrderingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FoodItem>()
                .Property(f => f.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<CartItem>()
                .Property(c => c.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.FoodItem)
                .WithMany()
                .HasForeignKey(c => c.FoodItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 1,
                   Username = "admin",
                   Password = "$2a$12$DCFivOnraf6V7aeMTeey8e9v9nRbetjV1ebRQTNn4fAuBxv2qyajq",
                   Role = "Admin"
               }
            );

            modelBuilder.Entity<FoodItem>().HasData(
                new FoodItem
                {
                    Id = 1,
                    Name = "Classic Cheeseburger",
                    Description = "Juicy beef patty with melted cheese, lettuce, tomato, and our special sauce on a toasted bun.",
                    Price = 12.99m,
                    Category = "A La Carte",
                    ImageUrl = ""
                },
                new FoodItem
                {
                    Id = 2,
                    Name = "Margherita Pizza",
                    Description = "Traditional pizza with fresh mozzarella, tomatoes, basil, and olive oil on a crispy thin crust.",
                    Price = 15.50m,
                    Category = "A La Carte",
                    ImageUrl = ""
                },
                new FoodItem
                {
                    Id = 3,
                    Name = "Caesar Salad",
                    Description = "Crisp romaine lettuce with parmesan cheese, croutons, and our homemade Caesar dressing.",
                    Price = 9.99m,
                    Category = "Rice and Salad",
                    ImageUrl = ""
                },
                new FoodItem
                {
                    Id = 4,
                    Name = "Grilled Chicken Breast",
                    Description = "Tender grilled chicken breast seasoned with herbs, served with roasted vegetables.",
                    Price = 18.75m,
                    Category = "Fried Chicken",
                    ImageUrl = ""
                },
                new FoodItem
                {
                    Id = 5,
                    Name = "Fish & Chips",
                    Description = "Beer-battered fish fillets with golden fries and mushy peas, served with tartar sauce.",
                    Price = 16.25m,
                    Category = "A La Carte",
                    ImageUrl = ""
                },
                new FoodItem
                {
                    Id = 6,
                    Name = "Pepperoni Pizza",
                    Description = "Classic pizza topped with spicy pepperoni and mozzarella cheese on our signature dough.",
                    Price = 17.00m,
                    Category = "A La Carte",
                    ImageUrl = ""
                },
                new FoodItem
                {
                    Id = 7,
                    Name = "Chocolate Brownie",
                    Description = "Rich, fudgy chocolate brownie served warm with vanilla ice cream and chocolate sauce.",
                    Price = 7.50m,
                    Category = "Snack",
                    ImageUrl = ""
                },
                new FoodItem
                {
                    Id = 8,
                    Name = "Chicken Wings",
                    Description = "Crispy chicken wings tossed in your choice of buffalo, BBQ, or honey mustard sauce.",
                    Price = 11.99m,
                    Category = "Fried Chicken",
                    ImageUrl = ""
                },
                new FoodItem
                {
                    Id = 9,
                    Name = "Veggie Burger",
                    Description = "House-made plant-based patty with avocado, sprouts, and chipotle mayo on a whole grain bun.",
                    Price = 13.50m,
                    Category = "A La Carte",
                    ImageUrl = ""
                },
                new FoodItem
                {
                    Id = 10,
                    Name = "Tiramisu",
                    Description = "Classic Italian dessert with layers of coffee-soaked ladyfingers and mascarpone cream.",
                    Price = 8.99m,
                    Category = "Coffee",
                    ImageUrl = ""
                },
                new FoodItem
                {
                    Id = 11,
                    Name = "Greek Salad",
                    Description = "Fresh mixed greens with feta cheese, olives, tomatoes, and cucumber in olive oil dressing.",
                    Price = 10.75m,
                    Category = "Rice and Salad",
                    ImageUrl = ""
                },
                new FoodItem
                {
                    Id = 12,
                    Name = "Loaded Nachos",
                    Description = "Crispy tortilla chips loaded with cheese, jalapeños, sour cream, and guacamole.",
                    Price = 9.50m,
                    Category = "Snack",
                    ImageUrl = ""
                }
            );
        }
    }
}
