using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationCenter.Api.Presets;
using NotificationCenter.Api.Presets.Reports;
using NotificationCenter.BusinessLogic;
using NotificationCenter.BusinessLogic.Abstractions;
using NotificationCenter.Core.Options;
using NotificationCenter.Core.Options.Reports;
using NotificationCenter.DataAccess;
using NotificationCenter.DataAccess.Abstractions;
using NotificationCenter.DataAccess.Repositories;

namespace NotificationCenter.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddTransient<IDatabaseConnectionFactory, DatabaseConnectionFactory>()
                .Configure<DatabaseOptions>(configuration.GetSection(PresetDatabaseOptions.Position));

            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<ISystemRepository, SystemRepository>();

            return services;
        }

        public static IServiceCollection AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<INotificationManager, NotificationManager>();
            services.AddTransient<ISystemRegister, SystemRegister>();

            services
                .AddTransient<IReportsGenerator, ReportsGenerator>()
                .Configure<ReportGeneratorOptions>(configuration.GetSection(PresetReportGeneratorOptions.Position));

            return services;
        }
    }
}