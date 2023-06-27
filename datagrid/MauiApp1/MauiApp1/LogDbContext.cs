using MauiApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiApp1;

// Define a DbContext class to interact with the database
public class LogDbContext : DbContext
{
    public DbSet<LogEntry> Log { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure the connection string for your database
        optionsBuilder.UseSqlite(connectionString: "Data Source=E:\\work\\NewLogs\\loguri.sqlite");
    }
}