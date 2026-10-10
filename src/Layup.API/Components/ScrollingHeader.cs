namespace Layup.API.Components;

using UnityEngine;
public class ScrollingHeader : IComponent
{
	public GameObject Object { get; }

	public ScrollingHeader(string name, string text)
	{
		Object = CreateInstance();
		Object.name = name;

		foreach (var label in Object.GetComponentsInChildren<UnityEngine.UI.Text>(true))
			label.text = text;
	}


	// TODO: Maybe it's worth copying styles + such
	private static GameObject CreateInstance()
	{
		var mainMenu = Utils.Scenes.MainMenu;
		var header = mainMenu.transform.Find("Scrolling Header") ?? throw new InvalidOperationException("Unable to locate the main menu's Scrolling Header.");
		return Utils.Cloning.CreateInactive(header.gameObject, mainMenu.transform);
	}
}
