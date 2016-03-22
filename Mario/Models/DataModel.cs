using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Lab5_KPZ.Base;

namespace Lab5_KPZ.Models
{
	[DataContract]
	[Serializable]
	public class DataModel
	{
		public DataModel()
		{
			
		}
		[DataMember]
		public IEnumerable<RegisteredPlayer> Players { get; set; } 

		public static string DataPath = "Players.dat";
		public static DataModel Load()
		{
			if (File.Exists(DataPath))
			{
				return Serializer.Deserialize(DataPath) as DataModel;
			}
			else
			{
				PlayerGeneration.PlayerGenerater();
				return Serializer.Deserialize(DataPath) as DataModel;
			}
			return new DataModel();
		}
		public void Save()
		{
			Serializer.Serialize(DataPath, this);
		}
	}
}
