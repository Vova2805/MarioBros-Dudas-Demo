using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab5_KPZ.ViewModels
{
	class UserSettingsViewModel:ViewModelBase
	{
		public Key menuDisplay;
		public Key moveForward;
		public Key moveBackward;
		public Key jump;
		public Key duck;
		public Key fire;
		public Key sprint;
		public Key _menuDisplay
		{
			get { return menuDisplay; }
			set
			{
				menuDisplay = value;
				OnPropertyChanged("_menuDisplay");
			}
		}
		public Key _moveForward
		{
			get { return moveForward; }
			set
			{
				moveForward = value;
				OnPropertyChanged("_moveForward");
			}
		}
		public Key _moveBackward
		{
			get { return moveBackward; }
			set
			{
				moveBackward = value;
				OnPropertyChanged("_moveBackward");
			}
		}
		public Key _jump
		{
			get { return jump; }
			set
			{
				jump = value;
				OnPropertyChanged("_jump");
			}
		}
		public Key _duck
		{
			get { return duck; }
			set
			{
				duck = value;
				OnPropertyChanged("_duck");
			}
		}
		public Key _fire
		{
			get { return fire; }
			set
			{
				fire = value;
				OnPropertyChanged("_fire");
			}
		}
		public Key _sprint
		{
			get { return sprint; }
			set
			{
				sprint = value;
				OnPropertyChanged("_sprint");
			}
		}
	}
}
