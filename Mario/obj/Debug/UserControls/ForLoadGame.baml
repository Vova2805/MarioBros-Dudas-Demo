   M S B A M L   `   `   `  ����H  DMarioBros2015, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Lab5_KPZ.UserControlsLab5_KPZ.UserControls  5      9!clr-namespace:Lab5_KPZ.ConvertorsLab5_KPZ.Convertors  5      '    !Lab5_KPZ.UserControls.ForLoadGame   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Lab5_KPZ.UserControls     5      8
convertors!clr-namespace:Lab5_KPZ.Convertors     5      .��5	      �   � 	Resources  5
   
   +  %Lab5_KPZ.Convertors.ControlVisibility   ControlVisibilityConv��%   &	          5      6+   5      .+�5   
   �� $��images/one_player.png��6   $	��250��6/   �� 5   
   .+�5      �  � RowDefinitions 5      �� 5      $��0 �6$   61   �� 5      $��30 �6$   62   �� 5      $��15 �6$   62   �� 5      $
��Auto �6$   64   �� 5      $��60 �6$   62   .+�5      �� $	��Top=�6   $��Center=�60   
�������$��1��6`   .��5      �� .�6   .�5      �� -   5         ��Name$ TextBl��5   $   $
��Wrap=�64   $��10(�6H   $?��9For uploading saved game you have to sing in your account��6V   5      5      �� 5       �� Orientation$ 
Horizontal=�6   $��3��66   $��Center=�6C   $��Stretch=�6`   .+�5      �  5      �� 5       $��25 �6,   �� 5!      $��* �6,   .+�5#      �� $��Center=�6    $��Center=�6;   
�������$��0��6k   .��5$      �� .�6#   .�5%   "   �� $
��Wrap=�6,   $��10(�6@   $$��Enter your data for signing in��6N   5&      5'      � 5(      $��1��6    5)      �� 5*   "   $
��Auto �60   �� 5+   "   $
��Auto �60    � ColumnDefinitions 5-      �� 5.   "   $	��100 �63   �� 5/   "   $��* �63   .+�51      �� $��Center=�6$   $��Center=�6?   
�������$��0��6o   $��0��6|   .��52   "   �� .�6'   .�53   &   �� $
��Wrap=�60   $��10(�6D   $��	User name��6R   54   #   55      �� 56      $��Center=�6$   $��Center=�6?   
�������$��1��6o   $��0��6|   .��57   "   �� .�6'   .�58   &   �� $
��Wrap=�60   $��10(�6D   $��Password��6R   59   #   5:      �� 5;      -   5         ��Name$ 
LoginField��5;   &   $��1��6:   $��0��6J   $��Center=�6W   $��Center=�6t   $	��150��6�   6�   G� 5<      -   5         G�Name$ PassworField��5<   *   $��1��6@   $��1��6P   $��Center=�6]   $��Center=�6z   $	��150��6�   5=      5>      5?      �� 5@      -   5         ��Name$ submit��5@   *   $��Submit��6   $��Center=�6:   $��Center=�6W   $��4��5A      $	��200��6   $��9(�6    6-   5B      5C      5E      5F      