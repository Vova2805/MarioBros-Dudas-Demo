using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AutoMapper;
using Lab5_KPZ.Base;
using Lab5_KPZ.Models;
using Lab5_KPZ.Models.Abstract_classes;
using Lab5_KPZ.Models.Classes;
using Lab5_KPZ.Models.Classes.Blocks;
using Lab5_KPZ.Models.Classes.Bonus;
using Lab5_KPZ.Models.Facad;
using Lab5_KPZ.ViewModels;
using Block = Lab5_KPZ.Models.Abstract_classes.Block;
using Brushes = System.Windows.Media.Brushes;
using DragDropEffects = System.Windows.DragDropEffects;
using DragEventArgs = System.Windows.DragEventArgs;
using Image = System.Windows.Controls.Image;
using MessageBox = System.Windows.MessageBox;
using Rectangle = System.Windows.Shapes.Rectangle;
using Lab5_KPZ.Models.Facade;
using Microsoft.Win32;
using Lab5_KPZ.Models.Flyweight;

namespace Lab5_KPZ.Views.XAMLs
{
	/// <summary>
	/// Interaction logic for MapEditor.xaml
	/// </summary>
	public partial class MapEditor : Window
	{
		bool firstTime = true;
		int CurrentImage = 0;
		public bool isPlaying = false;
		MediaPlayer pl = new MediaPlayer();
		public PointF cellSize = new PointF(50,50);
		List<Rectangle> rectangles = new List<Rectangle>();
		public static Level LevelModel ;
		public static EditorViewModel EditorViewModel;

		public MapEditor()
		{
			InitializeComponent();
			new Mapping().Create();
			EditorViewModel = Mapper.Map<EditorModel, EditorViewModel>(new EditorModel());
			DataContext = EditorViewModel;
            pl.Volume = 0.5;
			Canvas.Width = StackPanel.Width;
			Canvas.Height = StackPanel.Height;
			PlayList.ItemsSource = SoundModel.GetEnumerable();
			LevelModel = new Level(Models.Difficulty.Easy, new List<Map>(),200, "Test level", 1);
			LevelModel._Maps.Add(new Map(StackPanel.Height,StackPanel.Width,EditorBackground.Source.ToString()));
			PlayList.SelectedIndex = 0;
			GeneralObject.OnMap = true;
		}

		private void Play_OnClick(object sender, RoutedEventArgs e)
		{
			//Upload and play music
			if (isPlaying)
			{
				PlayImage.Source = new BitmapImage(new Uri(@"../../Views/Source/Images/play.png", UriKind.Relative));
				isPlaying = false;
				GeneralObject.MainFacade.PlayStopSound(pl, playingCommand.stop);
			}
			else
			{
				PlayImage.Source = new BitmapImage(new Uri(@"../../Views/Source/Images/stop.png", UriKind.Relative));
				isPlaying = true;
				string url = string.Concat(new List<string>() { FacadeClass.baseSoundURI, (SoundModel.GetEnumerable()).ElementAt(PlayList.SelectedIndex)});
				GeneralObject.MainFacade.PlayStopSound(pl, playingCommand.play,url);
			}
		}

		private void Image_click(object sender, MouseButtonEventArgs e)
		{
			var grid = sender as Grid;
			EditorBackground.Source = (grid.Children[0] as Image).Source;
			FillingMap();
		}

		void FillingMap()//Background
		{
			if (StackPanel.Children.Count > 1)
			{
				Image temp = EditorBackground;
				StackPanel.Children.Clear();
				StackPanel.Children.Add(temp);
			}
			int image_number = (int)Math.Ceiling(StackPanel.Width / EditorBackground.Width);
			for (int i = 1; i < image_number; i++)
			{
				var image = new Image();
				image.Source = EditorBackground.Source;
				image.VerticalAlignment = EditorBackground.VerticalAlignment;
				image.HorizontalAlignment = EditorBackground.HorizontalAlignment;
				image.Width = EditorBackground.Width;
				image.Stretch = EditorBackground.Stretch;
				StackPanel.Children.Add(image);
			}
			Canvas.Width = StackPanel.Width;
			if (!firstTime && showen)
			{
				showen = false;
				Rasts_click(new object(), null);
			}
			else
			firstTime = false;
		}

