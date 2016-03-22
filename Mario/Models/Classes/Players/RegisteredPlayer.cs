using Lab5_KPZ.Base;
using Lab5_KPZ.Models.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Lab5_KPZ.Models
{//Caretaker
	[Serializable]
	[DataContract]
	public enum Awards
	{
		[EnumMember]
		Registered,
		[EnumMember]
		Level1,
		[EnumMember]
		Level2,
		[EnumMember]
		Level3,
		[EnumMember]
		Level4,
		[EnumMember]
		Level5,
		[EnumMember]
		Level10,
		[EnumMember]
		Level20
	}
	[DataContract]
	[Serializable]
	public class RegisteredPlayer:Player
	{
		[DataMember]
		public string password { get; set;}
		[DataMember] public Dictionary<string,GameMemento> PreviousGames { get; set; }
		public RegisteredPlayer(string name, string password) : base(name)
		{
			this.password = password;
			PreviousGames = new Dictionary<string, GameMemento>();
			PreviousGames.OrderByDescending(g=>g.Key);
		}
		public void InsertGame()
		{
			PreviousGames.Add(DateTime.Now.ToString(), GeneralObject._gameModel.GameSave());
			if (PreviousGames.Count > 10)
				PreviousGames.Remove(PreviousGames.First().Key);
		}
		public void LoadGame(string time)
		{
			GeneralObject._gameModel.LoadGame(PreviousGames[time]);
		}
	}
}
