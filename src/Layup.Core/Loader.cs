using MelonLoader;
using Layup.Core.Scenes;

[assembly: MelonInfo(typeof(Layup.Core.Loader), "Layup", "1.0.0", "sylvrs", null)]
[assembly: MelonGame("Koality Game", "Hoop Land")]
namespace Layup.Core;


public class Loader : MelonMod
{
	private readonly UserPreferences userPrefs = new();
	public override void OnSceneWasInitialized(int buildIndex, string sceneName)
	{
		switch (sceneName)
		{
			case "Menu":
				var mainMenu = new MainMenu(LoggerInstance);
				mainMenu.OnLoad(userPrefs);
				break;
		}
	}
}
