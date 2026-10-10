namespace Layup.Core.Scenes;

using Layup.API;
using UnityEngine;
using MelonLoader;
public class MainMenu(MelonLogger.Instance logger)
{
	private enum ButtonsLayout
	{
		SEASON = 0,
		EXHIBITION_CUSTOMIZE = 1,
		TUTORIAL_SETTINGS = 2,
	}


	public void OnLoad(UserPreferences prefs)
	{
		// Add mods button to bottom middle of menu
		var modsButtonResult = Button.From(API.Utils.Scenes.MainMenu, templateId: "Quit Button", id: "Mods Button", text: "MODS");

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

			if (modsButton == null)
			{
				logger.Error("Unable to create mods button from template");
				return;
			}

			var button = modsButton.GetComponent<UnityEngine.UI.Button>();

			if (button == null)
			{
				logger.Error("Unable to find button component on mods button");
				return;
			}

			button.onClick = new UnityEngine.UI.Button.ButtonClickedEvent();
			button.onClick.AddListener((UnityEngine.Events.UnityAction)(() => logger.Msg("CLICKED!")));

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

}
