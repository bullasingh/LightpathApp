   M S B A M L   `   `   `  ����  LightpathApp&     LightpathApp.ConfigurationWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$)  #LightPointMedical Speciman Analyser��5   	    � WindowState$ 	Maximized=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � 	Resources 5	         lightPointFontStyle �� 
TargetType �� Property �� Value  buttonStyle �� 
TargetType	 �� CornerRadius
 �� Triggers P� Property P� Value  textBoxStyle��%�  &	        &	 S     &	 g    �� 5
   
   " ��6,   .�5      ��  � ��$ Comic Sans MS)�6,   5      �� 5   
   " ��6$   .�5      ��  � ��
 �����6+   �� 5       � ��
 �   �6+   �� 5       � ��$ Comic Sans MS)�6,   �� 5       � ��$
 Bold"�6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $	 4��6!   #��z��62   $��4q�5   !   
���   �._�5      �� $��4q�6/   $��Center=�6:   $��Center=�6W   5      5      5      5      
 5      P� 5       �@J�IsMouseOver . . �5      ��  � ��
 � � �63   5       5"      �� 5#   
   " ��6%   .�5$      ��  � ��
 �����6+   �� 5%       � ��
 �   �6+   �� 5&       � ��$ Comic Sans MS)�6,   
 5'      P� 5(       �@J�IsMouseOver . . �5)      ��  � ��
 ����63   5*      5,      5-      .��50      � .+�51   
   ��  K� ZIndex$ 0��6   $��0q�6!   $
��Fill=�6,   ��52      ��53      Proposed GUI_Main.jpg��65   55      �� 56   
   $ 0��6   $��0q�6!   $
��Fill=�6,   ��57      ��58      Proposed GUI_Main.jpg��65   5:      ]� 5<   
   $��0,90,0,0q�6   ��5=      �� 5>       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5?      �  � Color$ 	CadetBlue��6#    � Offset$ 0Q�65   � 5@      $ White��6#   $ 1Q�61   5A      .+�5C      ��  �� Orientation$ 
Horizontal=�6   .+�5D      �� $ Vertical=�6   .+�5E      �� $ 
Horizontal=�6!   .+�5F      �� $��	Gain Type��6    �� 5G      -   5         ��Name$ ComboBoxEmccdGainType��5G   #   $	��177��6B   .@�5H      �� -   5        $��EmccdGainEmccd��5H   +   .��6A   Electron-multiplying CCD6[   �� 5I      -   5        $��EmccdGainConventional��5I   +   .��6H   Conventional CCD6Z   5J      5K      �� 5L      $ 
Horizontal=�6!   .+�5M      �� $��Pre-Amp��6    �� 5N      -   5        $ ComboBoxEmccdPreAmp��5N   #   $	��177��6@   .@�5O      �� -   5        $��EmccdPreampGain1��5O   +   .��6C   Gain 16K   �� 5P      -   5        $��EmccdPreampGain2��5P   +   .��6C   Gain 26K   �� 5Q      -   5        $��EmccdPreampGain3��5Q   +   .��6C   Gain 36K   5R      5S      �� 5T      $ 
Horizontal=�6!   .+�5U      �� $��
EMCCD Gain��6    �� 5V      -   5         ��Name$ SliderEmccdGain��5V   !   $	��177��6:    � Maximum$	 300Q�6F    � Minimum$ 1Q�6T   5W      �� 5X      $ 
Horizontal=�6!   .+�5Y      �� $��Shutter��6    �� 5Z      -	   5        $ ComboBoxEmccdShutter��5Z   #   $	��177��6A   .@�5[      �� -
   5        $��EmccdShutterAuto��5[   +   .��6C   Automatic - use caution6\   �� 5\      -   5        $��EmccdShutterClosed��5\   +   .��6E   Always closed6T   �� 5]      -   5        $��EmccdShutterOpen��5]   +   .��6C   Always open6P   5^      5_      �� 5`      $ 
Horizontal=�6!   .+�5a      �� -   5         ��Name$  CheckBoxEmccdStabilisation��5a   #   $ ��Require stable temperature��6G   5b      �� 5c      $ 
Horizontal=�6!   .+�5d      �� $��Target Temp��6    $��86��66   �� 5e      -   5         ��Name$ TextboxEmccdTemp��5e   "   $��23��6<    �� TextWrapping$
 Wrap=�6H   $��Target Temp��6\   $��85��6o   5f      �� 5g      $ 
