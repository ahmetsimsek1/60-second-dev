using Microsoft.EntityFrameworkCore;

public class MyContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=sandbox;integrated security=true;");

    public DbSet<Food> Foods { get; set; } = default!;
    public DbSet<Person> People { get; set; } = default!;
}
