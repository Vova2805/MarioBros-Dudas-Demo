   M S B A M L   `   `   `  ����C  ?Lab5_KPZ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Lab5_KPZLab5_KPZ  5          Lab5_KPZ.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      (localclr-namespace:Lab5_KPZ     5        �� 	Resources  5         	Gradients �� 
StartPoint �� EndPoint � Color � Offset �� 
TargetType �� Property �� Value �� 
TargetType	 ��Name
 �� RadiusX �� RadiusY J� BitmapEffect � Triggers :� RoutedEvent ��Name g� RepeatBehavior g� AutoReverse �� 
TargetName �� TargetProperty �� From	 �� To g� Duration g� 	BeginTime �� BeginStoryboardName �� Triggers P� Property P� Value �� 
TargetName��%�  &	        '�� '    7   �� 5   
   $	 0,0&�5      $	 1,1&�6   .��5      � $
 Navy��6*   $ 0Q�67   � 5	      $ DarkCyan��6*   $	 0.3Q�6;   � 5
      $ 
Aquamarine��6*   $	 0.5Q�6=   � 5      $ DarkCyan��6*   $	 0.7Q�6;   � 5      $
 Navy��6*   $ 1Q�67   5      �� 5   
   " ��6   ButtonStyle��.�5      ��  � ��8   6,   �� 5       � ��$	 300��6&   �� 5       � ��$ 60��6'   �� 5       � ��$ 20(�6)   �� 5       � ��$ 
ExtraBlack"�6+   �� 5       � ��$ 15q�6'   �� 5       � �� 5      �� 5      " ��6#   .R�5      � #��z��6   #��z��6-   }�. .+�5      �� $	 
Rectangle1��6(   $��Stretch=�5   
   $��Stretch=�5   
   $
 20��5   
   $ 20��5   
   $��1��6   
���   ���5!   "   �� 5"   &   	brush��$	 0,0&�6I   $	 1,1&�6Z   .��5#   *   � 	stop1��$
 Navy��6F   $ 0Q�6S   � 5$   *   	stop2��$ DarkCyan��6F   $	 0.3Q�6W   � 5%   *   	stop3��$ 
Aquamarine��6F   $	 0.5Q�6Y   � 5&   *   	stop4��$ DarkCyan��6F   $	 0.7Q�6W   � 5'   *   	stop5��$
 Navy��6F   $ 1Q�6S   5(   '   z�5*   "   V� 5+   	   .~�5,   
   �� 5-   
    5/   "   �� 50   &    52   "   :� 53   &   $ 
MouseEnter��63   [�54   *   �� 55   .   $ mouseEnterBeginStoryboard��6>   .��56   2   �� $ Forever��6=    . .��57   6   �� $ stop1��6E   $ Color�6c   $	 RedX�58      $ GreenX�6#   $ 0:0:1D�6.   $ 0:0:0X�6?   �� 59   6   $ stop1��6E   $ Color�6c   $ GreenX�5:      $
 BlueX�6%   $ 0:0:1D�6/   $ 0:0:0.5X�6@   �� 5;   6   $ stop1��6E   $ Color�6c   $
 BlueX�5<      $	 RedX�6$   $ 0:0:1D�6-   $ 0:0:1X�6>   �� 5=   6   $ stop2��6E   $ Color�6c   $ GreenX�5>      $
 BlueX�6%   $ 0:0:1D�6/   $ 0:0:0X�6@   �� 5?   6   $ stop2��6E   $ Color�6c   $
 BlueX�5@      $	 RedX�6$   $ 0:0:1D�6-   $ 0:0:0.5X�6>   �� 5A   6   $ stop2��6E   $ Color�6c   $	 RedX�5B      $ GreenX�6#   $ 0:0:1D�6.   $ 0:0:1X�6?   �� 5C   6   $ stop3��6E   $ Color�6c   $
 BlueX�5D      $	 RedX�6$   $ 0:0:1D�6-   $ 0:0:0X�6>   �� 5E   6   $ stop3��6E   $ Color�6c   $	 RedX�5F      $ GreenX�6#   $ 0:0:1D�6.   $ 0:0:0.5X�6?   �� 5G   6   $ stop3��6E   $ Color�6c   $ GreenX�5H      $
 BlueX�6%   $ 0:0:1D�6/   $ 0:0:1X�6@   �� 5I   6   $ stop4��6E   $ Color�6c   $ GreenX�5J      $
 BlueX�6%   $ 0:0:1D�6/   $ 0:0:0X�6@   �� 5K   6   $ stop4��6E   $ Color�6c   $
 BlueX�5L      $	 RedX�6$   $ 0:0:1D�6-   $ 0:0:0.5X�6>   �� 5M   6   $ stop4��6E   $ Color�6c   $	 RedX�5N      $ GreenX�6#   $ 0:0:1D�6.   $ 0:0:1X�6?   �� 5O   6   $ stop5��6E   $ Color�6c   $
 BlueX�5P      $	 RedX�6$   $ 0:0:1D�6-   $ 0:0:0X�6>   �� 5Q   6   $ stop5��6E   $ Color�6c   $	 RedX�5R      $ GreenX�6#   $ 0:0:1D�6.   $ 0:0:0.5X�6?   �� 5S   6   $ stop5��6E   $ Color�6c   $ GreenX�5T      $
 BlueX�6%   $ 0:0:1D�6/   $ 0:0:1X�6@   5U   3   5V   /   5X   '   :� 5Y   &   $ 
MouseLeave��63   [�5Z   *   �� 5[   .   $ mouseEnterBeginStoryboard��6=   5]      5_      ]� 5`      $��ButtonContent��6(   $��Center=�6=   $��Center=�6Z   $
��Auto��6u   .+�5a   "   �� #��z��63   $��10q�6W   $��Center=�6c   5b      5c       5d      P� 5e       �@J�IsMouseOver . . �5f   "   �� $ 
Rectangle1��6;   # Z	�5g       � ���� 5h   "   $ 
Rectangle1��6<    �@J�Opacity$ 1Q�6T   5i      5k      5m      5n      5o      5r      