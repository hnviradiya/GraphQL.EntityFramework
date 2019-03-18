using GraphQL.EntityFramework;

public class WithMisNamedQueryChildGraph :
    EfObjectGraphType<WithMisNamedQueryChildEntity, MyDataContext>
{
    public WithMisNamedQueryChildGraph(IEfGraphQLService<MyDataContext> graphQlService) :
        base(graphQlService)
    {
        Field(x => x.Id);
        AddNavigationField(
            name: "parent",
            resolve: context => context.Source.Parent);
    }
}