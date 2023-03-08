using Library.Domain.Entities;
using Library.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Context;

public class ApplicationDbContext: DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<Author> Author { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        optionsBuilder.UseSqlite("Data source = ../Library.Persistence/database.db");
    }
}
