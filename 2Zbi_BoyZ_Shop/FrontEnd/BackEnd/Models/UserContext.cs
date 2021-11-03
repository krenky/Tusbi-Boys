using Microsoft.EntityFrameworkCore;
using System;

namespace BackEnd.Models
{
    public class UserContext: DbContext
    {
        public UserContext()
        //public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            //if (options == null)
            //{
            //    //Database.EnsureCreated();
            //    throw new ArgumentNullException(nameof(options));
            //}
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Shopdb;Trusted_Connection=True;");
            //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Shopdb;Username=postgres;Password=363kYkmJ");//postgres
        }
        public DbSet<User> Users {  get; set; }
        public DbSet<Order> Order {  get; set; }
        public DbSet<Product> Product {  get; set;}
        //public DbSet<UserRole> Roles {  get; set; }
    }
}
