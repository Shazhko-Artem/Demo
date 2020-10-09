using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotificationCenter.Api.Extensions;
using NotificationCenter.Api.Extensions.ServiceProvider;
using NotificationCenter.Api.Presets.Reports;
using NotificationCenter.Api.Schedulers;
using NotificationCenter.Core.Options.Reports;

namespace NotificationCenter.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataAccess(this.Configuration);
            services.AddBusinessLogic(this.Configuration);

            services
                .AddHostedService<ReportScheduler>()
                .Configure<PresetReportSchedulerOptions>(this.Configuration.GetSection(PresetReportSchedulerOptions.Position))
                .AddOptions<ReportSchedulerOptions>().Configure<IServiceProvider>((options, provider) =>
                {
                    var preset = provider.GetOptions<PresetReportSchedulerOptions>();
                    options.Interval = preset.TimerInterval;
                });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}