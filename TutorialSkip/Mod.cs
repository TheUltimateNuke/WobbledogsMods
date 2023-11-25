using BepInEx;
using BepInEx.Configuration;
using System.Threading.Tasks;
//using WobbleOn.Debugging;

namespace TutorialSkip
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Mod : BaseUnityPlugin
    {
        public static ConfigFile ModConfig { get; private set; }

        //public static ExposeClassFieldsToConfig exposed_CheatEngine;

        private void Awake()
        {
            ModConfig = Config;

            //exposed_CheatEngine = new ExposeClassFieldsToConfig(CheatEngine.cheatRef);
            Logger.LogInfo($"Mod {PluginInfo.PLUGIN_GUID} is loaded!");
        }

        private void UpdateTutorialSkip()
        {
            if (CheatEngine.cheatRef == null) return;
            CheatEngine.cheatRef.tutorialEnabled = false;
            if (TutorialController.IsTutorialActive())
                TutorialController.SetCurrentState(TutorialState.FINAL_UNLOCKS);
        }

        private void Update()
        {
            UpdateTutorialSkip();
        }
    }
}
