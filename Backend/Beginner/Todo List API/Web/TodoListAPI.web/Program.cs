using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        .AddIdentity<ApplicationUser, IdentityRole>(options => {
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
        })
        .AddEntityFrameworkStores<TodoListApiDbContext>();


        //try this only and shee what is the differene
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
        // .AddJwtBearer(options =>
        // {
        //     options.TokenValidationParameters = new TokenValidationParameters
        //     {
        //         ValidateIssuer = true,
        //         ValidIssuer = ,
        //         ValidateAudience = true,
        //         ValidAudience = ,
        //         ValidateIssuerSigningKey = true,
        //         IssuerSigningKey = new Systemsym
        //     };
        // });

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

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
