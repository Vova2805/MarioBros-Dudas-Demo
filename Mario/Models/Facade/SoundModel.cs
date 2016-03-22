using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_KPZ.Models
{
	class SoundModel
	{
		private SoundModel() { }
		private static IEnumerable<string> sounds = null;
        public static IEnumerable<string> GetEnumerable()
		{
	        if (sounds == null)
	        {
		        sounds = new List<string>()
		        {
			        "01-main-theme-overworld.wav",
					"Jamie Berry - Mario Bros.wav",
			        "mb.wav",
					"101-overture.wav",
					"121-galaxy-plant.wav",
					"219-athletic-cosmos.wav",
					"background1.wav"
				};
	        }
	        return sounds;
		}
		
	}
}
