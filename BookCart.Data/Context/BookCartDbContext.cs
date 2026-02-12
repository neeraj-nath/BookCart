using Microsoft.EntityFrameworkCore;

using BookCart.Data.Entities;

namespace BookCart.Data.Context;

public class BookCartDbContext(DbContextOptions<BookCartDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Category>().HasKey(c => c.Id);

    }
}
