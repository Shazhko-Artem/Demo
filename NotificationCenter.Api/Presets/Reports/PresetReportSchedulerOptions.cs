using NotificationCenter.Api.Constants;
using NotificationCenter.Core.Options.Reports;

namespace NotificationCenter.Api.Presets.Reports
{
    public class PresetReportSchedulerOptions : IPreset<ReportSchedulerOptions>
    {
        public const string Position = ConfigurationSectionNameConstants.Reports;

        public int TimerInterval { get; set; }
    }
}