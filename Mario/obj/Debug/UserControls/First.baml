   M S B A M L   `   `   `  ����H  DMarioBros2015, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Lab5_KPZ.UserControlsLab5_KPZ.UserControls  5      9!clr-namespace:Lab5_KPZ.ConvertorsLab5_KPZ.Convertors  5      !    Lab5_KPZ.UserControls.First   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Lab5_KPZ.UserControls     5      8
convertors!clr-namespace:Lab5_KPZ.Convertors     5      .��5	      �   � 	Resources  5
   
   +  %Lab5_KPZ.Convertors.ControlVisibility   ControlVisibilityConv1��%   &	          5      6+   5       � RowDefinitions 5   
   �� 5      $��25 �6   6*   �� 5      $
��Auto �6   6,   .+�5   
   �� $	��Top=�6   $��Center=�6(   
�������$��0��6X   .��5      �� .�6   .�5      �� -   5         ��Name$ TextBl��5      $
��Wrap=�6,   $��10(�6@   $,��&Player #1 .Are you already registered?��6N   5      5      �� 5      $��2��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�6(   .+�5      �� $	��100��6   $
��Auto��6!   $	��Yes��6/   $��9(�6=   $��S��6n   ��6J   ��  �� Path$ 
SetChoose1�6�   �� 5      $	��100��6   $
��Auto��6!   $��No,but i want��6/   $��9(�6G   $��R��6x   ��6T   �� $ 
SetChoose1�6�   �� 5      -   5        $	��100��5      $
��Auto��6!   $��Start playing��6/   $��9(�6G   ��6T   �� $ 	StartPlay�6�   5      �� 5   
   $ 
Horizontal=�6   $��3��6.   $��Center=�6;   $��Stretch=�6X   .+�5      3   -Lab5_KPZ.UserControls.RegistrationUserControl  -   5          Name$ RegistrationUserControl��5   ,   y�6M   �� *_first+ �� 	Converter# [   �� ConverterParameter$ R��-   'Lab5_KPZ.UserControls.SignInUserControl  5      -   5          Name$ SignInUserControl��5   &   y�6B   �� *_first+# [  $ S��5       �� 5!      -   5        	 ��Name$	 Submit��5!   &   $��Submit��6   $��Center=�66   $��Center=�6S   $	��300��6�   $��40��6�   $��19(�6�   5"      5%      5&      