		private void SlValue_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			StackPanel.Width = slValue.Value;
			FillingMap();
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void PlayList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(isPlaying)
			Play_OnClick(sender,null);
			LevelModel._Maps.ElementAt(0).SoundSource=string.Concat(new List<string>() { FacadeClass.baseSoundURI, (SoundModel.GetEnumerable()).ElementAt(PlayList.SelectedIndex) });
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			pl.Stop();
			lines.Clear();
			GeneralObject.OnMap = false;
        }
		List<Line> lines = new List<Line>();
		bool showen = false;
		private void Rasts_click(object sender, RoutedEventArgs e)
		{
			if (!showen)
			{
				int rows = (int)Math.Ceiling(StackPanel.Height / cellSize.Y);
				int cols = (int)Math.Ceiling(StackPanel.Width / cellSize.X);
				for (int i = 0; i < rows-1; i++)
				{
					Line line = new Line();
					line.Stroke = Brushes.Red;
					line.StrokeThickness = 2;
					line.X1 = 0;
					line.X2 = StackPanel.Width;
					line.Y1 = cellSize.Y * (i + 1);
					line.Y2 = line.Y1;
					Canvas.Children.Add(line);
					lines.Add(line);
				}
				for (int i = 0; i < cols; i++)
				{
					Line line = new Line();
					line.Stroke = Brushes.Red;
					line.StrokeThickness = 2;
					line.X1 = cellSize.X * (i + 1);
					line.X2 = line.X1;
					line.Y1 = 0;
					line.Y2 = StackPanel.Height;
					Canvas.Children.Add(line);
					lines.Add(line);
				}
			}
			else
			{
				foreach (var line in lines)
				{
					Canvas.Children.Remove(line);
				}
				lines.Clear();
			}
			showen = !showen;
		}
		private void ScrollViewer1_OnScrollChanged(object sender, ScrollChangedEventArgs e)
		{
			ScrollViewer0.ScrollToHorizontalOffset(ScrollViewer1.HorizontalOffset);
			ScrollViewer0.ScrollToVerticalOffset(ScrollViewer1.VerticalOffset);
		}

