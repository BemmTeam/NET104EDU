using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NET104.Entities;

namespace NET104 
{ 
    public class ShopContext : IdentityDbContext<User> 
    { 
        public DbSet<Product> Products {get;set;}

        public DbSet<Category> Categories {get;set;} 

        public DbSet<Cart> Carts {get;set;}
        
        public DbSet<Bill> Bills {get;set;}
        // public DbSet<User> Users {get;set;}

        public ShopContext(DbContextOptions<ShopContext> options) : base(options) {}
    }
}