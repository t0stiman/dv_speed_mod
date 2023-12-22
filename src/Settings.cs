using UnityEngine;
using UnityModManagerNet;

namespace speeeed
{
	public class Settings : UnityModManager.ModSettings
	{
		public float movementSpeedMultiplier = 2.5f;
		private string moveText = "";
		
		public float jumpSpeedMultiplier = 2f;
		private string jumpText = "";
		
		public void Draw(UnityModManager.ModEntry modEntry)
		{
			{
				if (moveText == "")
				{
					moveText = movementSpeedMultiplier.ToString();
				}

				GUILayout.Label("Movement speed multiplier");
				moveText = GUILayout.TextField(moveText);

				if (float.TryParse(moveText, out var newValue))
				{
					movementSpeedMultiplier = newValue;
				}
				else
				{
					GUILayout.Label($"'{moveText}' is not a number");
				}
			}
			
			// ====================
			
			{
				if (jumpText == "")
				{
					jumpText = jumpSpeedMultiplier.ToString();
				}

				GUILayout.Label("Jump speed multiplier");
				jumpText = GUILayout.TextField(jumpText);

				if (float.TryParse(jumpText, out var newValue))
				{
					jumpSpeedMultiplier = newValue;
				}
				else
				{
					GUILayout.Label($"'{jumpText}' is not a number");
				}
			}
		}

		public override void Save(UnityModManager.ModEntry modEntry)
		{
			Save(this, modEntry);
		}
	}
}