		private void Windows_drop(object sender, DragEventArgs e)
		{
			Image image = e.Data.GetData(typeof(Image)) as Image;
			if (image != null)
			{
				if (image.Parent.GetType().Equals(Canvas.GetType()))//if we drag image within canvas
				{
					Canvas.Children.Remove(image);
				}
				Image imageControl = new Image() { Width = image.Width, Height = image.Height, Source = image.Source,Name=image.Name };
				int x = (int)(Math.Floor(e.GetPosition(Canvas).X / cellSize.X) * cellSize.X);
				int y = (int)(Math.Floor(e.GetPosition(Canvas).Y / cellSize.Y) * cellSize.Y);
				Canvas.SetLeft(imageControl, x);
				Canvas.SetTop(imageControl, y);
				imageControl.Stretch = image.Stretch;
				//SWITCH
				#region 
				if (imageControl != null)//if it's imageControl
				{
					PointF pos = new PointF((float)Canvas.GetLeft(imageControl), (float)Canvas.GetTop(imageControl));
					switch (EditorViewModel.ControlType)
					{
						case "Heroes":
							{
								switch (image.Name)
								{
									case "MarioImage":
										{
											if (Canvas.Children.Contains(LevelModel._Mario.ImageController))
												Canvas.Children.Remove(LevelModel._Mario.ImageController);
											LevelModel._Mario =
														Mario.GetMario(imageControl);
											Canvas.SetLeft(LevelModel._Mario.ImageController, Canvas.GetLeft(imageControl));
											Canvas.SetTop(LevelModel._Mario.ImageController, Canvas.GetTop(imageControl));
											LevelModel._Mario.Position = UnitImagesFactory.GetPosition(Canvas.GetLeft(LevelModel._Mario.ImageController),
												Canvas.GetTop(LevelModel._Mario.ImageController));
                                            LevelModel._Mario.ImageController.Stretch = Stretch.Fill;
											LevelModel._Mario.ImageController.Height = imageControl.Height;
											LevelModel._Mario.ImageController.Width = imageControl.Width;
											if (Canvas.Children.Contains(LevelModel._Mario.ImageController))
												Canvas.Children.Remove(LevelModel._Mario.ImageController);
											Canvas.Children.Add(LevelModel._Mario.ImageController);
										}
										break;
									case "LuigiImage":
										{
											if (Canvas.Children.Contains(LevelModel._Luigi.ImageController))
												Canvas.Children.Remove(LevelModel._Luigi.ImageController);
											LevelModel._Luigi =
														Luigi.GetLuigi(imageControl);
											Canvas.SetLeft(LevelModel._Luigi.ImageController, Canvas.GetLeft(imageControl));
											Canvas.SetTop(LevelModel._Luigi.ImageController, Canvas.GetTop(imageControl));
											LevelModel._Luigi.Position = UnitImagesFactory.GetPosition(Canvas.GetLeft(LevelModel._Luigi.ImageController),
												Canvas.GetTop(LevelModel._Luigi.ImageController));
											LevelModel._Luigi.ImageController.Stretch = Stretch.Fill;
											LevelModel._Luigi.ImageController.Height = imageControl.Height;
											LevelModel._Luigi.ImageController.Width = imageControl.Width;
											if (Canvas.Children.Contains(LevelModel._Luigi.ImageController))
												Canvas.Children.Remove(LevelModel._Luigi.ImageController);
											Canvas.Children.Add(LevelModel._Luigi.ImageController);
										}
										break;
									default:
										{
											MessageBox.Show("Error during draging hero");
										}
										break;
								}
							}
							break;
						case "Enemies":
							{
								LevelModel._Maps.ElementAt(0).Enemies.Add(new GeneralEnemy(imageControl));
								Canvas.SetLeft(LevelModel._Maps.ElementAt(0).Enemies.Last().ImageController,
										LevelModel._Maps.ElementAt(0).Enemies.Last().Position.X);
								Canvas.SetTop(LevelModel._Maps.ElementAt(0).Enemies.Last().ImageController,
									LevelModel._Maps.ElementAt(0).Enemies.Last().Position.Y);
								LevelModel._Maps.ElementAt(0).Enemies.Last().ImageController.Stretch = Stretch.Fill;
								Canvas.Children.Add(LevelModel._Maps.ElementAt(0).Enemies.Last().ImageController);
							}
							break;
						case "Items":
						{
							var tab_panel = image.Parent as TabPanel;
                                if (tab_panel != null)
                                switch (tab_panel.Name)
								{
									case "Blocks":
										{
											switch (imageControl.Name)
											{
												case "Bonus":
													{
														LevelModel._Maps.ElementAt(0).Blocks.Add(new Bonus_block(imageControl, "Bonus", null));
													}
													break;
												case "Brick":
													{
														LevelModel._Maps.ElementAt(0).Blocks.Add(new GeneralWithImageRef(imageControl, "Brick"));
													}
													break;
												case "Flag":
													{
														LevelModel._Maps.ElementAt(0).Blocks.Add(new GeneralWithImageRef(imageControl, "Flag"));
													}
													break;
												case "Gate":
													{
														LevelModel._Maps.ElementAt(0).Blocks.Add(new GeneralWithImageRef(imageControl, "Gate"));
													}
													break;
												case "Platform":
													{
														LevelModel._Maps.ElementAt(0).Blocks.Add(new GeneralWithImageRef(imageControl, "Platform"));
													}
													break;
												default:
													{
														LevelModel._Maps.ElementAt(0).Blocks.Add(new GeneralWithImageRef(imageControl, "General"));
													}
													break;
											}
												Canvas.SetLeft(LevelModel._Maps.ElementAt(0).Blocks.Last().ImageController,
													LevelModel._Maps.ElementAt(0).Blocks.Last().Position.X);
												Canvas.SetTop(LevelModel._Maps.ElementAt(0).Blocks.Last().ImageController,
													LevelModel._Maps.ElementAt(0).Blocks.Last().Position.Y);
												LevelModel._Maps.ElementAt(0).Blocks.Last().ImageController.Stretch = Stretch.Fill;
												Canvas.Children.Add(LevelModel._Maps.ElementAt(0).Blocks.Last().ImageController);
												//add on canvas
											}
											break;
									case "Bonuses":
										{
												LevelModel._Maps.ElementAt(0).Bonuses.Add(new GeneralBonus(imageControl, imageControl.Name));
												Canvas.SetLeft(LevelModel._Maps.ElementAt(0).Bonuses.Last().ImageController,
													LevelModel._Maps.ElementAt(0).Bonuses.Last().Position.X);
												Canvas.SetTop(LevelModel._Maps.ElementAt(0).Bonuses.Last().ImageController,
													LevelModel._Maps.ElementAt(0).Bonuses.Last().Position.Y);
												LevelModel._Maps.ElementAt(0).Bonuses.Last().ImageController.Stretch = Stretch.Fill;
												Canvas.Children.Add(LevelModel._Maps.ElementAt(0).Bonuses.Last().ImageController);
												//add on canvas
											}
											break;
									case "Coins":
										{
												LevelModel._Maps.ElementAt(0).Coins.Add(new CoinOrdinary(imageControl, 50));
												Canvas.SetLeft(LevelModel._Maps.ElementAt(0).Coins.Last().ImageController,
													LevelModel._Maps.ElementAt(0).Coins.Last().Position.X);
												Canvas.SetTop(LevelModel._Maps.ElementAt(0).Coins.Last().ImageController,
													LevelModel._Maps.ElementAt(0).Coins.Last().Position.Y);
												LevelModel._Maps.ElementAt(0).Coins.Last().ImageController.Stretch = Stretch.Fill;
												Canvas.Children.Add(LevelModel._Maps.ElementAt(0).Coins.Last().ImageController);

												//add on canvas
											}
											break;
								}
							}
							break;
					}
				}
				#endregion

				var rect =
					rectangles.Where(r => Canvas.GetLeft(r).Equals(x) && Canvas.GetTop(r).Equals(y))
						.Select(rec => rec)
						.ToList()
						.FirstOrDefault();
				//if there is rectangle
				if (rect != null)
				{
					Canvas.Children.Remove(rect);
					rectangles.Remove(rect);
					//copy our object
					//PROTOTYPE
					try
					{
						while (rectangles.Count > 0)
						{
							var rectangle = rectangles.First();
							//exchange by object (copy)
							switch (EditorViewModel.ControlType)
							{
								case "Heroes":
								{
									throw new Exception("Error. You can't copy hero more than once");
								}
								case "Enemies":
								{
									//clone in last 
									LevelModel._Maps.ElementAt(0).Enemies.Add(LevelModel._Maps.ElementAt(0).Enemies.Last().Clone() as Enemy);
									//change position
									LevelModel._Maps.ElementAt(0).Enemies.Last().Position = new PointF((float) Canvas.GetLeft(rectangle),
										(float) Canvas.GetTop(rectangle));
									//add image of last element
									Canvas.SetLeft(LevelModel._Maps.ElementAt(0).Enemies.Last().ImageController,
										LevelModel._Maps.ElementAt(0).Enemies.Last().Position.X);
									Canvas.SetTop(LevelModel._Maps.ElementAt(0).Enemies.Last().ImageController,
										LevelModel._Maps.ElementAt(0).Enemies.Last().Position.Y);
										LevelModel._Maps.ElementAt(0).Enemies.Last().ImageController.Stretch = Stretch.Fill;
										Canvas.Children.Add(LevelModel._Maps.ElementAt(0).Enemies.Last().ImageController);
									//add on canvas
									}
									break;
								case "Items":
								{
									var parent = (image.Parent as TabPanel);
									if (parent != null)
										switch (parent.Name)
										{
											case "Blocks":
											{
												LevelModel._Maps.ElementAt(0).Blocks.Add(LevelModel._Maps.ElementAt(0).Blocks.Last().Clone() as Block);
												//change position
												LevelModel._Maps.ElementAt(0).Blocks.Last().Position = new PointF((float) Canvas.GetLeft(rectangle),
													(float) Canvas.GetTop(rectangle));
												//add image of last element
												Canvas.SetLeft(LevelModel._Maps.ElementAt(0).Blocks.Last().ImageController,
													LevelModel._Maps.ElementAt(0).Blocks.Last().Position.X);
												Canvas.SetTop(LevelModel._Maps.ElementAt(0).Blocks.Last().ImageController,
													LevelModel._Maps.ElementAt(0).Blocks.Last().Position.Y);
														LevelModel._Maps.ElementAt(0).Blocks.Last().ImageController.Stretch = Stretch.Fill;
														Canvas.Children.Add(LevelModel._Maps.ElementAt(0).Blocks.Last().ImageController);
												//add on canvas
											}
												break;
											case "Bonuses":
											{
												LevelModel._Maps.ElementAt(0).Bonuses.Add(LevelModel._Maps.ElementAt(0).Bonuses.Last().Clone() as Bonus);
												//change position
												LevelModel._Maps.ElementAt(0).Bonuses.Last().Position = new PointF((float) Canvas.GetLeft(rectangle),
													(float) Canvas.GetTop(rectangle));
												//add image of last element
												Canvas.SetLeft(LevelModel._Maps.ElementAt(0).Bonuses.Last().ImageController,
													LevelModel._Maps.ElementAt(0).Bonuses.Last().Position.X);
												Canvas.SetTop(LevelModel._Maps.ElementAt(0).Bonuses.Last().ImageController,
													LevelModel._Maps.ElementAt(0).Bonuses.Last().Position.Y);
														LevelModel._Maps.ElementAt(0).Bonuses.Last().ImageController.Stretch = Stretch.Fill;
														Canvas.Children.Add(LevelModel._Maps.ElementAt(0).Bonuses.Last().ImageController);
												//add on canvas
											}
												break;
											case "Coins":
											{
												LevelModel._Maps.ElementAt(0).Coins.Add(LevelModel._Maps.ElementAt(0).Coins.Last().Clone() as Coin);
												//change position
												LevelModel._Maps.ElementAt(0).Coins.Last().Position = new PointF((float) Canvas.GetLeft(rectangle),
													(float) Canvas.GetTop(rectangle));
												//add image of last element
												Canvas.SetLeft(LevelModel._Maps.ElementAt(0).Coins.Last().ImageController,
													LevelModel._Maps.ElementAt(0).Coins.Last().Position.X);
												Canvas.SetTop(LevelModel._Maps.ElementAt(0).Coins.Last().ImageController,
													LevelModel._Maps.ElementAt(0).Coins.Last().Position.Y);
														LevelModel._Maps.ElementAt(0).Coins.Last().ImageController.Stretch = Stretch.Fill;
														Canvas.Children.Add(LevelModel._Maps.ElementAt(0).Coins.Last().ImageController);
														
														//add on canvas
													}
												break;
											default:
											{
												MessageBox.Show("Error during draging items");
											}
												break;
										}
								}
									break;
							}
							//remove from pool
							Canvas.Children.Remove(rectangle);
							rectangles.Remove(rectangle);
						}
					}
					catch (Exception e1)
					{
						MessageBox.Show(e1.Message);
					}
					
				}
			}
		}

