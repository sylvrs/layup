namespace Layup.Core.Utils;

using UnityEngine;

public static class Buttons
{
	public static GameObject? Create(GameObject context, string templateId, string id, string text)
	{
		// We only want to add it once
		var btn = context.transform.Find(id);
		if (btn != null)
			return btn.gameObject;

		var templateBtn = context.transform.Find(templateId);
		if (templateBtn == null)
			return null;

		var newBtn = Object.Instantiate(
			templateBtn.gameObject, context.transform, false);

		newBtn.name = id;
		var label = newBtn.GetComponentInChildren<UnityEngine.UI.Text>(true);
		label?.text = text;



		return newBtn;
	}

}
