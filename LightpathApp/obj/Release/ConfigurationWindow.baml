   M S B A M L   `   `   `  ����   LightpathApp&     LightpathApp.ConfigurationWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$)  #LightPointMedical Speciman Analyser�� � WindowState$ 	Maximized=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � 	Resources    lightPointFontStyle �� 
TargetType �� Property �� Value  buttonStyle �� 
TargetType	 �� CornerRadius
 �� Triggers P� Property P� Value  textBoxStyle��%  &	        &	 .     &	 R    �� " ��.���  � ��$ Comic Sans MS)��� " ��.���  � ��
 �������  � ��
 �   ���  � ��$ Comic Sans MS)���  � ��$
 Bold"���  � �� �� " ��.R��� $	 4��#��z��$��4q�
���   �._��� $��4q�$��Center=�$��Center=�
 P�  �@J�IsMouseOver . . ���  � ��
 � � ��� " ��.���  � ��
 �������  � ��
 �   ���  � ��$ Comic Sans MS)�
 P�  �@J�IsMouseOver . . ���  � ��
 ����.��� .+���  K� ZIndex$ 0��$��0q�$
��Fill=�����Proposed GUI_Main.jpg���� $ 0��$��0q�$
��Fill=�����Proposed GUI_Main.jpg��]� $��0,90,0,0q�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	CadetBlue�� � Offset$ 0Q�� $ White��$ 1Q�.+���  �� Orientation$ 
Horizontal=�.+��� $ Vertical=�.+��� $ 
Horizontal=�.+��� $��	Gain Type���� -    ��Name$ ComboBoxEmccdGainType��$	��177��.@��� -   $��EmccdGainEmccd��.��Electron-multiplying CCD�� -   $��EmccdGainConventional��.��Conventional CCD�� $ 
Horizontal=�.+��� $��Pre-Amp���� -   $ ComboBoxEmccdPreAmp��$	��177��.@��� -   $��EmccdPreampGain1��.��Gain 1�� -   $��EmccdPreampGain2��.��Gain 2�� -   $��EmccdPreampGain3��.��Gain 3�� $ 
Horizontal=�.+��� $��
EMCCD Gain���� -    ��Name$ SliderEmccdGain��$	��177�� � Maximum$	 300Q� � Minimum$ 1Q��� $ 
Horizontal=�.+��� $��Shutter���� -	   $ ComboBoxEmccdShutter��$	��177��.@��� -
   $��EmccdShutterAuto��.��Automatic - use caution�� -   $��EmccdShutterClosed��.��Always closed�� -   $��EmccdShutterOpen��.��Always open�� $ 
Horizontal=�.+��� -    ��Name$  CheckBoxEmccdStabilisation��$ ��Require stable temperature���� $ 
Horizontal=�.+��� $��Target Temp��$��86���� -    ��Name$ TextboxEmccdTemp��$��23�� �� TextWrapping$
 Wrap=�$��Target Temp��$��85���� $ 
Horizontal=�.+��� $��Horizontal Shift Speed���� -   $ ComboBoxEmccdHss��$	��112���� $ 
Horizontal=�.+��� $��Vertical Shift Speed���� -   $ ComboBoxEmccdVss��$	��112��.@��� -   $��EmccdVss0300Ns��.��0.3 us�� -   $��EmccdVss0500Ns��.��0.5 us�� -   $��EmccdVss0900Ns��.��0.9 us�� -   $��EmccdVss1700Ns��.��1.7 us�� -   $��EmccdVss3300Ns��.��3.3 us�� $ 
Horizontal=�.+��� $��Vertical Clocking Voltage���� -   $ ComboBoxEmccdVcv��$	��112��.@��� -   $��EmccdVcvNormal��.��Normal�� -   $��EmccdVcvPlus1��.��Plus 1�� -   $��EmccdVcvPlus2��.��Plus 2�� -   $��EmccdVcvPlus3��.��Plus 3�� -   $��EmccdVcvPlus4��.��Plus 4�� $ Vertical=�.+��� $ 
Horizontal=�.+��� $��Exposure Time (s)���� -   $ TextBoxEmccdExposure��$
 Wrap=�$��TextBox��$	��112���� $ 
Horizontal=�.+��� $��First column���� -   $ TextBoxEmccdFirstCol��$
 Wrap=�$��TextBox��$	��112���� $ 
Horizontal=�.+��� $��Last column���� -   $ TextBoxEmccdLastCol��$
 Wrap=�$��TextBox��$	��112���� $ 
Horizontal=�.+��� $��	First row���� -   $ TextBoxEmccdFirstRow��$
 Wrap=�$��TextBox��$	��112���� $ 
Horizontal=�.+��� $��Last row���� -    $ TextBoxEmccdLastRow��$
 Wrap=�$��TextBox��$	��112���� $ Vertical=�.+��� $ 
Horizontal=�.+��� $��Horizontal Bin Size���� -!   $ ComboBoxEmccdHBinSize��$	��111��.@��� -"    ��Name$ HBin0��$��1���� -#   $ HBin1��$��2���� -$   $ HBin2��$��4���� -%   $ HBin3��$��8���� -&   $ HBin4��$��16���� -'   $ HBin5��$��32���� -(   $ HBin6��$��64���� -)   $ HBin7��$	��128���� -*   $ HBin8��$	��256���� $ 
Horizontal=�.+��� $��Vertical Bin Size���� -+   $ ComboBoxEmccdVBinSize��$	��111��.@��� -,   $ VBin0��$��1���� --   $ VBin1��$��2���� -.   $ VBin2��$��4���� -/   $ VBin3��$��8���� -0   $ VBin4��$��16���� -1   $ VBin5��$��32���� -2   $ VBin6��$��64���� -3   $ VBin7��$	��128���� -4   $ VBin8��$	��256���� $ 
Horizontal=�.+��� $��Cooling Timeout (s)���� -5   $ TextBoxEmccdCoolTimeout��$
 Wrap=�$��TextBox��$	��111���� $ 
Horizontal=�.+��� $��Kinetic cycle time (s)���� -6   $ TextBoxEmccdKineticTimeS��$
 Wrap=�$��TextBox��$	��110���� $ 
Horizontal=�.+��� $��Kinetic series count���� -7   $ TextBoxEmccdKineticCount��$
 Wrap=�$��TextBox��$	��111���� $ 
Horizontal=�.+��� -8    ��Name$ ButtonEmccdApply��$��Apply Settings��#���  �� -9   $ ButtonCancel��$��
Cancel All��#���  �� -:   $ ButtonEmccdLoad��$��Load Settings��#���  