using AutoMapper;
using Lab5_KPZ.Models;
using Lab5_KPZ.Models.Classes;
using Lab5_KPZ.Models.Facad;
using Lab5_KPZ.ViewModels;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab5_KPZ.Base
{
	class Mapping
	{
		public void Create()
		{
			Mapper.CreateMap<DataModel, DataViewModel>();
			Mapper.CreateMap<DataViewModel, DataModel>();

			Mapper.CreateMap<RegisteredPlayer, RegisteredPlayerViewModel>();
			Mapper.CreateMap<RegisteredPlayerViewModel, RegisteredPlayer>();

			Mapper.CreateMap<Player, PlayerViewModel>();
			Mapper.CreateMap<PlayerViewModel, Player>();

			Mapper.CreateMap<Mario, MarioViewModel>();
			Mapper.CreateMap<MarioViewModel, Mario>();

			Mapper.CreateMap<Luigi, LuigiViewModel>();
			Mapper.CreateMap<LuigiViewModel, Luigi>();

			Mapper.CreateMap<EditorModel, EditorViewModel>();
			Mapper.CreateMap<EditorViewModel, EditorModel>();

			Mapper.CreateMap<Map, MapViewModel>();
			Mapper.CreateMap<MapViewModel, Map>();

			Mapper.CreateMap<Level, LevelViewModel>();
			Mapper.CreateMap<LevelViewModel, Level>();

			Mapper.CreateMap<GameModel, GameViewModel>();
			Mapper.CreateMap<GameViewModel, GameModel>();

			Mapper.CreateMap<UserSettings, UserSettingsViewModel>();
			Mapper.CreateMap<UserSettingsViewModel, UserSettings>();
		}
		public static object Clone(object unit)
		{
			MemoryStream buffer = new MemoryStream();
			BinaryFormatter formatter = new BinaryFormatter();

			formatter.Serialize(buffer, unit);   
			buffer.Position = 0;
			return formatter.Deserialize(buffer);  
		}
	}
}
