   M S B A M L   `   `   `  ����H  DMarioBros2015, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Lab5_KPZ.UserControlsLab5_KPZ.UserControls  5      (    "Lab5_KPZ.UserControls.MarioControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Lab5_KPZ.UserControls     5      J FWpfAnimatedGif, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5      .��5
      � $	��600��6     � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��images/portrait-mario.png��6   $��0��63   �� 5   
    �� Orientation$ Vertical=�6   $��1��6,   $��2��6<   $��	3,0,147,0q�6P   .+�5      �� 
�������$��Center=�6'   $��8q�6D   .��5      �� .�6   .�5      �� $��15(�6     �� TextAlignment$ Center=�6.   $��Mario��6E   5      5      �� 5      $ 
Horizontal=�6   $	��Top=�62   $��Center=�6J   $	��-20q�6g   .+�5      �� -   5         ��Name$ 	MarioLife��5   	   
�������$��Stretch=�5   +   $��Center=�6H   $��20(�5   	   $��Center=�6   $
��Bold"�6;   $��0��5      �� 5      
�������$��Center=�6,   $��Stretch=�6I   $��20(�6e   $
��Bold"�6s   $��Center=�6�   $�� x��6�   5      �� 5      
����� �$��Center=�6&   $
��Bold"�6C   $��20(�6U   $	��Top=�6c   $��10q�6�   ��6{   ��  �� Path$ FirstPlayer.Name� �� Mode$ TwoWay=�6�   5      �� 5    
   $ Vertical=�6   $��2��6-   .+�5!      �� $ 
Horizontal=�6   $��5q�62   .+�5"      �� "  WpfAnimatedGif.ImageBehavior   AnimatedSource$9 3../Views/Source/Images/Items/Coins/AnimatedCoin.GIF��6   $��Stretch=�6o   $��Stretch=�6�   $��55��6�   $��60��6�   �� 5#      
�������$��Center=�6+   $��Center=�6H   .��5$      �� .�6   .�5%      �� $��20(�6$   $ Center=�62   $��x ��6I   5&      5'      �� 5(      -   5        $ 
MarioCoins��5)   	   
�������$��Center=�5(   .   $��0��5)      $��Center=�5*   	   $
��Bold"�6&   $��20(�68   $��Center=�6F   5+      �� 5,      $ 
Horizontal=�6   $��5q�62   .+�5-      �� -   5        $ MarioPoints��5/      
�������$��Center=�5-   .   $��Center=�6J   $
��Bold"�5.   	   $��20(�6   $��Center=�6)   $��0��5/   	   6   �� 50      
�������$��Center=�6+   $��Center=�6H   .��51      �� .�6   .�52      �� $��15(�6$   $ Center=�62   $�� points ��6I   53      54      55      56      �� 58   
   $ Vertical=�6   $��3��6,   .+�59      �� 
�������$��1��6'   $��Center=�64   $��8q�6Q   .��5:      �� .�6   .�5;      �� $��15(�6    $ Center=�6.   $��World��6E   5<      5=      �� 5>      -   5        $ 
MarioWorld��5>   �   
�������$��Center=�6'   $��Center=�6C   $
��Bold"�6`   $��20(�6r   $��Center=�6�   $��1��6�   6�   5?      5@      5A      