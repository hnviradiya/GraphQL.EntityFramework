using GraphQL.EntityFramework;

public class FilterChildGraph :
    EfObjectGraphType<FilterChildEntity, MyDataContext>
{
    public FilterChildGraph(IEfGraphQLService<MyDataContext> graphQlService) :
        base(graphQlService)
    {
        Field(x => x.Id);
        Field(x => x.Property);
    }
}