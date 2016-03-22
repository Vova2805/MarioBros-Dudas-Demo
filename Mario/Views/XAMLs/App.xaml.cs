using System;
using System.Windows;
using System.Windows.Controls;
using AutoMapper;
using Lab5_KPZ.Base;
using Lab5_KPZ.Models;
using Lab5_KPZ.Models.Abstract_Factory;
using Lab5_KPZ.ViewModels;
using Lab5_KPZ.Views.XAMLs;
using Lab5_KPZ.Models.Facade;
using System.Windows.Media;
using System.Linq;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using System.Windows.Threading;
using Lab5_KPZ.Models.Mediator1;
using System.Collections.Generic;

namespace Lab5_KPZ
{
	/// <summary>
	/// Interaction logic for GeneralObject.xaml
	/// </summary>
	public partial class App : Application
	{
		

		public App()
		{
			try
			{
				GeneralObject.OriginalSettings = GameSettings.GetGameSettings();

				GeneralObject.cellSize = new PointF(50,50);
				GeneralObject.Mediator = new Mediator();
				new Mapping().Create();
				GeneralObject._DataModel = DataModel.Load();

				GeneralObject._DataModel.Players = GeneralObject._DataModel.Players.OrderBy(p => -p.Score).ToList();
				GeneralObject._DataViewModel = Mapper.Map<DataModel, DataViewModel>(GeneralObject._DataModel);
				GeneralObject._gameModel = new GameModel();
				GeneralObject._gameViewModel = Mapper.Map<GameModel, GameViewModel>(GeneralObject._gameModel);
				GeneralObject.MainWindow = new WindowBackground();
				GeneralObject.MainWindow = MainWindow;
				GeneralObject.MainWindow.MaxHeight = GeneralObject._gameModel.screenSizes["HD 1366 * 768"].height;
				GeneralObject.MainWindow.MaxWidth = GeneralObject._gameModel.screenSizes["HD 1366 * 768"].width;
				// set static  size above
				GeneralObject.MainFacade = FacadeClass.GetFacade();
				GeneralObject.MainWindow.Show();
				//var temp = new NewGame();
				GeneralObject.Path = string.Format("Level{0}.dat",1);
            }
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		protected override void OnExit(ExitEventArgs e)
		{
			try
			{
				GeneralObject._DataModel = Mapper.Map<DataViewModel, DataModel>(GeneralObject._DataViewModel);
				GeneralObject._DataModel.Save();
			}
			catch (Exception e1)
			{
				MessageBox.Show("Error during closing application!");
			}
			base.OnExit(e);
		}

		
	}
}
