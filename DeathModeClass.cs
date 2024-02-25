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
            if (buildIndex == -1)
            {
                LoggerInstance.Msg($"You are plaing on map right now");
            }
        }

        public override void OnUpdate()
        {
            CameraContoller Camera = GameObject.Find("Camera").GetComponent<CameraContoller>();
            if (Input.GetKeyUp(KeyCode.Keypad6))
            {
                LoggerInstance.Msg($"brou what the fuck");
            }
        }
        }
}