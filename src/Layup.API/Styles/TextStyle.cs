namespace Layup.API.Styles;

using UnityEngine;
using UnityEngine.UI;

public sealed record TextStyle
{
	public int FontSize { get; init; } = 14;
	public float Height { get; init; } = 18f;
	public Color? Color { get; init; }
	public TextAnchor Alignment { get; init; } = TextAnchor.MiddleCenter;
	public HorizontalWrapMode Wrapping { get; init; } = HorizontalWrapMode.Overflow;
	public bool RichText { get; init; }

	public void Apply(Text text)
	{
		text.fontSize = FontSize;
		text.resizeTextForBestFit = false;
		if (Color.HasValue)
			text.color = Color.Value;
		text.alignment = Alignment;
		text.horizontalOverflow = Wrapping;
		text.verticalOverflow = VerticalWrapMode.Overflow;
		text.supportRichText = RichText;
		text.enabled = true;
		text.raycastTarget = false;
		text.gameObject.SetActive(true);

		var layout = text.GetComponent<LayoutElement>() ?? text.gameObject.AddComponent<LayoutElement>();
		layout.ignoreLayout = false;
		layout.minHeight = Height;
		layout.preferredHeight = Height;
		layout.flexibleHeight = 0f;
	}
}
