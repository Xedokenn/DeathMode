﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using HarmonyLib;



namespace DeathMode
{
    public class DeathModeClass : MelonMod
    {
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            LoggerInstance.Msg($"Scene {sceneName} with build index {buildIndex} has been loaded!");
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                LoggerInstance.Log("You just pressed T");
            }
        }
}
