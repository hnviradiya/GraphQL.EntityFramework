using System.Collections.Generic;
using System.Linq;
using GraphQL.EntityFramework;
using GraphQL.Types;
using SampleWeb;

#region QueryUsedInController

public class Query :
    EfObjectGraphType
{
    public Query(IEfGraphQLService efGraphQlService) :
        base(efGraphQlService)
    {
        AddQueryField(
            name: "companies",
            resolve: context =>
            {
                var dataContext = (context.UserContext as DataContexts).myDataContext;
                return dataContext.Companies;
            });

        #endregion

        AddSingleField(
            resolve: context =>
            {
                var dataContext = (context.UserContext as DataContexts).myDataContext;
                return dataContext.Companies;
            },
            name: "company");

        AddQueryConnectionField(
            name: "companiesConnection",
            resolve: context =>
            {
                var dataContext = (context.UserContext as DataContexts).myDataContext;
                return dataContext.Companies;
            });

        AddQueryField(
            name: "employees",
            resolve: context =>
            {
                var dataContext = (context.UserContext as DataContexts).yourDataContext;
                return dataContext.Employees;
            });

        AddQueryField(
            name: "employeesByArgument",
            resolve: context =>
            {
                var content = context.GetArgument<string>("content");
                var dataContext = (context.UserContext as DataContexts).yourDataContext;
                return dataContext.Employees.Where(x => x.Content == content);
            },
            arguments: new QueryArguments(
                new QueryArgument<StringGraphType>
                {
                    Name = "content"
                }));

        AddQueryConnectionField(
            name: "employeesConnection",
            resolve: context =>
            {
                var dataContext = (context.UserContext as DataContexts).yourDataContext;
                return dataContext.Employees;
            });

        #region ManuallyApplyWhere

        Field<ListGraphType<EmployeeSummaryGraph>>(
            name: "employeeSummary",
            arguments: new QueryArguments(
                new QueryArgument<ListGraphType<WhereExpressionGraph>>
                {
                    Name = "where"
                }
            ),
            resolve: context =>
            {
                var dataContext = (context.UserContext as DataContexts).yourDataContext;
                IQueryable<Employee> query = dataContext.Employees;

                if (context.HasArgument("where"))
                {
                    var wheres = context.GetArgument<List<WhereExpression>>("where");
                    foreach (var where in wheres)
                    {
                        var predicate = ExpressionBuilder<Employee>.BuildPredicate(where);
                        query = query.Where(predicate);
                    }
                }

                return from q in query
                    group q by new {q.CompanyId}
                    into g
                    select new EmployeeSummary
                    {
                        CompanyId = g.Key.CompanyId,
                        AverageAge = g.Average(x => x.Age),
                    };
            });

        #endregion
    }
}