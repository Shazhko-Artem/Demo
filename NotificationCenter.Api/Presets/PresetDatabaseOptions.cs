using NotificationCenter.Api.Constants;
using NotificationCenter.Core.Options;

namespace NotificationCenter.Api.Presets
{
    public class PresetDatabaseOptions : IPreset<DatabaseOptions>
    {
        public const string Position = ConfigurationSectionNameConstants.Database;
    }
}