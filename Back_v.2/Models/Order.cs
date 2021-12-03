using System;
using System.Collections.Generic;

namespace Back_v._2.Models
{
    public class Order
    {
        string description;
        List<Product> products;
        DateTime lastUpdated;
        public int Id { get; set; }
        public AspNetUser AspNetUser { get; set; }
        public string UserId { get; set; }
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
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
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
