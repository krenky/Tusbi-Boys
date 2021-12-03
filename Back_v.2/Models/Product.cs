using System;
using System.Collections.Generic;

namespace Back_v._2.Models
{
    public class Product
    {
        public string name;
        public string description;
        public string title;
        public decimal price;
        public List<string> photos;
        public string addess;

        public int Id { get; set; }
        public AspNetUser AspNetUser { get; set; }
        public string UserId { get; set; }
        public Order Order { get; set; }
        public int? OrderId { get; set; }//??
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                LastUpdated = DateTime.Now;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                LastUpdated = DateTime.Now;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                LastUpdated = DateTime.Now;
            }
        }
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                LastUpdated = DateTime.Now;
            }
        }
        public List<string> Photos
        {
            get
            {
                return photos;
            }
            set
            {
                photos = value;
                LastUpdated = DateTime.Now;
            }
        }
        public string Address
        {
            get
            {
                return addess;
            }
            set
            {
                addess = value;
                LastUpdated = DateTime.Now;
            }
        }
        public DateTime LastUpdated { get; set; }
    }
}
