using System.Reflection;
using Il2CppAccount;
using Il2CppAssets.Scripts.GameCore.Managers;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;
using Il2CppPeroTools2.Account.Internal;
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

        // Required initialization to avoid problems for skipping welcome screen.
        try
        {
            Logger.Debug("Initializing \'MDSteamAchievementManager\'...");

            Singleton<MDSteamAchievementManager>.instance.Init();

            Logger.Debug("Initialized \'MDSteamAchievementManager\'!");
        }
        catch (Exception e)
        {
            Logger.Error($"Error while initializing \'MDSteamAchievementManager\'\n{e}");
        }

        try
        {
            Logger.Debug("Initializing \'AccountManager\'...");

            var accSystem = GameAccountSystem.instance;
            AccountManager.instance.Init("product", accSystem.GetLanguage(), accSystem.platform_name);

            Logger.Debug("Initialized \'AccountManager\'!");
        }
        catch (Exception e)
        {
            Logger.Error($"Error while initializing \'AccountManager\'\n{e}");
        }
    }

    private static MethodBase TargetMethod() =>
        AccessTools.Method(typeof(SceneManager), nameof(SceneManager.LoadSceneSync));
}