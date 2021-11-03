using Microsoft.EntityFrameworkCore;
using System;

namespace BackEndShop.Models
{
    public class UserContext: DbContext
    {
        public UserContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Shopdb;Username=postgres;Password=363kYkmJ");//postgres
        }
        public DbSet<User> Users {  get; set; }
        public DbSet<Order> Order {  get; set; }
        public DbSet<Product> Product {  get; set;}
        //public DbSet<UserRole> Roles {  get; set; }
    }
}
