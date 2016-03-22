using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Lab5_KPZ.Models;
using Lab5_KPZ.Models.Abstract_Factory;
using Lab5_KPZ.Models.Facade;
using Xceed.Wpf.Toolkit;

namespace Lab5_KPZ.UserControls
{
	/// <summary>
	/// Interaction logic for SettingsForTwo.xaml
	/// </summary>
	public partial class SettingsForTwo : UserControl
	{
		public bool second = false;
		public static UserSettings settings;
		public static ControlSettings controlSettings;
		public static bool SecondClicked = false;
		public SettingsForTwo()
		{
			InitializeComponent();
			FirstClick(null, null);
			SecondClicked = false;
            Style.SelectedIndex = GeneralObject.style;
			PlayList.ItemsSource = SoundModel.GetEnumerable();
			DataContext = GeneralObject._gameViewModel;
			Slider.Value = GeneralObject._backgroundPlayer.Volume*100;
			PlayList.SelectedIndex = SoundModel.GetEnumerable()
				.ToList()
				.IndexOf(SoundModel.GetEnumerable().Where(s => GeneralObject._backgroundPlayer.Source.ToString().Contains(s)).First());
			ClrPcker_Background.SelectedColorChanged += (sender,e) => { ClrPcker_Background_SelectedColorChanged(null, null); };
        }
		private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (second && GeneralObject.style != Style.SelectedIndex)
			{
				GeneralObject.style = Style.SelectedIndex;
                switch (GeneralObject.style)
				{
					case 0:
						{
							GeneralObject.MainFacade.SetStyle(new OrdinaryStyleFactory());
						}
						break;
					case 1:
						{
							GeneralObject.MainFacade.SetStyle(new NightStyleFactory());
						}
						break;
				}}
			else second = true;
		}

		private void RangeBase_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			GeneralObject.MainFacade.ChangeVolume(GeneralObject._backgroundPlayer, Slider.Value / 100);
		}

		bool isFirstTime = true;
		private void PlayList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (!isFirstTime && FacadeClass.soundIndex!=PlayList.SelectedIndex)
			{
				string url = string.Concat(new List<string>() { FacadeClass.baseSoundURI, (SoundModel.GetEnumerable()).ElementAt(PlayList.SelectedIndex) });
				GeneralObject.MainFacade.PlayStopSound(GeneralObject._backgroundPlayer, playingCommand.play, url);
				FacadeClass.soundIndex = PlayList.SelectedIndex;
            }
			isFirstTime = false;
		}

		private void FirstClick(object sender, MouseButtonEventArgs e)
		{
			var label = sender as Label;
			if (label == null)
			{
				if (Set2.Visibility.Equals(Visibility.Visible))
				{
					controlSettings = LocalSettings2;
					SecondClicked = true;
					Assignment();
				}
				controlSettings = LocalSettings1;
				SecondClicked = false;
				Assignment();
			}
			else
			if (label.Content.Equals("Player 1"))
			{
				controlSettings = LocalSettings1;
				SecondClicked = false;
				Assignment();
			}
			else
			{
				controlSettings = LocalSettings2;
				SecondClicked = true;
				Assignment();
			}
        }
		public static void Assignment()
		{
			if (SecondClicked)
			{
				settings = GeneralObject._gameViewModel.SecondSettings;
			}
			else
			{
				settings = GeneralObject._gameViewModel.FirstSettings;
			}
			controlSettings.Menu_Display.Text = settings.commands["Menu_Display"].ToString();
			controlSettings.Move_Forward.Text = settings.commands["Move_Forward"].ToString();
			controlSettings.Move_Backward.Text = settings.commands["Move_Backward"].ToString();
			controlSettings.Jump.Text = settings.commands["Jump"].ToString();
			controlSettings.Duck.Text = settings.commands["Duck"].ToString();
			controlSettings.Fire.Text = settings.commands["Fire"].ToString();
			controlSettings.Sprint.Text = settings.commands["Sprint"].ToString();
			controlSettings.Save_Game.Text = settings.commands["Save_Game"].ToString();
		}

		private void ClrPcker_Background_SelectedColorChanged(object sender, RoutedEventArgs e)
		{
			foreach (var border in HeaderControl.borders)
			{
				GeneralObject.MainFacade.SetColor(
					Color.FromRgb(ClrPcker_Background.SelectedColor.Value.R, ClrPcker_Background.SelectedColor.Value.G, ClrPcker_Background.SelectedColor.Value.B),
					border);
			}
		}
	}
}
