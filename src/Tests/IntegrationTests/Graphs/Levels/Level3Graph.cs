using GraphQL.EntityFramework;

public class Level3Graph :
    EfObjectGraphType<Level3Entity, MyDataContext>
{
    public Level3Graph(IEfGraphQLService<MyDataContext> graphQlService) :
        base(graphQlService)
    {
        Field(x => x.Id);
        Field(x => x.Property);
    }
}