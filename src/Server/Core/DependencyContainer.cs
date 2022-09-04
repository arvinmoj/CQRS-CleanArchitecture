using MediatR;
using FluentValidation;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core;
public static class DependencyContainer
{

    #region Constructor
    static DependencyContainer()
    {
    }
    #endregion / Constructor

    #region Configure Services
    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        // Add HttpContextAccessor
        #region HttpContextAccessor
        services.AddTransient
             <IHttpContextAccessor, HttpContextAccessor>();
        #endregion / HttpContextAccessor

        // Add MediatR
        #region MediatR

        services.AddMediatR
                (typeof(Application.MappingProfile).GetTypeInfo().Assembly);

        #endregion / MediatR

        // Add FluentValidation
        #region Fluent Validation

        services.AddValidatorsFromAssembly
                (assembly: typeof(Application.Users.Commands.CreateUserCommandValidation).Assembly);

        #endregion / Fluent Validation

        // Add MediatR PipeLine
        #region MediatR PipeLine

        services.AddTransient
                (typeof(IPipelineBehavior<,>),
                 typeof(Infrastructure.Mediator.ValidationBehavior<,>));

        #endregion / MediatR PipeLine

        // Add Auto Mapper
        #region Auto Mapper

        services.AddAutoMapper
                (profileAssemblyMarkerTypes: typeof(Application.MappingProfile));

        #endregion / Auto Mapper

        // Add Unit Of Work
        #region Unit Of Work

        services.AddTransient<Persistence.IUnitOfWork, Persistence.UnitOfWork>(current =>
        {
            string databaseConnectionString =
                configuration
                .GetSection(key: "ConnectionStrings")
                .GetSection(key: "CommandsConnectionString")
                .Value;

            string databaseProviderString =
                configuration
                .GetSection(key: "CommandsDatabaseProvider")
                .Value;

            Infrastructure.Persistence.Enums.Provider databaseProvider =
                (Infrastructure.Persistence.Enums.Provider)
                System.Convert.ToInt32(databaseProviderString);

            Infrastructure.Persistence.Options options =
                new Infrastructure.Persistence.Options
                {
                    Provider = databaseProvider,
                    ConnectionString = databaseConnectionString,
                };

            return new Persistence.UnitOfWork(options: options);
        });

        #endregion / Unit Of Work

        // Add Query Unit Of Work
        #region Query Unit Of Work

        services.AddTransient<Persistence.IQueryUnitOfWork, Persistence.QueryUnitOfWork>(current =>
        {
            string databaseConnectionString =
                configuration
                .GetSection(key: "ConnectionStrings")
                .GetSection(key: "QueriesConnectionString")
                .Value;

            string databaseProviderString =
                configuration
                .GetSection(key: "QueriesDatabaseProvider")
                .Value;

            Infrastructure.Persistence.Enums.Provider databaseProvider =
                (Infrastructure.Persistence.Enums.Provider)
                System.Convert.ToInt32(databaseProviderString);

            Infrastructure.Persistence.Options options =
                new Infrastructure.Persistence.Options
                {
                    Provider = databaseProvider,
                    ConnectionString = databaseConnectionString,
                };

            return new Persistence.QueryUnitOfWork(options: options);
        });

        #endregion / Query Unit Of Work
    }
    #endregion / Configure Services
}
