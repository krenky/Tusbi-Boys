using Microsoft.EntityFrameworkCore;
using System;

namespace Back.Models
{
    public class UserContext: DbContext
    {
        public UserContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        //public UserContext(DbContextOptions<UserContext> options) : base(options)
        //{
        //    if (options == null)
        //    {
        //        Database.EnsureDeleted();
        //        Database.EnsureCreated();
        //        throw new ArgumentNullException(nameof(options));
        //    }
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Shopdb;Trusted_Connection=True;");
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Shopdb;Username=postgres;Password=363kYkmJ");//postgres

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";

            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, UserRoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users {  get; set; }
        public DbSet<Order> Order {  get; set; }
        public DbSet<Product> Product {  get; set;}
        public DbSet<Role> UserRoles { get; set; }
    }
}
