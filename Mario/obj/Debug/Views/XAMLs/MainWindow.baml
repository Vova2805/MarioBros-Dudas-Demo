   M S B A M L   `   `   `  ����H  DMarioBros2015, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Lab5_KPZLab5_KPZ  5   	   9!clr-namespace:Lab5_KPZ.ConvertorsLab5_KPZ.Convertors  5   	   =#clr-namespace:Lab5_KPZ.UserControlsLab5_KPZ.UserControls  5   	       Lab5_KPZ.WindowBackground   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Lab5_KPZ     5   	   8
convertors!clr-namespace:Lab5_KPZ.Convertors     5   	   <userControls#clr-namespace:Lab5_KPZ.UserControls     5   	   -   5          �Name$  
MainWindow��5   	    � Title$ Mario by Dudas��5
   	    � WindowStartupLocation$ CenterScreen=�6     � Icon$ ../Source/Images/main.ico��6F    � SizeToContent$ WidthAndHeight=�6g    � 
ResizeMode$ NoResize=�6�    � WindowStyle$ ThreeDBorderWindow=�5   +   $
��1366��6e   $	��768��6r   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��79* �6   �� 5      $��4* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5        	 ��Name$	 BackgroundImage��5      $
��Fill=�6)   $��2��68   $��2��6I   )   #Lab5_KPZ.UserControls.HeaderControl  5   
   $
��Auto��6%   $y�Visible=�62   $��2��6G   $	��Top=�6[    � 5   
   -   5        $��MyFrame��5   1   $��1��6   $��2��6   $��Stretch=�6@   $��Stretch=�6\   $
��Auto��6z   $
��Auto��6�   
  � Source$
 Startup.xaml?�5        � NavigationUIVisibility$ Hidden=�6    K� ZIndex$ 1��6=   $	��Top=�6N   �� 5   
   -   5         ��Name$ Mario_canvas��5   X   $��1��6   $��Stretch=�6   $��Stretch=�6<   $��2��6n   .+�5      �� -   5        $	 Mario��5      $*��$../Source/Images/Mario/NormRight.png��6#   $
��Left=�6Q   $	��150��6l   $��Bottom=�6y   $��Uniform=�6�   $	��100��6�    �� Left$
 -110��6�   
 �� Top$	 140��6�   �� 5      -   5        $	 Luigi��5      $&�� ../Source/Images/Luigi/Luigi.png��6#   $
��Left=�6M   $	��150��6h   $��Bottom=�6u   $��Uniform=�6�   $	��125��6�   $
 -240��6�   $	 140��6�   5      5      5      