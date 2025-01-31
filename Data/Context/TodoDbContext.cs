using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection.Emit;
using ToDoApp.Data.Models;

namespace ToDoApp.Data.Context
{
    public class TodoDbContext : DbContext
    {
        public DbSet<TodoItem> Todos { get; set; }

        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>()
                .Property(t => t.Title)
                .IsRequired();
        }
    }
}
