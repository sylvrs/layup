namespace Layup.Core.Scenes;

using Layup.API.Components;
using UnityEngine;
using FluentResults;
using MelonLoader;
public class MainMenu(MelonLogger.Instance logger)
{
	private enum ButtonsLayout
	{
		SEASON = 0,
		EXHIBITION_CUSTOMIZE = 1,
		TUTORIAL_SETTINGS = 2,
	}

	public API.Screen MainMenuScreen = new(API.Utils.Scenes.MainMenu);
	public API.Screen? ModsScreen { get; private set; }

	public void OnLoad(UserPreferences prefs)
	{
		// Add mods button to bottom middle of menu
		var modsButtonResult = Button.From(API.Utils.Scenes.MainMenu, templateId: "Quit Button", id: "Mods Button", text: "MODS");

		var screenResult = API.Screen.CreateFrom(categoryId: "Season/League", templateId: "Season Leaders", name: "Mods Screen");
		if (screenResult.IsSuccess)
		{
			ModsScreen = screenResult.Value;
			ModsScreen.KeepChildren();
			ModsScreen.Object.transform.SetParent(MainMenuScreen.Object.transform.parent, false);

			var header = new ScrollingHeader(name: "Scrolling Header", text: "MODS MENU");
			ModsScreen.Add(header);

			var panel = new Panel(name: "Panel", clear: true);
			ModsScreen.Add(panel);


			var backButton = Button.Back(id: "Mods - Back Button");
			ModsScreen.Add(backButton);
			backButton.AddClickListener((UnityEngine.Events.UnityAction)(() => OnBackModsScreen()));

			ModsScreen.ShowAll();
		}

		if (modsButtonResult.IsSuccess)
		{
			var btn = modsButtonResult.Value;
			var modsButton = btn.Object;

			modsButton.transform.SetAsLastSibling();
			var pos = modsButton.transform.localPosition;
			var transform = modsButton.GetComponent<RectTransform>();
			// Keep it on the same y & z axis but put it in the middle
			modsButton.transform.localPosition = new Vector3(0 - (transform.rect.xMax / 2f), pos.y, pos.z);
			modsButton.SetActive(true);

			btn.AddClickListener((UnityEngine.Events.UnityAction)(() => OnOpenModsScreen()));
		}


		if (prefs.HideTutorial)
		{
			var buttonsList = API.Utils.Scenes.MainMenu.transform.Find("Panel/Menu Buttons/Buttons");
			var buttons = buttonsList.GetChild((int)ButtonsLayout.TUTORIAL_SETTINGS);

			var tutorialBtn = buttons.Find("Tutorial");
			// TODO: center settings button 
			tutorialBtn?.gameObject.SetActive(false);
		}

	}

	public Result OnOpenModsScreen()
	{
		var screen = ModsScreen?.Object;
		if (screen == null)
		{
			return Result.Fail("Missing mods screen");
		}

		MainMenuScreen.Object.SetActive(false);
		screen.SetActive(true);

		return Result.Ok();
	}

	public Result OnBackModsScreen()
	{
		var screen = ModsScreen?.Object;
		if (screen == null)
		{
			return Result.Fail("Missing mods screen");
		}

		MainMenuScreen.Object.SetActive(true);
		screen.SetActive(false);

		return Result.Ok();
	}

}
