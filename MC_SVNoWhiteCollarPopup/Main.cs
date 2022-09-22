using BepInEx;
using HarmonyLib;

[BepInPlugin(pluginGuid, pluginName, pluginVersion)]
public class Main : BaseUnityPlugin
{
    public const string pluginGuid = "mc.starvalor.nowhitecollarpopup";
    public const string pluginName = "SV No White Collar Popup";
    public const string pluginVersion = "1.0.0";

    public void Awake()
    {
        Harmony.CreateAndPatchAll(typeof(Main));
    }

    [HarmonyPatch(typeof(QuestDB), nameof(QuestDB.StartQuest))]
    [HarmonyPrefix]
    public static bool QuestDBStartQuest_Pre(int questID)
    {
        //QuestDB.StartQuest(126, 0, false);
        if (questID == 126)
            return false;

        return true;
    }
}
