namespace Layup.API.Components;

using UnityEngine;
public interface IComponent
{
	GameObject Object { get; }

	string Name { get; }
}
