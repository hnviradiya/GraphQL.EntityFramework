using GraphQL.EntityFramework;

public class Level1Graph :
    EfObjectGraphType<Level1Entity,MyDataContext>
{
    public Level1Graph(IEfGraphQLService<MyDataContext> graphQlService) :
        base(graphQlService)
    {
        Field(x => x.Id);
        AddNavigationField(
            name: "level2Entity",
            resolve: context => context.Source.Level2Entity);
    }
}