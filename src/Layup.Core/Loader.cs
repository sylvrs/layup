using MelonLoader;

[assembly: MelonInfo(typeof(Layup.Core.Loader), "Layup", "1.0.0", "sylvrs", null)]
[assembly: MelonGame("Koality Game", "Hoop Land")]
namespace Layup.Core;


public class Loader : MelonMod
{
	public override void OnSceneWasLoaded(int buildIndex, string sceneName)
	{
		LoggerInstance.Msg($"Scene {sceneName} with build index {buildIndex} has been loaded!");
	}

}
