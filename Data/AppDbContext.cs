using Elmurod.ToDoList.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmurod.ToDoList.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserPlans> Userplans { get; set; }

        public DbSet<DeletedPlans> Deletedplans { get; set; }

        public DbSet<CompletedPlans> Completedplans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;Port=5432;Database=ToDoDb;User Id = postgres; Password=5456;";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
