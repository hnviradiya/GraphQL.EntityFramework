using System.Linq;
using GraphQL.EntityFramework;
using Microsoft.EntityFrameworkCore;

class RootQuery
{
    #region rootQuery

    public class Query :
        EfQueryGraphType<DataContext>
    {
        public Query(IEfGraphQLService<DataContext> graphQlService) :
            base(graphQlService, userContext => (DataContext) userContext)
        {
            AddSingleField(
                resolve: context =>
                {
                    var dataContext = (DataContext) context.UserContext;
                    return dataContext.Companies;
                },
                name: "company");
            AddQueryField(
                name: "companies",
                resolve: context =>
                {
                    var dataContext = (DataContext) context.UserContext;
                    return dataContext.Companies;
                });
        }
    }

    #endregion

    public class DataContext : DbContext
    {
        public IQueryable<Company> Companies { get; set; }
    }

    public class Company
    {
    }

    class CompanyGraph:
        EfObjectGraphType<Company, DataContext>
    {
        public CompanyGraph(IEfGraphQLService<DataContext> efGraphQlService) :
            base(efGraphQlService)
        {
        }
    }
}