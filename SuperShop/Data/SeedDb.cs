using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuperShop.Data.Entities;

namespace SuperShop.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        private Random _random;

        public SeedDb(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if(!_context.Products.Any())
            {
                AddProduct("Iphone 13");
                AddProduct("Iphone 14");
                AddProduct("Iphone 15");
                AddProduct("Samsung Galaxy S22");
                AddProduct("Samsung Galaxy S23");
                AddProduct("Samsung Galaxy S24");
                AddProduct("Xiaomi Redmi Note 12");
                AddProduct("Xiaomi Redmi Note 13");
                AddProduct("Xiaomi Redmi Note 14");
                await _context.SaveChangesAsync();
            }

        }

        private void AddProduct(string name)
        {
            _context.Products.Add(new Product
            {
                Name = name,
                Price = _random.Next(1000),
                IsAvailable = true,
                Stock = _random.Next(100),
            });
        }
    }
}
