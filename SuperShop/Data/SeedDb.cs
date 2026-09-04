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
        private readonly UserManager<User> _userManager;


        public SeedDb(DataContext context, UserManager<User> userManager)
        {
            _context = context;
            _random = new Random();
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            User user = await _userManager.FindByEmailAsync("jovanamatos22@gmail.com");

            if (user == null)
            {
                user = new User
                {
                    FirstName = "Jovana",
                    LastName = "Matos",
                    UserName = "jovanamatos22@gmail.com",
                    Email = "jovanamatos22@gmail.com"

                };

                IdentityResult result = await _userManager.CreateAsync(
                    user,
                    "123456"
                );
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        throw new InvalidOperationException(
                            $"{error.Code}: {error.Description}"
                        );
                    }
                }
            }

                if (!_context.Products.Any())
            {
                AddProduct("Iphone 13", user);
                AddProduct("Iphone 14", user);
                AddProduct("Iphone 15", user);
                AddProduct("Samsung Galaxy S22", user);
                AddProduct("Samsung Galaxy S23", user);
                AddProduct("Samsung Galaxy S24", user);
                AddProduct("Xiaomi Redmi Note 12", user);
                AddProduct("Xiaomi Redmi Note 13", user);
                AddProduct("Xiaomi Redmi Note 14", user);
                await _context.SaveChangesAsync();
            }

        }

        private void AddProduct(string name, User user)
        {
            _context.Products.Add(new Product
            {
                Name = name,
                Price = _random.Next(1000),
                IsAvailable = true,
                Stock = _random.Next(100),
                User = user
            });
        }
    }
}
