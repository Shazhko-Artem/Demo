using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NotificationCenter.BusinessLogic.Abstractions;
using NotificationCenter.Core.Options.Reports;

namespace NotificationCenter.Api.Schedulers
{
    public class ReportScheduler : IHostedService
    {
        private readonly IReportsGenerator reportsGenerator;
        private readonly System.Timers.Timer timer;

        public ReportScheduler(IReportsGenerator reportsGenerator, IOptions<ReportSchedulerOptions> options)
        {
            this.reportsGenerator = reportsGenerator;
            this.timer = new System.Timers.Timer(options.Value.Interval);
            this.timer.Elapsed += this.OnTimedEvent;
            this.timer.AutoReset = true;
            this.timer.Enabled = false;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.timer.Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.timer.Stop();
            return Task.CompletedTask;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            this.reportsGenerator.Create();
        }
    }
}