   M S B A M L   `   `   `  ����  LightpathApp!    LightpathApp.ScanningWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Scanning Sample��5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�6    � SizeToContent$ WidthAndHeight=�5   "    � WindowStyle$
 None=�5   	    � 	Resources 5	         lightPointFontStyle �� 
TargetType �� Property �� Value  buttonStyle	 �� 
TargetType
 �� CornerRadius �� Triggers P� Property P� Value  textBoxStyle��%�  &	        &	 S     &	 g    �� 5
   
   " ��6,   .�5      ��  � ��$ Comic Sans MS)�6,   5      �� 5   
   " ��6$   .�5      ��  � ��
 �����6+   �� 5       � ��
 �   �6+   �� 5       � ��$ Comic Sans MS)�6,   �� 5       � ��$
 Bold"�6+   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� $
 4��6!   #��z��62   $��4q�5   !   
���   �._�5      �� $��4q�6/   $��Center=�6:   $��Center=�6W   5      5      5      5       5      P� 5       �@J�IsMouseOver . . �5      ��  � ��
 ����63   5       5"      �� 5#   
   " ��6%   .�5$      ��  � ��
 �����6+   �� 5%       � ��
 �   �6+   �� 5&       � ��$ Comic Sans MS)�6,    5'      P� 5(       �@J�IsMouseOver . . �5)      ��  � ��
 ����63   5*      5,      5-      .��5/      �� 
�������$��2q�6!   ._�50   
   � .+�51      �� ���#6D68FC �� Orientation$ Vertical=�6/   .+�52      �� $ 
Horizontal=�6   .+�53      �� -   5         ��Name$ StartMessage��53      $��Acquiring CLI Image...��62   $
��Bold"�6S   $��16(�6e   $��10,10,100,10q�6s   $��Center=�6�   �� 54      -   5         ��Name$ 
CancelScan��54      $��Cancel��61   $��10q�6B   #���  6N   $��4q�6t   $��Center=�6�   $
��Bold"�6�   $��20(�6�   $��Center=�6�   55      �� 56      $ 
Horizontal=�6   $��30,0,0,0q�66   .+�57      � -   5         �Name$ ScanProgressBar��57   "   
�������$��Center=�6N   $��30��6k   $	��300��6w    � Value$ 0Q�6�   �� 58      -   5        $ ImagePercentage��58      $��0%��65   $��10q�6B   $
��Bold"�6N   59      �� 5:      $ 
Horizontal=�6   $��	80,0,0,10q�66   .+�5;      �� -   5        $ ProgressText��5;      $,��&...approxmiately xx minutes remaining.��62   5<      5=      5>      5?      5@      