		private new void DragEnter(object sender, DragEventArgs e)
		{
			//Image image = e.Data.GetData(typeof(Image)) as Image;
			//TabPanel tabpanel = image.Parent as TabPanel;
			//if(image.Name.Equals("MarioImage") || image.Name.Equals("LuigiImage"))
			//	tabpanel.Children.Remove(image);
			//DragDrop.DoDragDrop(sender as Image, sender as Image, DragDropEffects.All);
		}

		private void ImageMouseDown(object sender, MouseButtonEventArgs e)
		{
				DragDrop.DoDragDrop(sender as Image, sender as Image, DragDropEffects.All);
		}

		private void CanvasMouseDown(object sender, MouseButtonEventArgs e)
		{
			if(true)
			{
				Rectangle rect = new Rectangle
				{
					Fill = Brushes.Red,
					Width = 50,
					Height = 50
				};
				double x = (Math.Floor(e.GetPosition(Canvas).X / cellSize.X) * cellSize.X);
				double y = (Math.Floor(e.GetPosition(Canvas).Y / cellSize.Y) * cellSize.Y);
				Canvas.SetLeft(rect, x);
				Canvas.SetTop(rect, y);
				var image = new Image();
				Canvas.SetLeft(image, x);
				Canvas.SetTop(image, y);
				//if there is no rectangle on canvas on this position
				if ((rectangles.Where(r => Canvas.GetLeft(r).Equals(x) && Canvas.GetTop(r).Equals(y)).Select(rec => rec).ToList())
						.FirstOrDefault() == null && !Check(x,y,LevelModel))
				{
					rectangles.Add(rect);
					Canvas.Children.Add(rect);
				}
			}
		}

