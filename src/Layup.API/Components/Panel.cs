namespace Layup.API.Components;

using UnityEngine;
public class Panel : Component
{

	public Panel(string name, bool clear) : base(CreateInstance(clear))
	{
		Object.name = name;
	}

	public void Add(Component component)
	{
		component.Object.transform.SetParent(Object.transform, false);
	}



	// TODO: Maybe it's worth copying styles + such
	private static GameObject CreateInstance(bool clear)
	{
		var mainMenu = Utils.Scenes.MainMenu;
		var panel = mainMenu.transform.Find("Panel") ?? throw new InvalidOperationException("Unable to locate the main menu's Panel.");

		return Utils.Cloning.CreateInactive(panel.gameObject, mainMenu.transform, clear);
	}
}
