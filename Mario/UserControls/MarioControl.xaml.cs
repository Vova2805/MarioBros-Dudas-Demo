using Lab5_KPZ.Models;
using Lab5_KPZ.Models.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab5_KPZ.UserControls
{
	/// <summary>
	/// Interaction logic for MarioControl.xaml
	/// </summary>
	public partial class MarioControl : UserControl
	{
		public static MarioObserver marioObserver;
		public MarioControl()
		{
			InitializeComponent();
			DataContext = GeneralObject._gameViewModel;
			marioObserver = new MarioObserver(MarioLife,MarioPoints,MarioCoins);
			DataContext = GeneralObject._gameViewModel;
		}
	}
}
