using Microsoft.EntityFrameworkCore;

public class MyContext
    : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(Constants.ConnectionString);

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Store>(entity =>
        {
            entity.ToTable("Stores", "dbo");
            entity.HasKey(s => s.StoreID);
            entity.Property(s => s.RegionName).HasMaxLength(20).IsRequired();
            entity.Property(s => s.StoreName).HasMaxLength(20).IsRequired();
            entity.HasOne(s => s.Country).WithMany(c => c.Stores);
        });

        model.Entity<Country>(entity =>
        {
            entity.ToTable("Countries", "dbo");
            entity.HasKey(c => c.CountryID);
            entity.Property(c => c.CountryName).HasMaxLength(20).IsRequired();
        });
    }

    public DbSet<Store> Stores { get; set; } = default!;
    public DbSet<Country> Countries { get; set; } = default!;
}
