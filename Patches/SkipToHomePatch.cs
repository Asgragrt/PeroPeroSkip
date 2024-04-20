using System.Reflection;
using Il2CppAssets.Scripts.PeroTools.Managers;
using MelonLoader;
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
        Melon<Main>.Logger.Msg("Patched SceneManager.LoadSceneSync");
    }

    private static void Prefix(ref string sName)
    {
        if (!sName.Contains("Welcome")) return;

        sName = SystemScene;
    }

    private static MethodBase TargetMethod() =>
        AccessTools.Method(typeof(SceneManager), nameof(SceneManager.LoadSceneSync));
}