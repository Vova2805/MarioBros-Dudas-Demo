   M S B A M L   `   `   `  ����H  DMarioBros2015, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Lab5_KPZ.Views.XAMLsLab5_KPZ.Views.XAMLs  5   	   =#clr-namespace:Lab5_KPZ.UserControlsLab5_KPZ.UserControls  5   	   9!clr-namespace:Lab5_KPZ.ConvertorsLab5_KPZ.Convertors  5   	   $    Lab5_KPZ.Views.XAMLs.MapEditor   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Lab5_KPZ.Views.XAMLs     5   	   <userControls#clr-namespace:Lab5_KPZ.UserControls     5   	   8
convertors!clr-namespace:Lab5_KPZ.Convertors     5   	   J FWpfAnimatedGif, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5	      -   5          � Title$  
Map editor��5   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�62    � Icon$% /Views/Source/Images/editor.ico��5       � SizeToContent$ WidthAndHeight=�6*    J� 	AllowDrop .  � 	Resources 5         ButtonBrush �� Color  ChangeBackgroundStoryboard �� 
TargetName	 �� TargetProperty
 R� KeyTime R� Value��%�   &	        &	      7   �� 5   
   $	 Red��6.   �� 5   
   .��5      T� $ BorderBrushProperty��6,   $	 
Background�5   (   ..�5      i� $
 0:0:0��6)   8   5   %   5      5      5      .��5      � 
����� � 5   
   +  %Lab5_KPZ.Convertors.ControlVisibility  ControlVisibilityConv��%   &	         5      6+   5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       $��* �6    � ColumnDefinitions 5"      �� 5#      $	��140 �6   �� 5$      $��* �6   .+�5&      �� $��0��6   $��0��6   $��2��6,   .+�5'      o� $	��Top=�6   .@�5(      m� $��_File��6   .@�5)      m� $
��_New��6   m� 5*      $��_Open��6   m� 5+      $��_Save��6   �� 5,      m� 5-      $��_Exit��6   5.      5/      50      �� 51   
    �� Orientation$ Vertical=�6   $��0��6,   $��1��6<   $
��Left=�6I   $	��212��6d   .+�52      �� -   5        $��Raster��52      $��10(�6&   $	��150��64   6V   �� 53      -   5        $��Clear��53      $��10(�6%   $	��150��63   6]   �� 54      -   5        $
��Open��54      $��10(�6$   $	��150��62   6S   �� 55      -   5        $
��Save��55      $��10(�6$   $	��150��62   6R   �� 56      -   5        $
��Exit��56      $��10(�6$   $	��150��62   6[   57      �� 58   
   -   5         ��Name$ ScrollViewer0��58   �   $��1��6   $��1��6$   $��Hidden=�64   $��Hidden=�6[   $	��500��6�   .��59      �� -   5         ��Name$ 
StackPanel��59   2   $ 
Horizontal=�6   $	��650��6F    K� ZIndex$ 1��6S   .+�5:      �� -	   5         ��Name$ EditorBackground��5:      $
��Fill=�63   $��Stretch=�6B   $
��Left=�6^   $	��800��6y   $(��"../Source/Images/Background/08.png��6�   5;      5<      �� 5=   
   -
   5        $ ScrollViewer1��5>   C   $��1��5=      $��1��6$   $
��Auto=�64   $��Hidden=�6Y   $��Stretch=�5>   	   $��Stretch=�6'   $	��500��5@      .��5A      �� -   5         ��Name$ Canvas��5A   O   $��Stretch=�6   $��Stretch=�63   $ 3��6_   $	��650��6j    5B       �� 
TargetType��%E   '��       �� 5C      " ��6   .�5D      -   5        5E      5F      5G      5H      �� 5I   
   $
��Auto=�6   $��2��6:   $��0��6G   $��2��6X   .��5J      � $��Stretch=�6   $��Stretch=�6/    5K      �� 5L      $��60 �6$   �� 5M      $��* �6$   .+�5O      �� $ 
Horizontal=�6   $��0��66   $��Center=�6C   $
��Auto��6`   .+�5P      �� $��Option��6   $��10(�6.   $	��150��6<   $��5q�6H   $��Option��6{   ��6S   ��  �� Path$ SetControlType�6�   �� 5Q      $��Heroes��6   $��10(�6.   $	��150��6<   $��5q�6H   $��Heroes��6{   ��6S   �� $ SetControlType�6�   �� 5R      $��Enemies��6   $��10(�6/   $	��150��6=   $��5q�6I   $��Enemies��6|   ��6T   �� $ SetControlType�6�   �� 5S      $��Items��6   $��10(�6-   $	��150��6;   $��5q�6G   $��Items��6z   ��6R   �� $ SetControlType�6�   5T      �� 5U      $ Vertical=�6   $��1��64   $��Stretch=�6B   $
��Auto��6`   $
��Auto��6n   .+�5V      �� $
��Auto=�6#   $��10q�6F   $��Hidden=�6R   $��Stretch=�6y   $��Stretch=�6�   y�5W      �� $ ControlType� �� 	Converter# [  �� ConverterParameter$ Option��.��5X      �  5Y      �� 5Z   "   $��40 �60   �� 5[   "   $
��Auto �60   �� 5\   "   $��40 �60   �� 5]   "   $
��Auto �60   �� 5^   "   .+�5`      �� $��	Map width��6$   
�������$��20(�6K   $
��Bold"�6Y   $��Stretch=�6k   $��Center=�5a      
����  �$��0��6=   6L   �� 5b      $��Background and music��6$   
�������$��20(�6V   $
��Bold"�6d   $��Stretch=�6v   $��Center=�5c      
����  �$��2��6=   6L   �� 5d      $ Vertical=�6)   $��3��6@   .+�5e   "   �� $
��Auto=�6/   $��Hidden=�6T   $��Stretch=�6y   .��5f   &   �� -   5        $ StackPanel1��5f   h    �� CanHorizontallyScroll . $ 
Horizontal=�6O    5g   *    �� Property �� Value �� Triggers :� RoutedEvent8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value��%�  '�       �� 5h   .   " �64   .�5i   2   ��  � ��$	 100��6K   6Y   �� 5j   2    � ��$	 100��6J   6X   �� 5k   2    � ��$ Stretch=�6V   6h   �� 5l   2    � ��$ Stretch=�6X   6j    5m      :� 5n   6   $ 
MouseEnter��6C   .[�5o   :   �� .��5p   >   �� .��5q   B   �� $/	 )(Grid.Background).(SolidColorBrush.Color)�6_   .g�5r   F     $ 0��6Z    	CadetBlue6f   5s   C   5t   ?   5u   ;   5v   7   :� 5w   6   $ 
MouseLeave��6C   .[�5x   :   �� .��5y   >   �� .��5z   B   �� $/	 )(Grid.Background).(SolidColorBrush.Color)�6_   .g�5{   F     $ 0��6Z    Transparent6f   5|   C   5}   ?   5~   ;   5   7   :� 5�   6   $ 	MouseDown��6C   .[�5�   :   �� .��5�   >   �� .��5�   B   �� $/	 )(Grid.Background).(SolidColorBrush.Color)�6_   .g�5�   F     $ 0��6Z    Red6f   5�   C   5�   ?   5�   ;   5�   7   5�   /   5�   +   .+�5�   *   � -   5        
������ |�. $��10q�5�   Z   .+�5�   .   �� $(��"../Source/Images/Background/08.png��64   |�. 6`   5�   +   � 5�   *   -   5        
������ |�. $��10q�5�   Z   .+�5�   .   �� $(��"../Source/Images/Background/01.png��64   |�. 6`   5�   +   � 5�   )   -   5        
������ |�. $��10q�5�   Y   .+�5�   .   �� $(��"../Source/Images/Background/02.png��64   |�. 6`   5�   *   � 5�   )   -   5        
������ |�. $��10q�5�   Y   .+�5�   .   �� $(��"../Source/Images/Background/03.png��64   |�. 6`   5�   *   � 5�   )   -   5        
������ |�. $��10q�5�   Y   .+�5�   .   �� $(��"../Source/Images/Background/04.png��64   |�. 6`   5�   *   � 5�   )   -   5        
������ |�. $��10q�5�   Y   .+�5�   .   �� $(��"../Source/Images/Background/05.png��64   |�. 6`   5�   *   � 5�   )   -   5        
������ |�. $��10q�5�   Y   .+�5�   .   �� $(��"../Source/Images/Background/06.png��64   |�. 6`   5�   *   � 5�   *   -   5        
������ |�. $��10q�5�   Z   .+�5�   .   �� $(��"../Source/Images/Background/07.png��64   |�. 6`   5�   *   � 5�   )   -   5        
������ |�. $��10q�5�   Y   .+�5�   .   �� $-��'../Source/Images/Background/bgblock.png��64   |�. 6f   5�   *   � 5�   )   -   5        
������ |�. $��10q�5�   Y   .+�5�   .   �� $*��$../Source/Images/Background/back.png��64   5�   *   5�   '   5�   #   �� 5�   "   $ 
Horizontal=�6-   $��Center=�6F   .+�5�   &   �� $��Level title��6,   
�������$��15(�6U   $
��Bold"�6c   $��Stretch=�6u   $��Center=�5�      $��10q�6+   $��Center=�67   6[   �� 5�   &   -   5         ��Name$ Number��5�   F   $��30��6.   $	��100��6:   $��
Test level��6V   �� 5�   &   $��Level title��6,   
�������$��15(�6U   $
��Bold"�6c   $��Stretch=�6u   $��Center=�5�      $��10q�6+   $��Center=�67   6[   �� 5�   &   -   5        $
 Numb��5�   F   $��30��6.   $	��100��6:   $��1��6T   $��Center=�6]   $��20(�6�   �� 5�   &   $��Sound for map��6,   
�������$��15(�6W   $
��Bold"�6e   $��Stretch=�6w   $��Center=�5�      $��10q�6+   $��Center=�67   6[   �� 5�   &   -   5          ��Name$  PlayList��5�      $��Center=�60   $��Right=�6K   $��25��6g   $	��200��6s   5�   '   �� 5�      -   5        ! ��Name$
! Play��5�      $��30��6    $��20q�6,   .��5�   *   �� -   5        $ 	PlayImage��5�   0   $��../Source/Images/play.png��6C   6h   5�      �� 5�   &   $��Level time (s)��6,   
�������$��15(�6X   $
��Bold"�6f   $��Stretch=�6x   $��Center=�5�      $��10q�6+   $��Center=�67   6[   ]� 5�   &   $��Center=�60   $��10q�6K   $��1��6W   .+�5�   *   �� -   5        $
 Time��5�   �   $��Right=�6�   " �� TextAlignment$" Center=�6�   $��50��6�   ��62   �� # �� ElementName$# 	LevelTime��$ Value�$ �� UpdateSourceTrigger$$ PropertyChanged=�6�   �� 5�   *   -   5        $��	LevelTime��5�   |   % � Maximum$
% 1000Q�61   & � Minimum$	& 100Q�6@   ' �� TickFrequency$' 5Q�6O   ( �� IsSnapToTickEnabled( . $	��300��6�   5�   '   5�   #   5�      ]� 5�      $��Center=�6(   $��10q�6C   $��1��6O   .+�5�   "   �� -   5        $ Width��5�   �   $��Right=�6�   $" Right=�6�   $��50��6�   ��6*   �� $# slValue��$ Value�$$ PropertyChanged=�6�   �� 5�   "   -    5        $��slValue��5�   u   $
% 5000Q�6)   $
& 2000Q�68   $' 5Q�6H   ( . 6�   5�      5�      5�      � 5�      $��10q�6   y�6'   �� $ ControlType�# [ $ Heroes�� 5�      �� 5�      $��40 �6,   �� 5�      $
��Auto �6,   �� 5�       5�      ��%  '��       �� 5�      " ��6$   .�5�   "   -!   5        �� 5�   "    � ��$ 50��6;   6H   �� 5�   "    � ��$ 50��6:   6G   �� 5�   "    � ��$ Center=�6H   6Y   �� 5�   "    � ��$ Center=�6F   6W   �� 5�   "    � ��$
 Fill=�6<   5�      5�      .+�5�      �� $��Drag and drop heroes��6    
�������$��20(�6R   $
��Bold"�6`   $��Stretch=�6r   $��Center=�5�      
����  �$��0��6=   6L   �� 5�      $��1��6#   $��Stretch=�60   $��Stretch=�6L   .+�5�      �� -"   5        $ 
MarioImage��5�   R   $*��$../Source/Images/Mario/NormRight.png��6$   6R   �� 5�      -#   5        $ 
LuigiImage��5�   S   $+��%../Source/Images/Luigi/luigi_game.png��6$   6S   5�      5�      � 5�      $��10q�6   y�6'   �� $ ControlType�# [ $ Enemies�� 5�      �� 5�      $��40 �6,   �� 5�      $
��Auto �6,   �� 5�       5�      ��%�   '��       �� 5�      " ��6$   .�5�   "   -$   5        �� 5�   "    � ��$ 50��6;   6H   �� 5�   "    � ��$ 50��6:   6G   �� 5�   "    � ��$ Center=�6H   6Y   �� 5�   "    � ��$ Center=�6F   6W   5�      5�      .+�5�      �� $��Drag and drop enemies��6    
�������$��20(�6S   $
��Bold"�6a   $��Stretch=�6s   $��Center=�5�      
����  �$��0��6=   6L   �� 5�      $��1��6#   .+�5�      �� -%   5        $ Goomba��5�   a   $9��3../Source/Images/Enemies/Goomba/Goomba_Normal_1.png��6$   6a   �� 5�      -&   5        $ Koopa��5�   b   $:��4../Source/Images/Enemies/Koopa/Koopa_Red_Right_2.png��6$   6b   5�      5�      � 5�      -'   5        ) �Name$) AllItems��5�   '   $��10q�6   y�6:   �� $ ControlType�# [ $ Items�� 5�      �� 5�      $��40 �6,   �� 5�      $
��Auto �6,   �� 5�      $��40 �6,   �� 5�      $
��Auto �6,   �� 5�      $��40 �6,   �� 5�      $
��Auto �6,    5     ��%�   '��       �� 5     " ��6$   .�5  "   -(   5        �� 5  "    � ��$ 50��6;   6H   �� 5  "    � ��$ 50��6:   6G   �� 5  
    � ��$
 Fill=�6$   5     5     .+�5	     �� $��Drag and drop blocks��6    
�������$��20(�6R   $
��Bold"�6`   $��Stretch=�6r   $��Center=�5
     
����  �$��0��6=   6L   �� 5     -)   5        * ��Name$* Blocks��5  j   $��1��6#   $��Stretch=�60   $��Stretch=�6L   .+�5     �� $3��-../Source/Images/Items/Blocks/block_brown.png��6$   �� 5     -*   5        $ Bonus��5  ]   $5��/../Source/Images/Items/Blocks/bonus_block_1.png��6$   6]   �� 5     -+   5        $ Brick��5  U   $-��'../Source/Images/Items/Blocks/brick.png��6$   6U   �� 5     $3��-../Source/Images/Items/Blocks/brick_empty.png��6$   �� 5     -,   5        $
 Flag��5  [   $3��-../Source/Images/Items/Blocks/evil_flag_1.png��6$   6[   �� 5     --   5        $
 Gate��5  l   $,��&../Source/Images/Items/Blocks/exit.png��6$   $��50��6U   $��50��6a   6l   �� 5     $6��0../Source/Images/Items/Blocks/grass_center_1.png��6$   �� 5     $4��.../Source/Images/Items/Blocks/grass_left_1.png��6$   �� 5     $6��0../Source/Images/Items/Blocks/grass_center_2.png��6$   �� 5     $6��0../Source/Images/Items/Blocks/grass_center_3.png��6$   �� 5     $4��.../Source/Images/Items/Blocks/grass_left_2.png��6$   �� 5     $4��.../Source/Images/Items/Blocks/grass_left_3.png��6$   �� 5     $5��/../Source/Images/Items/Blocks/grass_right_1.png��6$   �� 5     $5��/../Source/Images/Items/Blocks/grass_right_2.png��6$   �� 5     $5��/../Source/Images/Items/Blocks/grass_right_3.png��6$   �� 5     $/��)../Source/Images/Items/Blocks/ground1.png��6$   $��Stretch=�6W   �� 5     $/��)../Source/Images/Items/Blocks/ground2.png��6$   $��Stretch=�6W   $��Stretch=�6u   �� 5     $1��+../Source/Images/Items/Blocks/pipe_head.png��6$   �� 5     $1��+../Source/Images/Items/Blocks/pipe_body.png��6$   �� 5     $3��-../Source/Images/Items/Blocks/ground_left.png��6$   $��Right=�6[   �� 5      $5��/../Source/Images/Items/Blocks/ground_center.png��6$   $��Stretch=�6^   $��Stretch=�6|   �� 5!     $4��.../Source/Images/Items/Blocks/ground_right.png��6$   $
��Left=�6\   �� 5"     $:��4../Source/Images/Items/Blocks/ground_grass_block.png��6$   �� 5#     $7��1../Source/Images/Items/Blocks/ice_grass_block.png��6$   �� 5$     $4��.../Source/Images/Items/Blocks/island_block.png��6$   $��Uniform=�6\   �� 5%     -.   5        $ Platform��5%  \   $3��-../Source/Images/Items/Blocks/movingblock.png��6$   $
��None=�6n   5'     �� 5(     $��Drag and drop bonuses��6    
�������$��20(�6S   $
��Bold"�6a   $��Stretch=�6s   $��Center=�5)     
����  �$��2��6=   6L   �� 5*     -/   5        $* Bonuses��5*  k   $��3��6#   $��Stretch=�60   $��Stretch=�6L    5+     ��%�   '��       �� 5,  "   " ��6(   .�5-  &   ��  � ��$ 40��6?   6L   �� 5.  &    � ��$ 40��6>   6K   �� 5/  &    � ��$ Center=�6L   6]   �� 50  &    � ��$ Center=�6J   6[   -0   5        52  #   53     .+�54     �� -1   5        $ MushroomGreen��54  \   $4��.../Source/Images/Items/Bonus/MushroomGreen.png��6$   $��Right=�6s   �� 55     -2   5        $ MushroomRed��55  Z   $2��,../Source/Images/Items/Bonus/MushroomRed.png��6$   6Z   �� 56     -3   5        $
 Star��56  Z   $2��,../Source/Images/Items/Bonus/Rainbowstar.png��6$   6Z   �� 57     -4   5        $ Flower1��57  Y   $1��+../Source/Images/Items/Bonus/fireflower.png��6$   6Y   �� 58     -5   5        $ Flower2��58  U   $-��'../Source/Images/Items/Bonus/flower.png��6$   6U   59     �� 5:     $��Drag and drop coins��6    
�������$��20(�6Q   $
��Bold"�6_   $��Stretch=�6q   $��Center=�5;     
����  �$��4��6=   6L   �� 5<     -6   5        $* Coins��5<  k   $��5��6#   $��Stretch=�60   $��Stretch=�6L    5=     ��%�   '��       �� 5>  "   " ��6(   .�5?  &   ��  � ��$ 25��6?   6L   �� 5@  &    � ��$ 25��6>   6K   �� 5A      � ��$ Center=�61   6B   �� 5B  &    � ��$ Center=�6J   6[   -7   5        5D  #   5E     .+�5F     �� "  WpfAnimatedGif.ImageBehavior+   AnimatedSource$<+ 6../../Views/Source/Images/Items/Coins/AnimatedCoin.GIF��6$   $
��Fill=�6~   $��Stretch=�6�   $��Stretch=�6�   $��55��6�   $��60��6�   5G     5H     5I     5J     5K     5L     5M     