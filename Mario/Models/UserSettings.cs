using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Lab5_KPZ.Models
{
	[Serializable]
	public class UserSettings
	{
		public Dictionary<string, Key> commands;
		public UserSettings()
		{
			commands = new Dictionary<string, Key>();
		}
		public UserSettings(
		Key _menuDisplay,
		Key _moveForward,
		Key _moveBackward,
		Key _jump,
		Key _duck,
		Key _fire,
		Key _sprint,
		Key _save_game)
		{
		commands = new Dictionary<string, Key>();
		commands.Add("Menu_Display", _menuDisplay);
		commands.Add("Move_Forward", _moveForward);
		commands.Add("Move_Backward", _moveBackward);
		commands.Add("Jump", _jump);
		commands.Add("Duck", _duck);
		commands.Add("Fire", _fire);
		commands.Add("Sprint", _sprint);
		commands.Add("Save_Game", _save_game);
		}
	}
}
