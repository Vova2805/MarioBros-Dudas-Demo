   M S B A M L   `   `   `  ����H  DMarioBros2015, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Lab5_KPZ.Views.XAMLsLab5_KPZ.Views.XAMLs  5      9!clr-namespace:Lab5_KPZ.ConvertorsLab5_KPZ.Convertors  5           Lab5_KPZ.Views.XAMLs.Score   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Lab5_KPZ.Views.XAMLs     5      8
convertors!clr-namespace:Lab5_KPZ.Convertors     5        N� Title$  Score��5	      .��5
      ��  �� Orientation$ Vertical=�6   $
��Auto��6(   $��Center=�65   $	��Top=�6R   .+�5   
   �� $��Center=�6   $��Center=�6+   
�������$��20(�6[   .��5      �� .�6   .�5      �� $
��Wrap=�6   $��Common score��60   5      5      �� 5   
   $
��Auto=�6   .��5      � $	��400��6    � 	Resources 5      (  "Lab5_KPZ.Convertors.AwardConvertor   AwardConvertor��%   &	          5      60   5       � RowDefinitions 5      �� 5      $��* �6$   .+�5      &   System.Windows.Controls.DataGrid  $��0��6   $��Stretch=�6(   $	��Top=�6F   "   VerticalScrollBarVisibility$
 Auto=�5         AutoGenerateColumns .  $��10(�5      $
��Bold"�6   $	��400��6(   ��5   $   ��  �� Path$ Players�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6-   	   
IsReadOnly	 . 
   	FontStyle$
 Italic$�6w   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� $
 Name� �� Mode$ OneWay=�6w     5      $ Player score��6-   	 .    
Foreground
 ��� � 6C   �� $ Score�$ OneWay=�6�     5      $ Coins quantity��6-   	 . 
 ��� � 6E   �� $ Coins�$ OneWay=�6�     5       $ Level��6-   	 . 
 ���_� 6<   �� $ Level�$ OneWay=�6y   4  .System.Windows.Controls.DataGridTemplateColumn  5!      $ Award��61      CellTemplate 5"      �� 5#   "   .R�5$   &   �� {�.  $	��100��6>   $	��100��6J   ��6X   �� $ Level� �� 	Converter# [  5%   #   5'      5*      5+      5,      �� 5-   
   .+�5.      �� -   5        $	��120��5.      $
��Auto��6!   $��Go back to menu��6/   $��9(�6I   6V   5/      50      52      