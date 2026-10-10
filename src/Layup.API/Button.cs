namespace Layup.API;

using FluentResults;
using UnityEngine;

public class Button(GameObject buttonObject)
{
	public GameObject Object { get => buttonObject; }
	public static Result<Button> From(GameObject context, string templateId, string id, string text)
	{
		var templateBtn = context.transform.Find(templateId);
		if (templateBtn == null)
			return Result.Fail($"Unable to locate template at template ID {templateId}");

		var newBtn = UnityEngine.Object.Instantiate(
			templateBtn.gameObject, context.transform, false);

		newBtn.name = id;
		var label = newBtn.GetComponentInChildren<UnityEngine.UI.Text>(true);
		label?.text = text;

		return Result.Ok(new Button(newBtn));
	}

}
