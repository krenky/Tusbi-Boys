using System.Collections.Generic;

namespace Back.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public UserRole()
        {
            Users = new List<User>();
        }
    }
}
