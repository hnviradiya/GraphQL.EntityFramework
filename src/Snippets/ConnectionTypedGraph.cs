using System.Collections.Generic;
using GraphQL.EntityFramework;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

class ConnectionTypedGraph
{
    #region ConnectionTypedGraph

    public class CompanyGraph :
        EfObjectGraphType<Company, MyDataContext>
    {
        public CompanyGraph(IEfGraphQLService<MyDataContext> graphQlService) :
            base(graphQlService)
        {
            AddNavigationConnectionField(
                name: "employees",
                resolve: context => context.Source.Employees);
        }
    }

    #endregion

    public class Company
    {
        public List<Employee> Employees { get; set; }
    }

    public class Employee
    {
    }

    public class MyDataContext :
        DbContext
    {
    }

    public class EmployeeGraph :
        ObjectGraphType<Employee>
    {
    }
}