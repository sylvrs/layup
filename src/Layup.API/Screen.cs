namespace Layup.API;

using FluentResults;
using UnityEngine;

public class Screen(GameObject screenObject)
{
	public GameObject Object { get => screenObject; }
	private const string SafeAreaPath = "Canvas/Safe Area";

	public Result KeepChildren(params List<string> childNames)
	{

		return Result.Ok();
	}
	public static Result<Screen> CreateFrom(string categoryId, string templateId)
	{
		var screen = GameObject.Find($"{SafeAreaPath}/{categoryId}/{templateId}");
		if (screen == null)
			return Result.Fail($"Unable to locate template at {SafeAreaPath}/{categoryId}/{templateId}");

		return Result.Ok(new Screen(screen));
	}
}
