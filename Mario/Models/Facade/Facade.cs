using System;
using System.Linq;
using Lab5_KPZ.Models.Abstract_Factory;
using Lab5_KPZ.Models.Facad;
using System.Windows.Media;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace Lab5_KPZ.Models.Facade
{
	public enum PlayingType
	{
		original,
		loop
	}
	public enum playingCommand
	{
		play,
		stop
	}
	public class FacadeClass
	{
		private static FacadeClass _facadeInstance;
		public static FacadeClass GetFacade()
		{
			if(_facadeInstance == null)
			{
				_facadeInstance = new FacadeClass();
			}
			return _facadeInstance;
		}

		public static string baseSoundURI = @"../../Views/Source/Sounds/";
		public static int soundIndex = 0;

		
		private System.Drawing.Image Background;

		private StyleManager _styleManager = new StyleManager();
		private PlayerManager _playerManager = new PlayerManager();
		private SoundManager _soundManager = new SoundManager();
		

		private FacadeClass()
		{
			_soundManager.ChangeVolume(GeneralObject._backgroundPlayer, 0.5);
			SetStyle(new OrdinaryStyleFactory());
		}
		public void SetStyle(IStyleFactory style)
		{
			_styleManager.Clear();
			_styleManager.ChangeBackground(style.GetBackground());
			_styleManager.ChangeButtonStyle(style.GetButtonStyle());
			_styleManager.ChangeTextBoxStyle(style.GetTextBoxStyle());

			PlayStopSound(GeneralObject._backgroundPlayer,playingCommand.play,style.GetMusic(),PlayingType.loop);
		}
		public void SetColor(System.Windows.Media.Color color,Border border)
		{
			border.BorderBrush = new SolidColorBrush(color);
		}
		public void ChangeVolume(MediaPlayer player, double value)
		{
			if (!player.IsMuted)
				_soundManager.ChangeVolume(player, value);
			else
			{
				player.Play();
				_soundManager.ChangeVolume(player,value);
			}
		}
		public void PlayStopSound(MediaPlayer player,playingCommand command = playingCommand.play, string source = "", PlayingType type = PlayingType.original)
		{
			if (command == playingCommand.play)
			{
				_soundManager.PlaySound(player, source);
				if (type.Equals(PlayingType.loop))
				{
					player.MediaEnded += (object sender, EventArgs e) => { player.Play(); };
				}
			}
			else _soundManager.StopPlaying(player);
			
		}
		public void RegisterNewPlayer(string login, string password, string password2)
		{
			if (GeneralObject._DataViewModel.Players.Where(p => p.Name.Equals(login)).FirstOrDefault() != null)
			{
				MessageBox.Show("There is already player with the same login");
			}
			else
			{
				_playerManager.RegisterNewPlayer(login,password,password2);
			}
		}
		public void DeletePlayer(string login)
		{
			if(!login.Equals(""))
			{
				_playerManager.RemovePlayer(login);
			}
		}
		public RegisteredPlayer CheckRegisteredPlayer(string login, string password)
		{
			return GeneralObject._DataViewModel.Players.Where(p => p.Name.Equals(login) && p.password.Equals(password)).FirstOrDefault();
        }
	}
}
