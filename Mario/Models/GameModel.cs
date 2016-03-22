
using Lab5_KPZ.Base;
using Lab5_KPZ.Models.Memento;
using Lab5_KPZ.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab5_KPZ.Models
{
	[DataContract]
	public class GameModel
	{
		[DataMember]
		public string _quantity { get; set; }
		[DataMember]
		public string _first { get; set; }
		[DataMember]
		public string _second { get; set; }
		[DataMember]
		public string FirstPlayerSubmited { get; set; }
		[DataMember]
		public string SecondPlayerSubmited { get; set; }
		[DataMember]
		public string uploadGame { get; set; }
		[DataMember]
		public string uploadedSuccessfull { get; set; }
		[DataMember]
		public string isWon { get; set; }
		public GameModel()
		{
			_quantity = "One";
			_first = "S";
			_second = "S";
			FirstPlayerSubmited = "false";
			SecondPlayerSubmited = "false";
			FirstSettings = new UserSettings();
			SecondSettings = new UserSettings();
			FirstSettings = (UserSettings)Mapping.Clone(GeneralObject.OriginalSettings.FirstUser);
			SecondSettings = (UserSettings)Mapping.Clone(GeneralObject.OriginalSettings.SecondUser);
			SaveRestore = "Save";
			CurrentLevel = null;
			uploadGame = "Yes";
			uploadedSuccessfull = "false";
			screenSizes = new Dictionary<string, Size>();
			screenSizes.Add("WVGA 800 * 480", new Size(480, 800));
			screenSizes.Add("WSVGA 1024 * 600", new Size(600, 1024));
			screenSizes.Add("HD 1366 * 768",new Size(755,1366));
			screenSizes.Add("HD 1600 * 900", new Size(900, 1600));
			screenSizes.Add("HD1080 1920 * 1080", new Size(1080, 1920));
			screenSizes.Add("2K 2048 * 1080", new Size(1080, 2048));
			screenSizes.Add("WQHD 2560 * 1440", new Size(1440, 2560));
			screenSizes.Add("WQXGA 2560 * 1600", new Size(1600, 2560));
			screenSizes.Add("UHD-1 3840 * 2160", new Size(2160, 3840));
			isWon = "No";
        }
		[DataMember]
		public Player FirstPlayer { get; set; }
		[DataMember]
		public Player SecondPlayer { get; set; }
		[DataMember]
		public string SaveRestore { get; set; }
		[DataMember]
		public Level CurrentLevel { get; set; }
		[DataMember]
		public UserSettings FirstSettings { get; set; }
		[DataMember]
		public UserSettings SecondSettings { get; set; }
		[DataMember]
		public Dictionary<string, Size> screenSizes { get; set; }
		[DataMember]
		public Difficulty difficultyModel { get; set; }
		public GameMemento GameSave()
		{
			return new GameMemento(CurrentLevel);
		}
		public void LoadGame(GameMemento memento)
		{
			CurrentLevel = memento.GetState();
			CurrentLevel.Load(NewGame.gameCanvas, NewGame.background,NewGame.MainStackPanel);
		}
		public static void SaveResults()
		{
			if (GeneralObject._gameModel.FirstPlayer is RegisteredPlayer)
			{
				var player = GeneralObject._DataViewModel.Players.Where(p => p.Name.Equals(GeneralObject._gameModel.FirstPlayer.Name) && p.password.Equals((GeneralObject._gameModel.FirstPlayer as RegisteredPlayer).password))
			 .FirstOrDefault();
				if (player != null)
				{
					player.Coins += GeneralObject._gameModel.CurrentLevel._Mario.CoinsQuantity;
					player.Score += GeneralObject._gameModel.CurrentLevel._Mario.Score;
					player.Level = GeneralObject._gameModel.FirstPlayer.Level;
					(player as RegisteredPlayer).PreviousGames =(Dictionary<string,GameMemento>) Mapping.Clone((GeneralObject._gameModel.FirstPlayer as RegisteredPlayer).PreviousGames);
				}
			}
			if (GeneralObject._gameModel._quantity.Equals("Two"))
			{
				if (GeneralObject._gameModel.SecondPlayer is RegisteredPlayer)
				{
					var player = GeneralObject._DataViewModel.Players.Where(p => p.Name.Equals(GeneralObject._gameModel.SecondPlayer.Name) && p.password.Equals((GeneralObject._gameModel.SecondPlayer as RegisteredPlayer).password))
			 .FirstOrDefault();
					if (player != null)
					{
						player.Coins += GeneralObject._gameModel.CurrentLevel._Luigi.CoinsQuantity;
						player.Score += GeneralObject._gameModel.CurrentLevel._Luigi.Score;
						player.Level = GeneralObject._gameModel.SecondPlayer.Level;
						(player as RegisteredPlayer).PreviousGames = (Dictionary<string, GameMemento>)Mapping.Clone((GeneralObject._gameModel.SecondPlayer as RegisteredPlayer).PreviousGames);
					}
				}
			}
		}
	}
}
