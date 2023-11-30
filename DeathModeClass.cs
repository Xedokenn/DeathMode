using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using MelonLoader;
using HarmonyLib;


namespace DeathMode
{
    public class DeathModeClass : MelonMod // This  shit is needed

    public static DeathModeClass instance;
    private statick KeyCode StartModeToggleKey;
    private static bool Killed;
    private static float BaseTimeScale;


    { 
        public override void OnInitializeMelon() // On Game start print hello world
        {
            LoggerInstance.Msg("Hello World!");
            instance = this;
            StartModeToggleKey = KeyCode.Space;
        }

        public override void OnLateUpdate()
        {
            if (Input.GetKeyDown(StartModeToggleKey))
            {
                ToggleKill();
            }
        }

        public static void DrawKilledText()
        {
            GUI.Label(new Rect(20, 20, 1000, 200), "<b><color=cyan><size=100>Killed</size></color></b>");
        }


        private static void ToggleKill()
        {
            Killed = !Killed;

            if (Killed)
            {
                instance.LoggerInstance.Msg("Killing");
                
                MelonEvents.OnGUI.Subscribe(DrawKilledText, 100); // Register the 'Killed' label
                baseTimeScale = Time.timeScale; // Save the original time scale before Kill
                Time.timeScale = 0;
            }
            else
            {
                instance.LoggerInstance.Msg("Zmartwychwstanie");
                
                MelonEvents.OnGUI.Unsubscribe(DrawKilledText); // Unregister the 'Frozen' label
                Time.timeScale = baseTimeScale; // Reset the time scale to what it was before we froze the time
            }
        }

        public override void OnDeinitializeMelon()
        {
            if (Killed)
            {
                ToggleKill(); // UnKill the game in case the melon gets unregistered
            }
        }

        public override void OnUpdate()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                LoggerInstance.Log("You just pressed T");
            }
        }




        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            LoggerInstance.Msg($"Scene {sceneName} with build index {buildIndex} has been loaded!");
            if (buildIndex == -1) // When you started playing on map, do: 
            {
                LoggerInstance.Msg($"You are on map, congrats :)"); //From there you wanna start the mod
                LoggerInstance.Msg($"Scene {sceneName} with build index {buildIndex}");
            }
        }
    }
}
