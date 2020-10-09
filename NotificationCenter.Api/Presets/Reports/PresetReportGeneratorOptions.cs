using NotificationCenter.Api.Constants;
using NotificationCenter.Core.Options.Reports;

namespace NotificationCenter.Api.Presets.Reports
{
    public class PresetReportGeneratorOptions : IPreset<ReportGeneratorOptions>
    {
        public const string Position = ConfigurationSectionNameConstants.Reports;
    }
}