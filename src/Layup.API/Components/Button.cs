namespace Layup.API.Components;

using FluentResults;
using UnityEngine;

// NOTE: This is NOT the cleanest implementation to do this w/. I'm still experimenting w/ APIs & designs as I explore Unity modding and this specific game
public class Button(GameObject gameObject) : Component(gameObject)
{
	public UnityEngine.UI.Button Component { get => Object.GetComponent<UnityEngine.UI.Button>() ?? throw new InvalidOperationException("Unable to locate button component"); }

	public void AddClickListener(UnityEngine.Events.UnityAction action)
	{
		Component.onClick.AddListener(action);
	}
	public static Result<Button> From(GameObject parent, string templateId, string id, string text)
	{
		var templateBtn = parent.transform.Find(templateId);
		if (templateBtn == null)
			return Result.Fail($"Unable to locate template at template ID {templateId}");

		var newBtn = Utils.Cloning.CreateInactive(templateBtn.gameObject, parent.transform);
		newBtn.name = id;
		var label = newBtn.GetComponentInChildren<UnityEngine.UI.Text>(true);
		label?.text = text;

		var component = newBtn.GetComponent<UnityEngine.UI.Button>();
		component.onClick = new UnityEngine.UI.Button.ButtonClickedEvent();

		return Result.Ok(new Button(newBtn));
	}

	public static Button Back(string id)
	{
		var seasonSaves = Utils.Scenes.SeasonSaves;
		var backButton = seasonSaves.transform.Find("Back Button") ?? throw new InvalidOperationException("Unable to locate the season save's back button.");

		var cloned = Utils.Cloning.CreateInactive(backButton.gameObject, seasonSaves.transform);
		cloned.name = id;


		var component = cloned.GetComponent<UnityEngine.UI.Button>();
		component.onClick = new UnityEngine.UI.Button.ButtonClickedEvent();

		return new Button(cloned);
	}

}
