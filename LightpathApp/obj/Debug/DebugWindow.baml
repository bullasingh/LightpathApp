   M S B A M L   `   `   `  ����  LightpathApp    LightpathApp.DebugWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Debug Window��5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�6    � SizeToContent$ WidthAndHeight=�5   	    � 	Resources 5         lightPointFontStyle �� 
TargetType �� Property �� Value  buttonStyle �� 
TargetType	 �� CornerRadius
 �� Triggers P� Property P� Value  textBoxStyle��%�  &	        &	 S     &	 g    �� 5	   
   " ��6,   .�5
      ��  � ��$ Comic Sans MS)�6,   5      �� 5   
   " ��6$   .�5      ��  � ��
 �����6+   �� 5       � ��
 �   �6+   �� 5       � ��$ Comic Sans MS)�6,   �� 5       � ��$
 Bold"�6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $	 4��6!   #��z��62   $��4q�5   !   
���   �._�5      �� $��4q�6/   $��Center=�6:   $��Center=�6W   5      5      5      5      
 5      P� 5       �@J�IsMouseOver . . �5      ��  � ��
 ����63   5      5!      �� 5"   
   " ��6%   .�5#      ��  � ��
 �����6+   �� 5$       � ��
 �   �6+   �� 5%       � ��$ Comic Sans MS)�6,   
 5&      P� 5'       �@J�IsMouseOver . . �5(      ��  � ��
 ����63   5)      5+      5,      .��5.      � .+�5/   
   �� $
��Wait��6   $��Center=�6!   $��Center=�6>   .��50      �� .+�51      �� -   5         ��Name$ errorMessage��51      $��No Error��6.   $��36(�6A   $
��Bold"�6O   �� 52      -   5         ��Name$ terminateApp��52      $��Continue��6/   $��10,30q�6B   $��4q�6Q   $��Center=�6e   $
��Bold"�6�   $��20(�6�   6�   53      54      55      56      