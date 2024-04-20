using PeroPeroSkip.Patches;
using PeroPeroSkip.Utils;

namespace PeroPeroSkip.Managers;

using static SettingsManager;

internal static class ModManager
{
    internal static void PatchMethods(HarmonyLib.Harmony harmony)
    {
        if (!IsEnabled)
        {
            Logger.Debug("No patch is enabled!");
            return;
        }

        if (SkipToHome)
        {
            Logger.Debug("Patching SkipToHome...");
            SkipToHomePatch.Patch(harmony);
            Logger.Debug("Patched SkipToHome!");
            return;
        }

        if (SkipToWelcome)
        {
            Logger.Debug("Patching SkipToWelcome...");
            SkipToWelcomePatch.Patch(harmony);
            Logger.Debug("Patched SkipToWelcome!");
        }
    }
}