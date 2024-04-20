using MelonLoader;
using PeroPeroSkip.Managers;

namespace PeroPeroSkip.Utils;

public static class Logger
{
    private static readonly MelonLogger.Instance LocalLogger = Melon<Main>.Logger;
    internal static void Debug(object message)
    {
        if (!SettingsManager.DebugLog) return;
        LocalLogger.Msg($"[DEBUG]: {message}");
    }

    internal static void Error(object message)
    {
        LocalLogger.Error(message);
    }

    internal static void Msg(object message)
    {
        LocalLogger.Msg(message);
    }

    internal static void Warning(object message)
    {
        LocalLogger.Warning(message);
    }

    private class DebugType(string initMessage, string finishMessage, string errorMessage = "")
    {
        private readonly string StartMessage = initMessage;

        private readonly string FinishMessage = finishMessage;

        private readonly string ErrorMessage = errorMessage;

        internal string Start(object m) => $"{StartMessage} {m}...";
        internal string Finish(object m) => $"{FinishMessage} {m}!";
        internal string Error(object m) => $"Couldn't {ErrorMessage} {m}.";
    }
}