namespace Layup.API.Components;

using UnityEngine;
public class Viewport : Component
{
	public GameObject Content { get => Object.transform.Find("Content")?.gameObject ?? throw new InvalidOperationException("Unable to locate associated content with this viewport"); }

	public Viewport(string name) : base(CreateInstance())
	{
		Object.name = name;
		Utils.Cloning.Clear(Content);
	}

	public void Add(Component child)
	{
		child.Object.transform.SetParent(Content.transform, false);
	}


	// TODO: Maybe it's worth copying styles + such
	private static GameObject CreateInstance()
	{
		var mainMenu = Utils.Scenes.SeasonLeaders;
		var viewport = mainMenu.transform.Find("Panel/Single Season/Viewport") ?? throw new InvalidOperationException("Unable to locate the season leaders' Viewport.");
		return Utils.Cloning.CreateInactive(viewport.gameObject, mainMenu.transform);
	}
}
