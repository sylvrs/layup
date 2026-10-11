namespace Layup.API;

using FluentResults;
using UnityEngine;

public static class Navigation
{
	public static Result Open(Screen? screen)
	{
		if (screen?.Object == null)
			return Result.Fail("Cannot navigate to a missing or destroyed screen.");

		var menuUI = Object.FindObjectOfType<Il2Cpp.MenuUI>();
		if (menuUI == null)
			return Result.Fail("Cannot navigate without an active Hoop Land MenuUI.");

		menuUI.ChangeMenu(screen.Object);
		return Result.Ok();
	}
}
