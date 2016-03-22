using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5_KPZ.Models;

namespace Lab5_KPZ.Base
{
	class PlayerGeneration
	{
		public static void PlayerGenerater()
		{
			var model = new DataModel();
			model.Players = new List<RegisteredPlayer>()
			{};
			Serializer.Serialize(@"Players.dat", model);
		}
	}
}
