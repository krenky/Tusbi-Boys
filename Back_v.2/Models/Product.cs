using Back_v._2.IdentityAuth;
using System.Collections.Generic;

namespace Back_v._2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public AspNetUser AspNetUser { get; set; }
        public string UserId { get; set; }
        public Order Order { get; set; }
        public int? OrderId { get; set; }//??
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public List<string> Photos { get; set; }
    }
}
