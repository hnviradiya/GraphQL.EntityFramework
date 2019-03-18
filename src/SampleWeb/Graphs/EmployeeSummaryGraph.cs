using GraphQL.EntityFramework;

public class EmployeeSummaryGraph :
    EfObjectGraphType<EmployeeSummary, MyDataContext>
{
    public EmployeeSummaryGraph(IEfGraphQLService<MyDataContext> graphQlService) :
        base(graphQlService)
    {
        Field(x => x.CompanyId);
        Field(x => x.AverageAge);
    }
}