		public static bool Check(double x,double y,Level LevelModel)
		{
			return (MapUnit.CheckIn(x,y,LevelModel)!= null);
		}
		private void CanvasDoubleClick(object sender, MouseButtonEventArgs e)
		{
			int x =  (int)(Math.Floor(e.GetPosition(Canvas).X / cellSize.X) * cellSize.X);
			int y = (int)(Math.Floor(e.GetPosition(Canvas).Y / cellSize.Y) * cellSize.Y);
			var rectangle = (rectangles.Where(r => Canvas.GetLeft(r).Equals(x) && Canvas.GetTop(r).Equals(y)).Select(rec => rec).ToList()).FirstOrDefault();
			if (rectangle != null)
			{
					Canvas.Children.Remove(rectangle);
					rectangles.Remove(rectangle);
			}
			//Using Iterator
			var temp = MapUnit.CheckIn(x, y, LevelModel);
			if(temp != null)
			{
				Canvas.Children.Remove(temp.ImageController);
				if (temp is Enemy) LevelModel._Maps.ElementAt(0).Enemies.Remove(temp);
				else if (temp is Block) LevelModel._Maps.ElementAt(0).Blocks.Remove(temp);
				else if (temp is Pipe) LevelModel._Maps.ElementAt(0).Pipes.Remove(temp);
				else if (temp is Coin) LevelModel._Maps.ElementAt(0).Coins.Remove(temp);
				else if (temp is Bonus) LevelModel._Maps.ElementAt(0).Bonuses.Remove(temp);
				else if (temp is Mario) LevelModel._Mario.Position = new PointF(-1,-1);
				else if (temp is Luigi) LevelModel._Luigi.Position = new PointF(-1, -1);
			}
		}

