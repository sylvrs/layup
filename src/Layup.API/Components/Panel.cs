namespace Layup.API.Components;

using UnityEngine;
public class Panel : IComponent
{
	public GameObject Object { get; }

	public Panel(string name, bool clear)
	{
		Object = CreateInstance(clear);
		Object.name = name;
	}


	// TODO: Maybe it's worth copying styles + such
	private static GameObject CreateInstance(bool clear)
	{
		var mainMenu = Utils.Scenes.MainMenu;
		var panel = mainMenu.transform.Find("Panel") ?? throw new InvalidOperationException("Unable to locate the main menu's Panel.");

		var cloned = Utils.Cloning.CreateInactive(panel.gameObject, mainMenu.transform);

		if (clear)
		{
			for (int i = cloned.transform.childCount - 1; i >= 0; i--)
			{
				var child = cloned.transform.GetChild(i);
				child.gameObject.SetActive(false);
				UnityEngine.Object.Destroy(child.gameObject);
			}

		}

		return cloned;
	}
}
