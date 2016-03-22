using Lab5_KPZ.Models;
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
	/// Interaction logic for TwoPlayerUserControl.xaml
	/// </summary>
	public partial class TwoPlayerUserControl : UserControl
	{
		public static bool OneIsCompleted = false;
		public TwoPlayerUserControl()
		{
			InitializeComponent();
			DataContext = GeneralObject._gameViewModel;
			GeneralObject._gameViewModel.SecondPlayerSubmited = "false";
			GeneralObject._gameViewModel.FirstPlayerSubmited = "false";
		}
	}
}