		private void ButtonBase1_OnClick(object sender, RoutedEventArgs e)
		{
			Canvas.Children.Clear();
			LevelModel._Maps.ElementAt(0).Blocks.Clear();
			LevelModel._Maps.ElementAt(0).Coins.Clear();
			LevelModel._Maps.ElementAt(0).Enemies.Clear();
			LevelModel._Maps.ElementAt(0).Pipes.Clear();
			LevelModel._Maps.ElementAt(0).Bonuses.Clear();
			rectangles.Clear();
		}

		private void SaveClick(object sender, RoutedEventArgs e)
		{
			SaveFileDialog saveDl = new SaveFileDialog();
			saveDl.DefaultExt = ".dat";
			saveDl.Filter = "DAT documents (.dat)|*.dat";
			Nullable<bool> result = saveDl.ShowDialog();
			if (result == true)
			{
				try
				{
					LevelModel._Maps.ElementAt(0).BackgrounImageSource = EditorBackground.Source.ToString();
					LevelModel._Maps.ElementAt(0).Wigth = double.Parse(Width.Text.ToString());
					LevelModel._Maps.ElementAt(0).Heigth = 650;
					LevelModel.Time = int.Parse(Time.Text.ToString());
					LevelModel.Title = Number.Text.ToString();
					LevelModel.Number = int.Parse(Numb.Text.ToString());
					LevelModel.Save(saveDl.FileName);
				}
				catch(Exception e1)
				{
					MessageBox.Show("Error into map editor. Check all data and try again! (Check option info)");
				}
			}
		}

		private void Open_click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFDl = new OpenFileDialog();
			openFDl.DefaultExt = ".dat";
			openFDl.Filter = "DAT documents (.dat)|*.dat";
			Nullable<bool> result = openFDl.ShowDialog();
			if (result == true)
			{
				try
				{
					ButtonBase1_OnClick(this, null);
					LevelModel = Level.Load(openFDl.FileName);
					LevelModel._Maps.First().FillMap(Canvas, EditorBackground, StackPanel, LevelModel._Mario, LevelModel._Luigi,Models.Difficulty.Easy);
					FillingMap();
				}
				catch(Exception e1)
				{
					MessageBox.Show("Error! Invalid file content!");
					ButtonBase1_OnClick(this, null);
				}
				
			}
		}
	}
}
