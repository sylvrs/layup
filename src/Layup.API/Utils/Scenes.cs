namespace Layup.API.Utils;

using UnityEngine;
public static class Scenes
{
	private const string SafeAreaPath = "Canvas/Safe Area";

	public static GameObject MainMenu { get => GameObject.Find($"{SafeAreaPath}/Home/Main Menu") ?? throw new Exception("Unable to locate Main Menu game object"); }

	public static GameObject SeasonSaves { get => GameObject.Find($"{SafeAreaPath}/Season/Setup/Season Saves") ?? throw new Exception("Unable to locate Season Saves game object"); }

}
