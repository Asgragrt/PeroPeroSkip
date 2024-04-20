using MelonLoader;
using SkipLogo.Managers;
using SkipLogo.Properties;

namespace SkipLogo;

using static SettingsManager;
using static ModManager;

public class Main : MelonMod
{
    public override void OnInitializeMelon()
    {
        Load();
        PatchMethods(HarmonyInstance);
        LoggerInstance.Msg($"{MelonBuildInfo.ModName} has loaded correctly!");
    }
}