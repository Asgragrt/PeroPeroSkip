using MelonLoader;
using SkipLogo.Managers;
using SkipLogo.Patches;
using SkipLogo.Properties;

namespace SkipLogo;

using static SettingsManager;

public class Main : MelonMod
{
    public override void OnInitializeMelon()
    {
        Load();
        PatchMethods();
        LoggerInstance.Msg($"{MelonBuildInfo.ModName} has loaded correctly!");
    }

    private void PatchMethods()
    {
        if (!IsEnabled) return;

        if (SkipToHome)
        {
            SkipToHomePatch.Patch(HarmonyInstance);
            return;
        }

        if (SkipToWelcome)
        {
            SkipToWelcomePatch.Patch(HarmonyInstance);
        }
    }
}