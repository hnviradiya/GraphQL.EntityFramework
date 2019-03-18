using GraphQL.EntityFramework;

public class CustomTypeGraph :
    EfObjectGraphType<CustomTypeEntity, MyDataContext>
{
    public CustomTypeGraph(IEfGraphQLService<MyDataContext> graphQlService) :
        base(graphQlService)
    {
        Field(x => x.Id);
        Field(x => x.Property);
    }
}