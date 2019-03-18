using GraphQL.EntityFramework;

public class FilterParentGraph :
    EfObjectGraphType<FilterParentEntity, MyDataContext>
{
    public FilterParentGraph(IEfGraphQLService<MyDataContext> graphQlService) :
        base(graphQlService)
    {
        Field(x => x.Id);
        Field(x => x.Property);
        AddNavigationListField(
            name: "children",
            resolve: context => context.Source.Children);
        AddNavigationConnectionField(
            name: "childrenConnection",
            resolve: context => context.Source.Children,
            includeNames: new[] {"Children"});
    }
}