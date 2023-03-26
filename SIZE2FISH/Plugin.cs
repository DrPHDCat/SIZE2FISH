using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace SIZE2FISH
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
            Harmony harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
        }
    }
    [HarmonyPatch(typeof(FishingHUD), "Start")]
    static public class SIZE2FISH
    {
        [HarmonyPostfix]
        static public void Postfix(FishingHUD __instance, ref GameObject ___fishSizeContainer)
        {
            ___fishSizeContainer.GetComponent<UnityEngine.UI.Text>().text = "SIZE: 2";
        }
    }
}