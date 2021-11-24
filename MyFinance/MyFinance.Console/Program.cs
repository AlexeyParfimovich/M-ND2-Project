using Microsoft.EntityFrameworkCore;
using MyFinance.DAL;
using System;
using System.Text.Json;

namespace MyFinance.Console
{
    class Program
    {
        static void Main()
        {
            System.Console.WriteLine("Test User table access");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            UnitOfWork db = new(new AppDbContext(optionsBuilder.Options));

            var users = db.Users.GetAll().Result;

            System.Console.WriteLine("Request all registered Users:");
            System.Console.WriteLine($"\n{System.Text.Json.JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true })}");
        }
    }
}
