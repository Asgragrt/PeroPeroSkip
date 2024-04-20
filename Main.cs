using MelonLoader;
using PeroPeroSkip.Managers;
using PeroPeroSkip.Properties;

namespace PeroPeroSkip;

using static ModManager;
using static SettingsManager;

public class Main : MelonMod
{
    public override void OnInitializeMelon()
    {
        Load();
        PatchMethods(HarmonyInstance);
        LoggerInstance.Msg($"{MelonBuildInfo.ModName} has loaded correctly!");
    }
}