using Microsoft.EntityFrameworkCore;

using BookCart.Data.Entities;

namespace BookCart.Data.Context;

public class BookCartDbContext(DbContextOptions<BookCartDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Model Configuration:
        //builder.Entity<Category>().HasKey(c => c.Id);
        builder.Entity<Category>(category =>
        {
            category.ToTable("Categories", "books",
                c => c.HasCheckConstraint("CK_Categories_DisplayOrder", "DisplayOrder>0")
            );

            category.HasKey(c => c.Id).HasName("PK_Categories");

            category.Property(c => c.Name).IsRequired().HasMaxLength(30);

            category.HasIndex(c => c.Name).IsUnique().HasDatabaseName("UQ_Categories_Name");

            category.Property(c => c.DisplayOrder).IsRequired();
        });




        //Data Seeds:
        builder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
            new Category { Id = 2, Name = "Thriller", DisplayOrder = 2 },
            new Category { Id = 3, Name = "Horror", DisplayOrder = 3 }
        );

    }
}
