   M S B A M L   `   `   `  ����H  DMarioBros2015, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Lab5_KPZ.Views.XAMLsLab5_KPZ.Views.XAMLs  5      9!clr-namespace:Lab5_KPZ.ConvertorsLab5_KPZ.Convertors  5      *    $Lab5_KPZ.Views.XAMLs.SaveRestoreGame   5      ,ms%http://namespaces.mindscape.co.nz/wpf  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Lab5_KPZ.Views.XAMLs     5      8
convertors!clr-namespace:Lab5_KPZ.Convertors     5      .��5	      �� -   5          ��Name$  SaveRestore��5	   ,   $
��Auto��6   $
��Auto��6   $��Center=�6A   $��Center=�6\   $��0,50,0,0q�6y    � 	Resources 5
   
   +  %Lab5_KPZ.Convertors.ControlVisibility   ControlVisibilityConv��%   &	          5      6+   5      .+�5   
   �� $��Game is saved��6   
�������$
��Bold"�6;   $��20(�5      $��Center=�6   $��Center=�60   y�5      ��  �� Path$ SaveRestore� �� ConverterParameter$
 Save�� �� 	Converter# [  �� 5   
    �� Orientation$ Vertical=�6   $
��Auto��6,   $��Center=�69   $	��Top=�6V   y�5      �� $ SaveRestore�$ Restore��# [  .+�5      �� $��Center=�6   $��Center=�6/   
�������$��20(�6_   .��5      �� .�6   .�5      �� .F�5      �� $
��Wrap=�6$   $��Saved games��68   5      5      5      �� 5      $
��Auto=�6   .��5      � $	��200��6   $	��300��6$    � ColumnDefinitions 5      �� 5      $	��50* �6+   �� 5      $��* �6+    � RowDefinitions 5      �� 5       $��* �6(   .+�5"      &   System.Windows.Controls.DataGrid  -   5          Name$ PreviousGame��5%   <   $��0��5"      $��Stretch=�6,   $��Stretch=�6J   "	   VerticalScrollBarVisibility$
	 Auto=�5#      
   
IsReadOnly
 .    AutoGenerateColumns .  $��10(�5%      $
��Bold"�6   $��2��6(    5&      )  #System.Windows.Controls.DataGridRow �� 
TargetType��%E   '        �� 5'      "  6$   .�5(   "   -   5        5)      5*         Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��61      	FontStyle$ Italic$�6W      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6j   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Key+6j     5-      $ Level��61      
Foreground
 ���_�$ 70 6    6@   �� *Value._state.Number+6     5.      $
 Time��61   
 ���_�$ 50 6|    6?   �� *Value._state.Time+6|     5/      $ 	Map index��61   
 ���_�$ 60 6�    6D   �� *Value._state.currentMap+6�   51      52      53      �� 54      $ 
Horizontal=�6   $��Center=�62   $��5q�6O   .+�55      �� -   5        $��60��55      $
��Auto��6$   $��Close��62   $��9(�6B   $��5q�6O   6Z   56      57      58      59      