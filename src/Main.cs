﻿using System;
using System.Reflection;
using UnityModManagerNet;
using HarmonyLib;

namespace speeeed
{
	[EnableReloading]
	static class Main
	{
		private static bool enabled;
		private static UnityModManager.ModEntry MyModEntry;
		private static Harmony harmony;
		public static Settings MySettings { get; private set; }

		//================================================================

		private static bool Load(UnityModManager.ModEntry modEntry)
		{
			try
			{
				MyModEntry = modEntry;
				MySettings = UnityModManager.ModSettings.Load<Settings>(modEntry);
				
				modEntry.OnGUI = entry => MySettings.Draw(entry);
				modEntry.OnSaveGUI = entry => MySettings.Save(entry);
				modEntry.OnToggle = OnToggle;
				modEntry.OnUnload = OnUnload;

				harmony = new Harmony(MyModEntry.Info.Id);
				harmony.PatchAll(Assembly.GetExecutingAssembly());
			}
			catch (Exception ex)
			{
				MyModEntry.Logger.LogException($"Failed to load {MyModEntry.Info.DisplayName}:", ex);
				harmony?.UnpatchAll(MyModEntry.Info.Id);
				return false;
			}
			
			modEntry.Logger.Log("loaded");

			return true;
		}

		private static bool OnUnload(UnityModManager.ModEntry modEntry)
		{
			harmony?.UnpatchAll(MyModEntry.Info.Id);
			return true;
		}

		private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value) 
		{
			enabled = value;
			string msg = enabled ? "hello!" : "goodbye!";
			modEntry.Logger.Log(msg);

			return true;
		}

		// Logger Commands
		public static void Log(string message)
		{
			MyModEntry.Logger.Log(message);
		}

		public static void Warning(string message)
		{
			MyModEntry.Logger.Warning(message);
		}

		public static void Error(string message)
		{
			MyModEntry.Logger.Error(message);
		}
	}
}