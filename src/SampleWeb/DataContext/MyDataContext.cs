using Microsoft.EntityFrameworkCore;

public class MyDataContext :
    DbContext
{
    public DbSet<Company> Companies { get; set; }

    public MyDataContext()
    {
    }
    public MyDataContext(DbContextOptions options) :
        base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>()
            .HasMany(c => c.Employees)
            .WithOne(e => e.Company)
            .IsRequired();
    }
}