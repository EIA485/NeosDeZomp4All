using HarmonyLib;
using NeosModLoader;
using System;
using FrooxEngine;
using FrooxEngine.UIX;

namespace DeZomp4All
{
	public class DeZomp4All : NeosMod
	{
		public override string Name => "DeZomp4All";
		public override string Author => "eia485";
		public override string Version => "1.0.0";
		public override string Link => "https://github.com/EIA485/NeosDeZomp4All/";
		public override void OnEngineInit()
		{
			Harmony harmony = new Harmony("net.eia485.DeZomp4All");
			harmony.PatchAll();
		}

		[HarmonyPatch(typeof(SkinnedMeshRenderer), "BuildInspectorUI")]
		class ExtendCompatibilityPatch
		{
			static void Postfix(UIBuilder ui, SkinnedMeshRenderer __instance)
			{
				string text;
				if (__instance.World.GetUserByAllocationID(ui.Canvas.ReferenceID.User)?.UserID == "U-Cyro")
					text = "FizBuz";
				else
					text = "DeZomp";

				try
				{
					ui.Current.GetComponentInChildren<LocaleStringDriver>().Key.Value = text;
				}
				catch(Exception e)
				{
					Error("something went wrong"+e.ToString());
				}

			}
		}
	}
}