using System;
using System.Windows.Media;

namespace Lab5_KPZ.Models.Facad
{
	class SoundManager
	{
		public void ChangeVolume(MediaPlayer player, double value)
		{
			player.Volume = value;
		}

		public void PlaySound(MediaPlayer player, string source)
		{
			if(source!=null)
			{
				player.Open(new Uri(source, UriKind.Relative));
				player.Play();
			}
		}
		public void StopPlaying(MediaPlayer player)
		{
				player.Pause();
		}
	}
}
