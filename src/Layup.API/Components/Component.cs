namespace Layup.API.Components;

using UnityEngine;
public abstract class Component(GameObject gameObject)
{
	public GameObject Object { get; set; } = gameObject;

	public string Name { get => Object.name; }

	public void Show() => Object.SetActive(true);
	public void Hide() => Object.SetActive(false);
}
