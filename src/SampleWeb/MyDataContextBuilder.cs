using EfCore.InMemoryHelpers;
using Microsoft.EntityFrameworkCore.Metadata;

// InMemory is used to make the sample simpler.
// Replace with a real DataContext
static class MyDataContextBuilder
{
    static MyDataContextBuilder()
    {
        using (var myDataContext = InMemoryContextBuilder.Build<MyDataContext>())
        {
            Model = myDataContext.Model;
        }
    }

    public static IModel Model;

    public static MyDataContext BuildDataContext()
    {
        var company1 = new Company
        {
            Id = 1,
            Content = "Company1"
        };
  
        var company2 = new Company
        {
            Id = 4,
            Content = "Company2"
        };
       
        var company3 = new Company
        {
            Id = 6,
            Content = "Company3"
        };
        var company4 = new Company
        {
            Id = 7,
            Content = "Company4"
        };
        var myDataContext = InMemoryContextBuilder.Build<MyDataContext>();
        myDataContext.AddRange(company1, company2, company3, company4);
        myDataContext.SaveChanges();
        return myDataContext;
    }
}
