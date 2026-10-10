namespace Layup.API.Components;

using UnityEngine;
public interface IComponent
{
	GameObject Object { get; }

	string Name { get => Object.name; }


	public void Show() => Object.SetActive(true);
	public void Hide() => Object.SetActive(false);
}
