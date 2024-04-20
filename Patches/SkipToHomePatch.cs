using System.Reflection;
using Il2CppAssets.Scripts.PeroTools.Managers;
using MelonLoader;
using PeroPeroSkip.Utils;
using AccessTools = HarmonyLib.AccessTools;
using HarmonyMethod = HarmonyLib.HarmonyMethod;

namespace PeroPeroSkip.Patches;

internal static class SkipToHomePatch
{
    private const string SystemScene = "UISystem_PC";

    internal static void Patch(HarmonyLib.Harmony harmony)
    {
        var prefix = Prefix;
        harmony.Patch(TargetMethod(), new HarmonyMethod(prefix.Method));
        Logger.Debug("Patched SceneManager.LoadSceneSync.");
    }

    private static void Prefix(ref string sName)
    {
        if (!sName.Contains("Welcome")) return;

        sName = SystemScene;
        
        Logger.Debug($"Renamed scene to {sName}.");
    }

    private static MethodBase TargetMethod() =>
        AccessTools.Method(typeof(SceneManager), nameof(SceneManager.LoadSceneSync));
}