   M S B A M L   `   `   `  ����C  ?Lab5_KPZ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Lab5_KPZLab5_KPZ  5          Lab5_KPZ.SettingsPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Lab5_KPZ     5        N� Title$  SettingsPage��5	       � 	Resources 5
         changeColorOnExpanded �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   &	        �� 5   
   " 9�6.    5      P� 5       �@9�
IsExpanded . . �5      ��  � ��
 �<��64   5      P� 5       �@9�
IsExpanded .  . �5      ��  � ��
 ��� �64   5      5      5      .��5      �� 
����  � �� CanVerticallyScroll . $	��500��6>   $��Center=�6J   $
��Auto��6g   $	��Top=�6u   .+�5   
   �� $	��Top=�6   $��Center=�6(   
�������$��60��6X   .��5      �� .�6   .�5      �� -   5        	 ��Name$	 TextBl��5      $
��Wrap=�6,   $��30(�6@   $��Game settings:��6N   5      5      � 5   
   $��Stretch=�6   $��Center=�6-   $��10,10,10,10q�6H   
 � RowDefinitions
 5      �� 5      $
��Auto �6    �� 5      $��40 �6    �� 5       $
��Auto �6    .+�5"      9� -   5         9�Name$ expander��5"   $   $��0��6   $��Current bottons��66   $��20(�6O   $
��Left=�6]   $	��Top=�6x   $	��480��6�   #��[  5#      .��5$      �� $��Visible=�6   $	��200��6E   .��5%      �� .+�5&      �� $��Ulysses��6$   �� 5'      $��The Great Gatsby��6$   �� 5(      $-��'A Portrait of the Artist as a Young Man��6$   �� 5)      $��Lolita��6$   �� 5*      $��Ulysses��6$   �� 5+      $��The Great Gatsby��6$   �� 5,      $-��'A Portrait of the Artist as a Young Man��6$   �� 5-      $��Lolita��6$   �� 5.      $��Ulysses��6$   �� 5/      $��The Great Gatsby��6$   �� 50      $-��'A Portrait of the Artist as a Young Man��6$   �� 51      $��Lolita��6$   �� 52      $��Ulysses��6$   �� 53      $��The Great Gatsby��6$   �� 54      $-��'A Portrait of the Artist as a Young Man��6$   �� 55      $��Lolita��6$   �� 56      $��Images/Luigi/Luigi.png��6   60   57      58      59      � 5:      $��1��6    � ColumnDefinitions 5;      �� 5<      $
��Auto �6'   �� 5=      $
��Auto �6'   .+�5?      �� 
�������$��0��6+   $
��Left=�6;   .��5@      �� .�6   .�5A      �� $
��Wrap=�6$   $��Sound :��68   $��20(�6G   5B      5C      �� 5D      -   5        $��ComboBox��5D   l   $��1��6   $��20��6+   $��50��67    �� Text$ ON��6B   .@�5E      �� .��6#   ON6'   �� 5F      .��6#   OFF6(   5G      5H      �� 5I       �� Orientation$ 
Horizontal=�6   $��2��62   $��Center=�6?   .+�5J      �� -   5        $	��150��5J      $
��Auto��6%   $��Save changes��63   $��10(�6J   $��
15,0,15,15q�6X   6�   �� 5K      -   5        $	��150��5K      $
��Auto��6%   $��Cancel��63   $��10(�6D   $��
15,0,15,15q�6R   6~   5L      5N      5P      5R      