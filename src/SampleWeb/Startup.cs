﻿using System;
using System.Collections.Generic;
using System.Linq;
using GraphiQl;
using GraphQL.EntityFramework;
using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using GraphQL.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        GraphTypeTypeRegistry.Register<Employee, EmployeeGraph>();
        GraphTypeTypeRegistry.Register<EmployeeSummary, EmployeeSummaryGraph>();
        GraphTypeTypeRegistry.Register<Company, CompanyGraph>();

        services.AddScoped(provider => MyDataContextBuilder.BuildDataContext());
        services.AddScoped(provider => YourDataContextBuilder.BuildDataContext());

        EfGraphQLConventions.RegisterInContainer(services, MyDataContextBuilder.Model);
        EfGraphQLConventions.RegisterInContainer(services, YourDataContextBuilder.Model);

        foreach (var type in GetGraphQlTypes())
        {
            services.AddSingleton(type);
        }

        services.AddGraphQL(options => options.ExposeExceptions = true).AddWebSockets();
        services.AddSingleton<ContextFactory>();
        services.AddSingleton<IDocumentExecuter, EfDocumentExecuter>();
        services.AddSingleton<IDependencyResolver>(
            provider => new FuncDependencyResolver(provider.GetRequiredService));
        services.AddSingleton<ISchema, Schema>();
        var mvc = services.AddMvc();
        mvc.SetCompatibilityVersion(CompatibilityVersion.Latest);
    }

    static IEnumerable<Type> GetGraphQlTypes()
    {
        return typeof(Startup).Assembly
            .GetTypes()
            .Where(x => !x.IsAbstract &&
                        (typeof(IObjectGraphType).IsAssignableFrom(x) ||
                         typeof(IInputObjectGraphType).IsAssignableFrom(x)));
    }

    public void Configure(IApplicationBuilder builder)
    {
        builder.UseWebSockets();
        builder.UseGraphQLWebSockets<ISchema>();
        builder.UseGraphiQl("/graphiql", "/graphql");
        builder.UseMvc();
    }
}