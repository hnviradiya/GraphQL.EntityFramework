using EfCore.InMemoryHelpers;
using Microsoft.EntityFrameworkCore.Metadata;

// InMemory is used to make the sample simpler.
// Replace with a real DataContext
static class YourDataContextBuilder
{
    static YourDataContextBuilder()
    {
        using (var yourDataContext = InMemoryContextBuilder.Build<YourDataContext>())
        {
            Model = yourDataContext.Model;
        }
    }

    public static IModel Model;

    public static YourDataContext BuildDataContext()
    {

        var employee1 = new Employee
        {
            Id = 2,
            CompanyId = 1,
            Content = "Employee1",
            Age = 25
        };
        var employee2 = new Employee
        {
            Id = 3,
            CompanyId = 1,
            Content = "Employee2",
            Age = 31 
        };

        var employee4 = new Employee
        {
            Id = 5,
            CompanyId = 4,
            Content = "Employee4",
            Age = 34 
        };

        var yourDataContext = InMemoryContextBuilder.Build<YourDataContext>();
        yourDataContext.AddRange(employee1, employee2, employee4);
        yourDataContext.SaveChanges();
        return yourDataContext;
    }
}
