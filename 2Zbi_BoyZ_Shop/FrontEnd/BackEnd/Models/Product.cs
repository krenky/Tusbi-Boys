using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Product
    {
        public Product()
        {
        }

        /// <summary>
        /// for add in bd
        /// </summary>
        /// <param name="authorId"></param>
        /// <param name="orderId"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="title"></param>
        /// <param name="price"></param>
        public Product(string name, string description, string title, decimal price)
        {
            Name = name;
            Description = description;
            Title = title;
            Price = price;
        }

        public int Id {  get; set; }
        //public int UserId {  get; set; }
        //public int OrderId {  get; set; }//??
        public string Name {  get; set; }
        public string Description {  get; set; }
        public string Title {  get; set; }
        public decimal Price {  get; set; }
        public List<photo> Photos { get; set; }
    }
}
