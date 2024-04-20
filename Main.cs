using MelonLoader;
using PeroPeroSkip.Managers;
using PeroPeroSkip.Properties;
using PeroPeroSkip.Utils;

namespace PeroPeroSkip;

using static ModManager;
using static SettingsManager;

public class Main : MelonMod
{
    public override void OnInitializeMelon()
    {
        Load();
        PatchMethods(HarmonyInstance);
        Logger.Msg($"{MelonBuildInfo.ModName} has loaded correctly!");
    }
}