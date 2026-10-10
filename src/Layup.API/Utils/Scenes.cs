namespace Layup.API.Utils;

using UnityEngine;
public static class Scenes
{
	private const string HomePath = "Canvas/Safe Area/Home";

	public static GameObject MainMenu { get => GameObject.Find($"{HomePath}/Main Menu") ?? throw new Exception("Unable to locate Main Menu game object"); }

}
