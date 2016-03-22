using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab5_KPZ.Models.Facad
{
	class PlayerManager
	{
		public void RegisterNewPlayer(string login, string password, string password2)
		{
				if (Validation(password, password2))
				{
					GeneralObject._DataViewModel.Players.Add(new RegisteredPlayer(login, password));
					MessageBox.Show("Congratulation! You are registered successfully!");
				}
				else MessageBox.Show("Passwords aren't matched. Check them and try again!");
		}
		
		public void RemovePlayer(string login)
		{
			var player = GeneralObject._DataViewModel.Players.Where(p => p.Name.Equals(login)).FirstOrDefault();
			if (player != null)
				GeneralObject._DataViewModel.Players.Remove(player);
			else MessageBox.Show("There is no registered player with such name!");
		}

		private bool Validation(string password, string password2)
		{
			return password.Equals(password2) ? true : false;
		}
	}
}
