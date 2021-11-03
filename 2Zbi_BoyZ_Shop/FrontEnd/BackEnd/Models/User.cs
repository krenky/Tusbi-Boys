using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BackEnd.Models
{
    public class User
    {
        List<Product> products = new List<Product>();
        List<Order> order = new List<Order>();
        string password;
        public User(string name, string email, string password, string phoneNumber, List<Product> products, List<Order> order)
        {
            Name = name;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Products = products;
            Order = order;
        }

        public User()
        {
        }

        public User(string name, string email, string password, string phoneNumber)
        {
            Name = name;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = ComputeHash(value, new MD5CryptoServiceProvider());
            }
        }
        public string PhoneNumber { get; set; }
        public List<Product> Products { get => products; set => products = value; }
        public List<Order> Order { get => order; set => order = value; }//??
        public photo Photo { get; set; }
        public string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
        public static string ComputeHash(string input, HashAlgorithm algorithm, Byte[] salt)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Combine salt and input bytes
            Byte[] saltedInput = new Byte[salt.Length + inputBytes.Length];
            salt.CopyTo(saltedInput, 0);
            inputBytes.CopyTo(saltedInput, salt.Length);

            Byte[] hashedBytes = algorithm.ComputeHash(saltedInput);

            return BitConverter.ToString(hashedBytes);
        }
    }
}
