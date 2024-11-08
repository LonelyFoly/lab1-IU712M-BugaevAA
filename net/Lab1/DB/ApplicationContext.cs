
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.DB
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationContext : DbContext
    {
        public DbSet<Person> person { get; set; } = null!;
        private readonly string _connectionString;
        public ApplicationContext()
        {
            
            // Чтение строки подключения из переменной окружения
            string connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
                                ?? "Host=postgres;Port=5432;Database=persons;Username=program;Password=test";
            _connectionString = connectionString;
            Console.WriteLine($"Loaded connection string: {_connectionString}");
            Database.EnsureCreated();
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}

