   M S B A M L   `   `   `  ����   LightpathApp!    LightpathApp.MainScanWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$)  #LightPointMedical Speciman Analyser�� � WindowState$ 	Maximized=� � 
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
��Fill=�����Proposed GUI_Main.jpg��]� $��0,90,0,0q�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	CadetBlue�� � Offset$ 0Q�� $ White��$ 1Q�.+��� $
��Left=�$��20,0,0,0q�.+���  �� Orientation$ Vertical=�.+��� -   $��PatientInfo��$��Patient Information��$��10q�#���   $
��Bold"����� $ 0.5,1&�$ 0.5,0&�.��� $ 	LightGray��$ 0Q�� $ White��$ 1Q�.���� $ 
Horizontal=�$
��20,0q�.+��� $ Vertical=�.+��� $ Vertical=�.+��� $
��Name��$
��Bold"��� -    ��Name$ PatientName��$��Bulla Singh��#���  $��Normal"��� $ Vertical=�.+��� $��Date Of Birth���� -   $ 
PatientDOB��$��
09-10-1958��#���  $��Normal"��� $ Vertical=�.+��� $��Gender���� -   $ PatientGender��$
��Male��#���  $��Normal"��� $ Vertical=�.+��� $��
Patient ID���� -   $ 	PatientID��$��	#12345678��#���  $��Normal"��� .+��� -    ��Name$ PhotoPatient��$	��Top=�$��20,10,10,10q� �� StretchDirection$ DownOnly=�$	��200������  �� 	UriSource$ Simrit_3.jpg?��� -   $��HospitalInfo��$��Hospital Information��$��10q�#���   $
��Bold"����� $ 0.5,1&�$ 0.5,0&�.��� $ 	LightGray��$ 0Q�� $ White��$ 1Q�.���� $ Vertical=�$
��20,0q�.+��� $ Vertical=�$��0q�.+��� $��	Institute��$
��Bold"��� -   $ Institution��$*��$University College Hospital - London��#���  $��Normal"��� $ Vertical=�.+��� $��Surgeon��$
��Bold"��� -	   $ NameSurgeon��$��Joanna Bloggs��#���  $��Normal"��� $ Vertical=�.+��� $ 
Horizontal=�$��15q�.+��� $��	Procedure���� -
   $��ProcedureName��$��80��#���   �� $ 
Horizontal=�.+��� -   $��ImportButton��$��Import��$��5,5,20,5q�#���  �� -   $��
SaveButton��$
��Save��$
��20,5q�#���  �� -   $��ExportButton��$��Export��$��20,5,5,5q�#���  �� -   $��CliInfo��$��CLI Acquistion��$��10q�#���   $
��Bold"�$��Bottom=����� $ 0.5,1&�$ 0.5,0&�.��� $ 	LightGray��$ 0Q�� $ White��$ 1Q�.���� $ 
Horizontal=�$
��Left=�.+��� $ Vertical=�$��
80,20,0,20q�.+��� $��Configuration���� -   $��Configuration��$��80��#���   �� -   $��	StartScan��$��Start��$��80,0,0,0q�#���  $��Center=�$��Center=��� $ Vertical=�$��Right=�$��	50,0,20,0q�.+��� -   $��	ImageData��$��
Image Data��$��10q�#���   $
��Bold"����� $ 0.5,1&�$ 0.5,0&�.��� $ 	LightGray��$ 0Q�� $ White��$ 1Q�.���� $ 
Horizontal=�.+��� .+��� -   $ ScannedImage��$��30,10q�$ DownOnly=�$	��600������ $ GUI Main Sample Image.jpg?��� $ Vertical=�$��0q�.+��� -   $��ImageFullScreen��$��Img1a��$��5q�$
��Left=��� $ 
Horizontal=�.+��� -   $��EnlargeImage��$��Img2a��$��5q��� -   $��ReduceImage��$��Img2b��$��5q��� $ 
Horizontal=�.+��� $��Img3a��$��5q��� $��Img3b��$��5q��� $ 
Horizontal=�.+��� $��Img4a��$��5q��� $��Img4b��$��5q��� $ 
Horizontal=�.+��� $��Img5a��$��5q��� $��Img5b��$��5q��� $ 
Horizontal=�.+��� $��Img6a��$��5q��� $��Img6b��$��5q��� $ 
Horizontal=�.+��� $��Img7a��$��5q��� $��Img7b��$��5q��� $ 
Horizontal=�.+��� $��Img7a��$��5q��� $��Img7b��$��5q��� $ 
Horizontal=�.+��� $��Img7a��$��5q��� $��Img7b��$��5q��� $ 
Horizontal=�.+��� $��Img7a��$��5q��� $��Img7b��$��5q��� $ 
Horizontal=�.+��� $��Img7a��$��5q��� $��Img7b��$��5q��� -   $��
SystemInfo��$��System Information��$��10q�#���   $
��Bold"�$��Bottom=����� $ 0.5,1&�$ 0.5,0&�.��� $ 	LightGray��$ 0Q�� $ White��$ 1Q�.���� $ Vertical=�.+��� $ 
Horizontal=�$��Center=�.+��� $ Vertical=�$
��10,0q�.+��� $
��Door���� -    ��Name$ DoorMessage��$
��Shut��
��� � �$
��Bold"�$��Center=��� $ Vertical=�.+��� $��Camera Temp���� -   $ TempMessage��$��-85 C��
��� � �$
��Bold"�$��Center=��� $ Vertical=�$
��10,0q�.+��� $��Filter Wheel Pos���� -   $ FilterMessage��$��3��
��� � �$
��Bold"�$��Center=��� $ Vertical=�$
��10,0q�.+��� $��System Status���� -   $ SystemMessage��$��Ready��
��� � �$
��Bold"�$��Center=��� .+��� -   $��
StopButton��$��	Shut Down��$��	80,5,10,5q�#���  �� $ 
Horizontal=�.+��� $��Elapsed Time: ���� -   $ TimeElapsedMessage��$��0 minute 0 seconds��
��� � �$
��Bold"�$��Center=