using Microsoft.Extensions.Options;
using NotificationCenter.BusinessLogic.Abstractions;
using NotificationCenter.Core.Options;
using System;
using System.IO;
using System.Threading.Tasks;
using NotificationCenter.Core.Options.Reports;

namespace NotificationCenter.BusinessLogic
{
    public class ReportsGenerator : IReportsGenerator
    {
        private readonly IOptionsMonitor<ReportGeneratorOptions> options;

        public ReportsGenerator(IOptionsMonitor<ReportGeneratorOptions> options)
        {
            this.options = options;
        }

        public async Task Create()
        {
            var directory = this.options.CurrentValue.Directory;
            var directoryInfo = new DirectoryInfo(directory);
            directoryInfo.Create();
            var fileName = $"{directoryInfo.FullName}\\{DateTime.Now:yy-MM-dd hh-mm-ss tt}.txt";
            await File.WriteAllTextAsync(fileName, "Some report");
        }
    }
}