Horizontal=�6!   .+�5h      �� $��Horizontal Shift Speed��6    �� 5i      -   5        $ ComboBoxEmccdHss��5i   #   $	��112��6=   5j      �� 5k      $ 
Horizontal=�6!   .+�5l      �� $��Vertical Shift Speed��6    �� 5m      -   5        $ ComboBoxEmccdVss��5m   #   $	��112��6=   .@�5n      �� -   5        $��EmccdVss0300Ns��5n   +   .��6A   0.3 us6I   �� 5o      -   5        $��EmccdVss0500Ns��5o   +   .��6A   0.5 us6I   �� 5p      -   5        $��EmccdVss0900Ns��5p   +   .��6A   0.9 us6I   �� 5q      -   5        $��EmccdVss1700Ns��5q   +   .��6A   1.7 us6I   �� 5r      -   5        $��EmccdVss3300Ns��5r   +   .��6A   3.3 us6I   5s      5t      �� 5u      $ 
Horizontal=�6!   .+�5v      �� $��Vertical Clocking Voltage��6    �� 5w      -   5        $ ComboBoxEmccdVcv��5w   #   $	��112��6=   .@�5x      �� -   5        $��EmccdVcvNormal��5x   +   .��6A   Normal6I   �� 5y      -   5        $��EmccdVcvPlus1��5y   +   .��6@   Plus 16H   �� 5z      -   5        $��EmccdVcvPlus2��5z   +   .��6@   Plus 26H   �� 5{      -   5        $��EmccdVcvPlus3��5{   +   .��6@   Plus 36H   �� 5|      -   5        $��EmccdVcvPlus4��5|   +   .��6@   Plus 46H   5}      5~      �� 5      $ Vertical=�6!   .+�5�      �� $ 
Horizontal=�6%   .+�5�      �� $��Exposure Time (s)��6$   �� 5�      -   5        $ TextBoxEmccdExposure��5�   &   $
 Wrap=�6D   $��TextBox��6X   $	��112��6g   5�      �� 5�      $ 
Horizontal=�6%   .+�5�      �� $��First column��6$   �� 5�      -   5        $ TextBoxEmccdFirstCol��5�   &   $
 Wrap=�6D   $��TextBox��6X   $	��112��6g   5�      �� 5�      $ 
Horizontal=�6%   .+�5�      �� $��Last column��6$   �� 5�      -   5        $ TextBoxEmccdLastCol��5�   &   $
 Wrap=�6C   $��TextBox��6W   $	��112��6f   5�      �� 5�      $ 
Horizontal=�6%   .+�5�      �� $��	First row��6$   �� 5�      -   5        $ TextBoxEmccdFirstRow��5�   &   $
 Wrap=�6D   $��TextBox��6X   $	��112��6g   5�      �� 5�      $ 
Horizontal=�6%   .+�5�      �� $��Last row��6$   �� 5�      -    5        $ TextBoxEmccdLastRow��5�   &   $
 Wrap=�6C   $��TextBox��6W   $	��112��6f   5�      5�      5�      �� 5�      $ Vertical=�6   .+�5�      �� $ 
Horizontal=�6!   .+�5�      �� $��Horizontal Bin Size��6    �� 5�      -!   5        $ ComboBoxEmccdHBinSize��5�   #   $	��111��6B   .@�5�      �� -"   5         ��Name$ HBin0��5�   +   $��1��6:   �� 5�      -#   5        $ HBin1��5�   +   $��2��6:   �� 5�      -$   5        $ HBin2��5�   +   $��4��6:   �� 5�      -%   5        $ HBin3��5�   +   $��8��6:   �� 5�      -&   5        $ HBin4��5�   +   $��16��6:   �� 5�      -'   5        $ HBin5��5�   +   $��32��6:   �� 5�      -(   5        $ HBin6��5�   +   $��64��6:   �� 5�      -)   5        $ HBin7��5�   +   $	��128��6:   �� 5�      -*   5        $ HBin8��5�   +   $	��256��6:   5�      5�      �� 5�      $ 
Horizontal=�6!   .+�5�      �� $��Vertical Bin Size��6    �� 5�      -+   5        $ ComboBoxEmccdVBinSize��5�   #   $	��111��6B   .@�5�      �� -,   5        $ VBin0��5�   +   $��1��6:   �� 5�      --   5        $ VBin1��5�   +   $��2��6:   �� 5�      -.   5        $ VBin2��5�   +   $��4��6:   �� 5�      -/   5        $ VBin3��5�   +   $��8��6:   �� 5�      -0   5        $ VBin4��5�   +   $��16��6:   �� 5�      -1   5        $ VBin5��5�   +   $��32��6:   �� 5�      -2   5        $ VBin6��5�   +   $��64��6:   �� 5�      -3   5        $ VBin7��5�   +   $	��128��6:   �� 5�      -4   5        $ VBin8��5�   +   $	��256��6:   5�      5�      �� 5�      $ 
Horizontal=�6!   .+�5�      �� $��Cooling Timeout (s)��6    �� 5�      -5   5        $ TextBoxEmccdCoolTimeout��5�   "   $
 Wrap=�6C   $��TextBox��6W   $	��111��6f   5�      �� 5�      $ 
Horizontal=�6!   .+�5�      �� $��Kinetic cycle time (s)��6    �� 5�      -6   5        $ TextBoxEmccdKineticTimeS��5�   "   $
 Wrap=�6D   $��TextBox��6X   $	��110��6h   5�      �� 5�      $ 
Horizontal=�6!   .+�5�      �� $��Kinetic series count��6    �� 5�      -7   5        $ TextBoxEmccdKineticCount��5�   "   $
 Wrap=�6D   $��TextBox��6X   $	��111��6h   5�      �� 5�      $ 
Horizontal=�6!   .+�5�      �� -8   5         ��Name$ ButtonEmccdApply��5�   !   $��Apply Settings��6;   #���  6T   �� 5�      -9   5        $ ButtonCancel��5�   !   $��
Cancel All��67   #���  6L   6r   �� 5�      -:   5        $ ButtonEmccdLoad��5�   !   $��Load Settings��6:   #���  6R   5�      5�      5�      5�      5�      5�      