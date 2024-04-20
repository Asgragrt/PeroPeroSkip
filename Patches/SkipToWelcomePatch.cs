using System.Reflection;
using Il2CppAccount;
using Il2CppAssets.Scripts.GameCore.Managers;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppUI.Welcome;
using MelonLoader;
using AccessTools = HarmonyLib.AccessTools;
using HarmonyMethod = HarmonyLib.HarmonyMethod;

namespace SkipLogo.Patches;

internal static class SkipToWelcomePatch
{
    internal static void Patch(HarmonyLib.Harmony harmony)
    {
        var prefix = Prefix;
        harmony.Patch(TargetMethod(), new HarmonyMethod(prefix.Method));
        Melon<Main>.Logger.Msg("Patched WelcomeProgram.Start");
    }

    private static bool Prefix(WelcomeProgram __instance)
    {
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