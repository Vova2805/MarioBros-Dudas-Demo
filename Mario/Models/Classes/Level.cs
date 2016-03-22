using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Lab5_KPZ.Base;
using Lab5_KPZ.Models.Classes;
using Lab5_KPZ.Models.Observer;
using System.Windows.Controls;
using Lab5_KPZ.UserControls;

namespace Lab5_KPZ.Models
{
	[Serializable]
	public enum Difficulty
	{
		[EnumMember]
		Easy,
		[EnumMember]
		Middle,
		[EnumMember]
		Hard
	}
	[Serializable]
	public class Level
	{
		public Difficulty difficulty { get; set; }
		public List<Map> _Maps { get; set;}
		public int Number { get; set; }
		public string Title { get; set; }
		public int Time { get; set; }
		public Mario _Mario { get; set; }
		public Luigi _Luigi { get; set; }
		public int currentMap { get; set; }

		public Level(Difficulty difficulty, List<Map> _map,int time, string title,int number)
		{
			this.difficulty = difficulty;
			_Maps = _map;
			Time = time;
			_Mario = Mario.GetMario();
			_Luigi = Luigi.GetLuigi();
			Title = title;
			Number = number;
			currentMap = 0;
        }
		public static Level Load(string FileName)
		{
			if (File.Exists(FileName))
			{
				return Serializer.Deserialize(FileName) as Level;
			}
			return null;
		}
		public void Save(string File)
		{
			Serializer.Serialize(File, this);
		}
		public void Load(Canvas gameCanvas, Image background,StackPanel panel)
		{
			gameCanvas.Children.Clear();
			background.Source = null;
			observers = new List<AObserver>();
			if (_Mario.observers == null)
				_Mario.observers = new List<AObserver>();
			if (_Luigi.observers == null)
				_Luigi.observers = new List<AObserver>();
			if (_Maps.Count() > 0)
			{
				_Maps.ElementAt(0).FillMap(gameCanvas, background, panel,_Mario, _Luigi,difficulty);
			}
			if (HeaderControl.timeObserver != null)
			{
				GeneralObject._gameModel.CurrentLevel.Attach(HeaderControl.timeObserver);
				GeneralObject._gameModel.CurrentLevel.Notify();
			}
			if (MarioControl.marioObserver != null)
			{
				GeneralObject._gameModel.CurrentLevel._Mario.Attach(MarioControl.marioObserver);
				GeneralObject._gameModel.CurrentLevel._Mario.Notify();
			}
			if (LuigiControl.luigiObserver != null && GeneralObject._gameViewModel._quantity.Equals("Two"))
			{
				GeneralObject._gameModel.CurrentLevel._Luigi.Attach(LuigiControl.luigiObserver);
				GeneralObject._gameModel.CurrentLevel._Luigi.Notify();
			}
		}
		//Observer pattern
		public void Attach(AObserver observer)
		{
			observers.Add(observer);
		}

		public void Detach(AObserver observer)
		{
			observers.Remove(observer);
		}

		public void Notify()
		{
			foreach (var observer in observers)
			{
				observer.Update(this);
			}
		}
		[NonSerialized]
		public List<AObserver> observers;
	}
}
