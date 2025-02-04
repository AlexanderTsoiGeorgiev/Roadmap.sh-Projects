using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TodoListAPI.Data;
using TodoListAPI.Data.Models;

namespace TodoListAPI.web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string connectionString = builder.Configuration.GetConnectionString("Default Connection") ?? throw new ArgumentNullException("Connection string 'Default Connection' not found!");
        builder.Services.AddDbContext<TodoListApiDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        builder.Services
        .AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<TodoListApiDbContext>();

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
