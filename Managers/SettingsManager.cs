using MelonLoader;
using PeroPeroSkip.Properties;

namespace PeroPeroSkip.Managers;

using static MelonBuildInfo;

internal static class SettingsManager
{
    private const string SettingsPath = $"UserData/{ModName}.cfg";

    private static MelonPreferences_Entry<bool> _skipToHome;

    private static MelonPreferences_Entry<bool> _skipToWelcome;

    internal static bool SkipToHome => _skipToHome.Value;

    internal static bool SkipToWelcome => _skipToWelcome.Value;

    internal static bool IsEnabled => SkipToWelcome || SkipToHome;

    internal static void Load()
    {
        var mainCategory = MelonPreferences.CreateCategory(ModName);
        mainCategory.SetFilePath(SettingsPath, true, false);

        _skipToHome = mainCategory.CreateEntry(nameof(SkipToHome), false,
            description: $"Takes precedence over {nameof(SkipToWelcome)}");

        _skipToWelcome = mainCategory.CreateEntry(nameof(SkipToWelcome), true);
    }
}