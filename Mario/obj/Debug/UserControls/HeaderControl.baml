   M S B A M L   `   `   `  ����H  DMarioBros2015, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Lab5_KPZ.UserControlsLab5_KPZ.UserControls  5      9!clr-namespace:Lab5_KPZ.ConvertorsLab5_KPZ.Convertors  5      )    #Lab5_KPZ.UserControls.HeaderControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Lab5_KPZ.UserControls     5      8
convertors!clr-namespace:Lab5_KPZ.Convertors     5      $
��Auto��5      .��5	      � $	��100��6     � 	Resources  5
   
   +  %Lab5_KPZ.Convertors.ControlVisibility   ControlVisibilityConvert��%   &	          5      6+   5       � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��100 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Stretch=�6.   $��Stretch=�6J   $��0��6h   .+�5      (   "Lab5_KPZ.UserControls.LuigiControl  $��Stretch=�6!   5      � 5   
   $��1��6    � RowDefinitions 5      �� 5      �� 5      .+�5      �� $��Center=�6   $��Center=�6/   
�������$��0��6_   .��5      �� .�6   .�5      �� $
��Wrap=�6    $��25(�64   $
��Time��6B    �� TextAlignment$ Center=�6N   5      5      �� 5      -   5         ��Name$ 	LevelTime��5   ?   $��Center=�5      $��Center=�6/   $
��Bold"�6L   $��25(�6^   $��Center=�6l   
�������$��1��5   f   ��6   ��  �� Path$ CurrentLevel.Time� �� Mode$ OneWay=�5       �� 5!      -   5         ��Name$ border1��5!      $��1q�6&   
����·�$��1��6U   �� 5"      -   5        $ border2��5"      $��1q�6'   
����·�$��0��6V   5#      �� 5$   
   -   5        $ border3��5$      $��2q�6#   
����·�$��0��6R   5%      5&      