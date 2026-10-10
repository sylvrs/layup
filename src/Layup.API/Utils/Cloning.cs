namespace Layup.API.Utils;

using UnityEngine;

internal static class Cloning
{
	public static GameObject CreateInactive(GameObject template, Transform parent, bool clear = false)
	{
		var staging = new GameObject("CLONE_STAGING");
		staging.SetActive(false);
		try
		{
			var clone = Object.Instantiate(template, staging.transform, false) ?? throw new InvalidOperationException($"Cloning '{template.name}' failed.");
			clone.SetActive(false);
			clone.transform.SetParent(parent, false);

			if (clear)
			{
				Clear(clone);
			}

			return clone;
		}
		finally
		{
			Object.Destroy(staging);
		}
	}

	public static void Clear(GameObject gameObject)
	{
		for (int i = gameObject.transform.childCount - 1; i >= 0; i--)
		{
			var child = gameObject.transform.GetChild(i);
			child.gameObject.SetActive(false);
			Object.Destroy(child.gameObject);
		}

	}
}
