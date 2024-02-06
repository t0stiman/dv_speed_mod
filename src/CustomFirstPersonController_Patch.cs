using HarmonyLib;

namespace speeeed
{
	[HarmonyPatch(typeof(CustomFirstPersonController))]
	[HarmonyPatch("ProcessInputAndGetSpeed")]
	public class CustomFirstPersonController_Patch
	{
		private static void Postfix(ref float __result)
		{
			__result *= Main.MySettings.movementSpeedMultiplier;
		}
	}
	
	[HarmonyPatch(typeof(CustomFirstPersonController))]
	[HarmonyPatch("SetJumpParameters")]
	public class SetJumpParameters_Patch
	{
		private static void Postfix(ref CustomFirstPersonController __instance)
		{
			__instance.m_MoveDir.y *= Main.MySettings.jumpSpeedMultiplier;
		}
	}
}