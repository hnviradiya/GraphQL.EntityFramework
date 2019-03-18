using GraphQL.EntityFramework;

public class Level2Graph :
    EfObjectGraphType<Level2Entity, MyDataContext>
{
    public Level2Graph(IEfGraphQLService<MyDataContext> graphQlService) :
        base(graphQlService)
    {
        Field(x => x.Id);
        AddNavigationField(
            name: "level3Entity",
            resolve: context => context.Source.Level3Entity);
    }
}