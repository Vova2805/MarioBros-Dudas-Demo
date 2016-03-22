using Lab5_KPZ.Models.Facade;
using Lab5_KPZ.Models.Mediator1;
using Lab5_KPZ.ViewModels;
using Lab5_KPZ.Views.XAMLs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab5_KPZ.Models
{
	class GeneralObject
	{
		public static PointF MarioStartPosition;
		public static PointF LuigiStartPosition;

		public static Window MainWindow;
		public static MapEditor Editor;

		public static Frame GameFrame;
		public static Frame MainFrame;

		public static bool OutGame = true;
		public static bool IsStartup = false;
		public static bool GameMenuVisible = false;
		public static int style = 0;
		public static MediaPlayer _backgroundPlayer = new MediaPlayer();

		public static FacadeClass MainFacade;

		public static GameModel _gameModel;
		public static GameViewModel _gameViewModel;

		public static DataModel _DataModel;
		public static DataViewModel _DataViewModel;

		public static Mediator Mediator;
		public static PointF cellSize;
		public static GameSettings OriginalSettings;
		public static bool OnMap = false;
		public static string Path;
	}
}
