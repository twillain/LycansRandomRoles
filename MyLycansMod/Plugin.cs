using HarmonyLib;
using BepInEx;
using UnityEngine;
using LycansNewRoles;
using System;
using Random = System.Random;
using TMPro;

namespace MyLycansMod
{
    [BepInPlugin("com.yourname.traiteurpatch", "Traitor Count Patch", "1.0.0")]
    public class MyLycansMod : BaseUnityPlugin
    {
        // Référence statique à l'instance de votre plugin
        public static MyLycansMod Instance;

        public void Awake()
        {
            // Assigner l'instance de ce plugin à la variable statique
            Instance = this;
            
            var harmony = new Harmony("com.traitormod");
            harmony.PatchAll();  // Patch tout le code
            Logger.LogInfo("Traitor Count Patch Loaded");
        }

        // Patch de la méthode Spawned de la classe GameConfig
        [HarmonyPatch(typeof(PlayerCustom), "Reset")]
        public static class PatchSpawnedMethod
        {
            // Cette méthode sera exécutée après la méthode Spawned()
            public static void Postfix(PlayerCustom __instance)
            {
                try
                {
                    
                    if (PlayerCustomRegistry.AllPlayers[0] != __instance) return;

                    int SoloRolesCount = int.Parse(GameConfig.SoloRolesCountConfig.options[GameConfig.SoloRolesCountConfig.value].text);
                    int TraitorsCount = int.Parse(GameConfig.TraitorsCountConfig.options[GameConfig.TraitorsCountConfig.value].text);
                    int PowersCount = int.Parse(GameConfig.PowersCountConfig.options[GameConfig.PowersCountConfig.value].text);
                    int SecondaryRolesCount = int.Parse(GameConfig.SecondaryRolesCountConfig.options[GameConfig.SecondaryRolesCountConfig.value].text);


                    Random rand = new Random();

                    Instance.Logger.LogInfo("============================================================");

                    int randomTraitorCount = rand.Next(0, TraitorsCount+1);
                    Plugin.CustomConfig.TraitorsCount = randomTraitorCount;

                    Instance.Logger.LogInfo("TraitorsCount : " + Plugin.CustomConfig.TraitorsCount);

                    int randomSoloRoleCount = rand.Next(0, SoloRolesCount+1);
                    Plugin.CustomConfig.SoloRolesCount = randomSoloRoleCount;

                    Instance.Logger.LogInfo("SoloRolesCount : " + Plugin.CustomConfig.SoloRolesCount);

                    int randomSecondaryRoleCount = rand.Next(0, SecondaryRolesCount+1);
                    Plugin.CustomConfig.SecondaryRolesCount = randomSecondaryRoleCount;

                    Instance.Logger.LogInfo("SecondaryRolesCount : " + Plugin.CustomConfig.SecondaryRolesCount);

                    int randomPowerCount = rand.Next(0, PowersCount+1);
                    Plugin.CustomConfig.PowersCount = randomPowerCount;

                    Instance.Logger.LogInfo("PowerCount : " + Plugin.CustomConfig.PowersCount);

                    int randomNightFog = rand.Next(0,11);

                    GameConfig.NightFogDropdown.value = randomNightFog;

                    Instance.Logger.LogInfo("NightFog : " + randomNightFog*10 + "%");

                    Instance.Logger.LogInfo("============================================================");
                }
                catch (Exception ex)
                {
                    // Log des erreurs avec l'instance du plugin
                    Instance.Logger.LogError("Erreur lors du patch de la méthode Reset : " + ex);
                }
            }
        }

    }
}
