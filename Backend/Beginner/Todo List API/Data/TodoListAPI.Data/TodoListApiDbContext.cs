using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoListAPI.Data.Models;

namespace TodoListAPI.Data;

public class TodoListApiDbContext : IdentityDbContext<ApplicationUser>
{
    public TodoListApiDbContext(DbContextOptions<TodoListApiDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
