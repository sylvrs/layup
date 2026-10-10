namespace Layup.API.Utils;

using UnityEngine;

internal static class Cloning
{
	public static GameObject CreateInactive(GameObject template, Transform parent)
	{
		var staging = new GameObject("CLONE_STAGING");
		staging.SetActive(false);
		try
		{
			var clone = Object.Instantiate(template, staging.transform, false) ?? throw new InvalidOperationException($"Cloning '{template.name}' failed.");
			clone.SetActive(false);
			clone.transform.SetParent(parent, false);
			return clone;
		}
		finally
		{
			Object.Destroy(staging);
		}
	}
}
