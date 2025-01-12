using ClientServer_gRPC.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientServer_gRPC.DAL;

/// <summary>
///     Represents the database context for managing student-related data.
/// </summary>
public class StudentDbContext : DbContext
{
    // Db sets
    public DbSet<Student> Students { get; set; }

    // Configurations
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.\\MSSQLSERVER2;Initial Catalog=StudentDb;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasMany(c => c.PhoneNumbers).WithOne().OnDelete(DeleteBehavior.Cascade);
    }
}