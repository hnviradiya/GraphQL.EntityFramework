using System.Collections.Generic;
using GraphQL.EntityFramework;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

public class TypedGraph
{
    #region typedGraph

    public class CompanyGraph :
        EfObjectGraphType<Company,DataContext>
    {
        public CompanyGraph(IEfGraphQLService<DataContext> graphQlService) :
            base(graphQlService)
        {
            Field(x => x.Id);
            Field(x => x.Content);
            AddNavigationListField(
                name: "employees",
                resolve: context => context.Source.Employees);
            AddNavigationConnectionField(
                name: "employeesConnection",
                resolve: context => context.Source.Employees,
                includeNames: new[] {"Employees"});
        }
    }

    #endregion

    public class Company
    {
        public object Id { get; set; }
        public object Content { get; set; }
        public List<Employee> Employees { get; set; }
    }

    public class Employee
    {
    }
    public class DataContext:
        DbContext
    {
    }

    public class EmployeeGraph :
        ObjectGraphType<Employee>
    {
    }
}