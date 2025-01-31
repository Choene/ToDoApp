using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Data.Context;
using ToDoApp.Data.Services;

namespace ToDoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            // Get connection string
            var relativeDbPath = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data/todo.db";

            // Convert to absolute path
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeDbPath.Replace("Data Source=", ""));
            Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);

            builder.Services.AddDbContext<TodoDbContext>(options => options.UseSqlite($"Data Source={dbPath}"));

            builder.Services.AddScoped<TodoService>();

            var app = builder.Build();

            // database creation and migrations
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TodoDbContext>();
                db.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
