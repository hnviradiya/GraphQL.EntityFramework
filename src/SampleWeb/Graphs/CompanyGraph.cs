using GraphQL.EntityFramework;

public class CompanyGraph :
    EfObjectGraphType<Company,MyDataContext>
{
    public CompanyGraph(IEfGraphQLService<MyDataContext> graphQlService) :
        base(graphQlService)
    {
        Field(x => x.Id);
        Field(x => x.Content);
        AddNavigationListField(
            name: "employees",
            resolve: context => context.Source.Employees);
        AddNavigationConnectionField(
            name: "employeesConnection",
            resolve: context => context.Source.Employees,
            includeNames: new[] {"Employees"});
    }
}