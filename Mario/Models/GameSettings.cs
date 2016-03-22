using Lab5_KPZ.Models.Abstract_Factory;
using System.Windows.Input;

namespace Lab5_KPZ.Models
{
	public class GameSettings
	{
		public UserSettings FirstUser;
		public UserSettings SecondUser;
		public System.Drawing.Color BorderColor;
		public int Style;
		public int ScreenSize;
		public int Sound;
		private static GameSettings _instance;
		private static readonly object locker = new object();

		public static GameSettings GetGameSettings()
		{
			lock (locker)
			{
				if (_instance == null)
				{
					_instance = new GameSettings();
                }
			}
			return _instance;
		}
		private GameSettings()
		{
			FirstUser = new UserSettings(Key.Escape, Key.D, Key.A, Key.W, Key.S, Key.Z, Key.LeftShift, Key.LeftCtrl);
			SecondUser = new UserSettings(Key.Home, Key.Right, Key.Left, Key.Up, Key.Down, Key.Space, Key.RightShift, Key.RightCtrl);
			BorderColor = System.Drawing.Color.LightSkyBlue;
			Style = 0;
			ScreenSize = 2;
            Sound = 0; 
        }

	}
}
