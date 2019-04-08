using Microsoft.EntityFrameworkCore;

public class YourDataContext :
    DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public YourDataContext()
    {
    }
    public YourDataContext(DbContextOptions options) :
        base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>();
    }
}