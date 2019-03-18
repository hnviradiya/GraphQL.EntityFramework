using GraphQL.EntityFramework;

public class ChildGraph :
    EfObjectGraphType<ChildEntity, MyDataContext>
{
    public ChildGraph(IEfGraphQLService<MyDataContext> graphQlService) :
        base(graphQlService)
    {
        Field(x => x.Id);
        Field(x => x.Property);
        Field(x => x.Nullable, true);
        AddNavigationField(name: "parent",
            resolve: context => context.Source.Parent, graphType: typeof(ParentGraph));
        AddNavigationField(name: "parentAlias",
            resolve: context => context.Source.Parent,
            graphType: typeof(ParentGraph), includeNames: new []{"Parent"});
    }
}