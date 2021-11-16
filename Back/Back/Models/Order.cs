using System;
using System.Collections.Generic;
using System.Linq;

namespace Back.Models
{
    public class Order
    {
        string description;
        List<Product> products;
        DateTime lastUpdated;

        public Order()
        {
        }

        /// <summary>
        /// for add in bd
        /// </summary>
        /// <param name="clientId">Id Заказчика</param>
        /// <param name="description">Описание заказа</param>
        /// <param name="products">список продуктов</param>
        public Order(string description, List<Product> products)
        {
            Description = description;
            Created = DateTime.Now;
            LastUpdated = DateTime.Now;
            Products = products;
        }

        public Order(int userId, string description, List<Product> products)
        {
            UserId = userId;
            Description = description;
            Products = products;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description
        {
            get
            {
                return description;
            } 
            set
            {
                description = value;
                lastUpdated = DateTime.Now;
            }
        }
        public decimal Price { get => Products.Sum(i => i.Price); }
        public DateTime Created {  get; }
        public DateTime LastUpdated {  get; }
        public List<Product> Products 
        {  
            get
            {
                return products;
            }
            set 
            {
                products = value;
                lastUpdated = DateTime.Now;
            } 
        }
    }
}
