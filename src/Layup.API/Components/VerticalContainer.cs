namespace Layup.API.Components;

using UnityEngine;
using UnityEngine.UI;

public sealed class VerticalContainer : Component
{
	private readonly VerticalLayoutGroup layout;

	public Vector2 Padding
	{
		get => new(layout.padding.left, layout.padding.top);
		set => layout.padding = new RectOffset((int)value.x, (int)value.x, (int)value.y, (int)value.y);
	}
	public float Spacing
	{
		get => layout.spacing;
		set => layout.spacing = value;
	}
	public TextAnchor Alignment
	{
		get => layout.childAlignment;
		set => layout.childAlignment = value;
	}

	public VerticalContainer(GameObject parent) : base(new GameObject("Vertical Container"))
	{
		var rect = Object.AddComponent<RectTransform>();
		rect.SetParent(parent.transform, false);
		rect.anchorMin = Vector2.zero;
		rect.anchorMax = Vector2.one;
		rect.offsetMin = Vector2.zero;
		rect.offsetMax = Vector2.zero;

		layout = Object.AddComponent<VerticalLayoutGroup>();
		layout.childControlWidth = true;
		layout.childControlHeight = true;
		layout.childForceExpandWidth = true;
		layout.childForceExpandHeight = false;
	}

	public void Add(Component child) => child.Object.transform.SetParent(Object.transform, false);
}
