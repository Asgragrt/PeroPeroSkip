using System.Reflection;
using Il2CppAccount;
using Il2CppAssets.Scripts.GameCore.Managers;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppUI.Welcome;
using PeroPeroSkip.Utils;
using AccessTools = HarmonyLib.AccessTools;
using HarmonyMethod = HarmonyLib.HarmonyMethod;

namespace PeroPeroSkip.Patches;

internal static class SkipToWelcomePatch
{
    internal static void Patch(HarmonyLib.Harmony harmony)
    {
        var prefix = Prefix;
        harmony.Patch(TargetMethod(), new HarmonyMethod(prefix.Method));
        Logger.Debug("Patched WelcomeProgram.Start.");
    }

    private static bool Prefix(WelcomeProgram __instance)
    {
        Logger.Debug("Skipping to welcome scene.");
        var mainManager = Singleton<MainManager>.instance;
        mainManager.InitLanguageFirst();

        var pnlWelcome = __instance.pnlWelcome;
        pnlWelcome.SetActive(true);

        GameAccountSystem.instance.isOnActive = true;
        return false;
    }

    private static MethodBase TargetMethod() =>
        AccessTools.Method(typeof(WelcomeProgram), nameof(WelcomeProgram.Start));
}