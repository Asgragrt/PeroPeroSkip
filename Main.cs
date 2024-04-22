using MelonLoader;
using PeroPeroSkip.Managers;
using PeroPeroSkip.Properties;
using PeroPeroSkip.Utils;

namespace PeroPeroSkip;

public class Main : MelonMod
{
    public override void OnInitializeMelon()
    {
        SettingsManager.Load();
        ModManager.Init(HarmonyInstance);
        Logger.Msg($"{MelonBuildInfo.ModName} has loaded correctly!");
    }
}