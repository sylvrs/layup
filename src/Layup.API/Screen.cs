namespace Layup.API;

using FluentResults;
using UnityEngine;

public class Screen(GameObject screenObject)
{
	public GameObject Object { get => screenObject; }


	public List<Components.IComponent> Components = [];
	private const string SafeAreaPath = "Canvas/Safe Area";

	// TODO: wrap our components into this
	public void KeepChildren(params List<string> childNames)
	{
		for (int i = Object.transform.childCount - 1; i >= 0; i--)
		{
			var child = Object.transform.GetChild(i);
			if (childNames.Contains(child.name))
			{
				continue;
			}
			child.gameObject.SetActive(false);
			UnityEngine.Object.Destroy(child.gameObject);
		}
	}

	public void Add(Components.IComponent component)
	{
		Components.Add(component);
		component.Object.transform.SetParent(Object.transform, false);
	}

	public void ShowAll()
	{
		foreach (Components.IComponent component in Components)
		{
			component.Show();
		}
	}
	public static Result<Screen> CreateFrom(string categoryId, string templateId, string name)
	{
		var screen = GameObject.Find($"{SafeAreaPath}/{categoryId}/{templateId}");


		if (screen == null)
			return Result.Fail($"Unable to locate template at {SafeAreaPath}/{categoryId}/{templateId}");

		var clone = Utils.Cloning.CreateInactive(screen, screen.transform.parent);
		clone.name = name;

		return Result.Ok(new Screen(clone));
	}
}
