namespace Layup.API.Components;

using UnityEngine;
using UnityEngine.UI;

public sealed class Label : Component
{
	public Text TextComponent { get; }
	public string Text
	{
		get => TextComponent.text;
		set => TextComponent.text = value;
	}

	public Label(Text template, string text, Styles.TextStyle style) : base(new GameObject("Label"))
	{
		Object.AddComponent<RectTransform>();
		TextComponent = Object.AddComponent<Text>();
		TextComponent.font = template.font;
		TextComponent.material = template.material;
		TextComponent.color = template.color;
		TextComponent.fontStyle = template.fontStyle;
		TextComponent.lineSpacing = template.lineSpacing;
		Text = text;
		style.Apply(TextComponent);
	}
}
