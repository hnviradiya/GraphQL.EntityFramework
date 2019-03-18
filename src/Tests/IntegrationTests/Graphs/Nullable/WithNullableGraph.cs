using GraphQL.EntityFramework;

public class WithNullableGraph :
    EfObjectGraphType<WithNullableEntity, MyDataContext>
{
    public WithNullableGraph(IEfGraphQLService<MyDataContext> graphQlService) :
        base(graphQlService)
    {
        Field(x => x.Id);
        Field(x => x.Nullable,true);
    }
}