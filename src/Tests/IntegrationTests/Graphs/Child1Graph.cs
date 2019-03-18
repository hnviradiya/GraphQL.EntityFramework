using GraphQL.EntityFramework;

public class Child1Graph :
    EfObjectGraphType<Child1Entity, MyDataContext>
{
    public Child1Graph(IEfGraphQLService<MyDataContext> graphQlService) :
        base(graphQlService)
    {
        Field(x => x.Id);
    }
}