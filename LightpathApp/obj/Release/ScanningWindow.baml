   M S B A M L   `   `   `  ����   LightpathApp!    LightpathApp.ScanningWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Scanning Sample�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � SizeToContent$ WidthAndHeight=� � WindowStyle$
 None=� � 	Resources    lightPointFontStyle �� 
TargetType �� Property �� Value  buttonStyle	 �� 
TargetType
 �� CornerRadius �� Triggers P� Property P� Value  textBoxStyle��%  &	        &	 .     &	 R    �� " ��.���  � ��$ Comic Sans MS)��� " ��.���  � ��
 �������  � ��
 �   ���  � ��$ Comic Sans MS)���  � ��$
 Bold"���  � �� �� "	 ��.R��� $
 4��#��z��$��4q�
���   �._��� $��4q�$��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � ��
 ������ " ��.���  � ��
 �������  � ��
 �   ���  � ��$ Comic Sans MS)� P�  �@J�IsMouseOver . . ���  � ��
 ����.���� 
�������$��2q�._�� .+��� ���#6D68FC �� Orientation$ Vertical=�.+��� $ 
Horizontal=�.+��� -    ��Name$ StartMessage��$��Acquiring CLI Image...��$
��Bold"�$��16(�$��10,10,100,10q�$��Center=��� -    ��Name$ 
CancelScan��$��Cancel��$��10q�#���  $��4q�$��Center=�$
��Bold"�$��20(�$��Center=��� $ 
Horizontal=�$��30,0,0,0q�.+�� -    �Name$ StartProgressBar��
�������$��Center=�$��30��$	��300�� � Value$ 10Q��� -   $ ImagePercentage��$	��56%��$��10q�$
��Bold"��� $ 
Horizontal=�$��	80,0,0,10q�.+��� $,��&...approxmiately 12 minutes remaining.��