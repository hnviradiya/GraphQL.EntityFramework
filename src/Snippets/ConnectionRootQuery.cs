using System.Linq;
using GraphQL.EntityFramework;
using Microsoft.EntityFrameworkCore;

class ConnectionRootQuery
{
    #region ConnectionRootQuery

    public class Query :
        EfQueryGraphType<MyDataContext>
    {
        public Query(IEfGraphQLService<MyDataContext> graphQlService) :
            base(graphQlService, userContext => (MyDataContext) userContext)
        {
            AddQueryConnectionField(
                name: "companies",
                resolve: context =>
                {
                    var dataContext = (MyDataContext) context.UserContext;
                    return dataContext.Companies;
                });
        }
    }

    #endregion

    public class Company
    {
    }

    class CompanyGraph :
        EfObjectGraphType<Company, MyDataContext>
    {
        public CompanyGraph(IEfGraphQLService<MyDataContext> efGraphQlService) :
            base(efGraphQlService)
        {
        }
    }

    public class MyDataContext :
        DbContext
    {
        public IQueryable<Company> Companies { get; set; }
    }
}