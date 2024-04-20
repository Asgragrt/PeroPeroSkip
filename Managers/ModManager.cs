using PeroPeroSkip.Patches;

namespace PeroPeroSkip.Managers;

using static SettingsManager;

internal static class ModManager
{
    internal static void PatchMethods(HarmonyLib.Harmony harmony)
    {
        if (!IsEnabled) return;

        if (SkipToHome)
        {
            SkipToHomePatch.Patch(harmony);
            return;
        }

        if (SkipToWelcome)
        {
            SkipToWelcomePatch.Patch(harmony);
        }
    }
}