   M S B A M L   `   `   `  ����H  DMarioBros2015, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Lab5_KPZ.UserControlsLab5_KPZ.UserControls  5      9!clr-namespace:Lab5_KPZ.ConvertorsLab5_KPZ.Convertors  5      (    "Lab5_KPZ.UserControls.LuigiControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Lab5_KPZ.UserControls     5      J FWpfAnimatedGif, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5      2
convertors!clr-namespace:Lab5_KPZ.Convertors  5      .��5
      ��   �� Orientation$  
Horizontal=�6    � 	Resources 5   
   +  %Lab5_KPZ.Convertors.ControlVisibility   ControlVisibilityConvert��%   &	          5      6+   5      .+�5   
   (   "Lab5_KPZ.UserControls.MarioControl  $	��600��6   �� 5      $��50��6   � 5   
   $	��600��6   y�6   �� *	_quantity+ �� 	Converter# [   �� ConverterParameter$	 Two�� � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   .+�5   
   �� $��images/portrait-luigi.png��6   $��0��63   �� 5      $  Vertical=�6   $��1��60   .+�5      �� 
�������$��Center=�6'   $��8q�6D   .��5      �� .�6   .�5      �� $��15(�6     �� TextAlignment$ Center=�6.   $��Luigi��6E   5      5      �� 5      $  
Horizontal=�6   $��Stretch=�66   $��Center=�6R   .+�5      �� -   5         ��Name$ 	LuigiLife��5"      
�������$��Stretch=�5   /   $��Center=�5    
   $��20(�6'   $��Center=�5!   
   $
��Bold"�6.   $��0��5"   
   6   �� 5#      
�������$��Center=�60   $��Stretch=�6M   $��20(�6i   $
��Bold"�6w   $��Center=�6�   $�� x��6�   5$      �� 5%      
����� �$��Center=�6*   $
��Bold"�6G   $��20(�6Y   $	��Top=�6g   ��6�   ��  �� Path$ SecondPlayer.Name� �� Mode$ TwoWay=�5&      �� 5'      $  Vertical=�6   $��2��61   .+�5(      �� $  
Horizontal=�6   $��5q�66   .+�5)      �� "  WpfAnimatedGif.ImageBehavior	   AnimatedSource$9	 3../Views/Source/Images/Items/Coins/AnimatedCoin.GIF��6   $��Stretch=�6s   $��Stretch=�6�   $��55��6�   $��60��6�   �� 5*      
�������$��Center=�6/   $��Center=�6L   .��5+      �� .�6   .�5,      �� $��20(�6(   $ Center=�66   $��x ��6M   5-      5.      �� 5/      -   5        $ 
LuigiCoins��52      
�������$��Center=�5/   2   $��Center=�50   
   $
��Bold"�6'   $��20(�69   $��Center=�51   
   $��0��52   
   6   53      �� 54      $  
Horizontal=�6   $��5q�66   .+�55      �� -   5        $ LuigiPoints��57      
�������$��Center=�55   2   $��Center=�6N   $
��Bold"�56   
   $��20(�6   $��Center=�6*   $��0��57   
   6   �� 58      
�������$��Center=�6/   $��Center=�6L   .��59      �� .�6   .�5:      �� $��15(�6(   $ Center=�66   $�� points ��6M   5;      5<      5=      5>      �� 5@      $  Vertical=�6   $��3��60   .+�5A      �� 
�������$��1��6+   $��Center=�68   $��8q�6U   .��5B      �� .�6   .�5C      �� $��15(�6$   $ Center=�62   $��World��6I   5D      5E      �� 5F      -   5        $ 
LuigiWorld��5G   :   
�������$��Center=�5F   +   $��Center=�6G   $
��Bold"�6d   $��20(�6v   $��Center=�5G   	   $��1��6.   6:   5H      5I      5J      5M      