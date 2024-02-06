using HarmonyLib;

namespace speeeed
{
	/// <summary>
	/// bunny hopping
	/// </summary>
	[HarmonyPatch(typeof(LocomotionInputNonVr))]
	[HarmonyPatch(nameof(LocomotionInputNonVr.JumpRequested), MethodType.Getter)]
	public class LocomotionInputNonVr_JumpRequested_Patch
	{
		private static bool Prefix(ref bool __result)
		{
			if (!Main.MySettings.EnableBunnyHopping)
			{
				return true; //execute original function 
			}

			__result = KeyBindings.jumpKeys.IsPressed();
			
			return false; //skip original function
		}
	}
}