using HarmonyLib;
using Il2CppAssets.Scripts.PeroTools.Managers;

namespace PeroPeroSkip.Patches;

[HarmonyPatch(typeof(SceneManager), nameof(SceneManager.Init))]
internal static class SceneInitPatch
{
    internal static void Postfix(SceneManager __instance)
    {
        __instance.leastLoadingTime = 0f;
    }
}