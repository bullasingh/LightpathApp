   M S B A M L   `   `   `  ���� G  CLightpathApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:LightpathAppLightpathApp  Q MSpecimenAnalyserDriver, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulleGclr-namespace:LightPath.InstrumentModel;assembly=SpecimenAnalyserDriverLightPath.InstrumentModel     LightpathApp.InternalEi   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:LightpathApp     VsaGclr-namespace:LightPath.InstrumentModel;assembly=SpecimenAnalyserDriver     -   .��� $	��810��$
��1048������   �� ImageSource$%  SimplifiedInstrumentDiagram.png�� j� Stretch$
 None=�.+��� -    ��Name$ TextBlockFanStatus��$
��Left=�$��24��$��	73,84,0,0q�$
��Wrap=�$��	FanStatus��$	��Top=�$��76���� -   $ TextBlockOnBoardTemp��$
��Left=�$��26��$��
292,46,0,0q�$
��Wrap=�$��InternalTemperature��$	��Top=�$	��197���� -   $ TextBlockOffBoardTemp��$
��Left=�$��26��$��
292,77,0,0q�$
��Wrap=�$��ExternalTemperature��$	��Top=�$	��197���� -    ��Name$ CheckBoxRefCamAutoGain��$
��Auto��$
��Left=�$��
532,48,0,0q�$	��Top=��� -   $ CheckBoxRefCamAutoExp��$
��Auto��$
��Left=�$��
532,77,0,0q�$	��Top=��� -    ��Name$ ButtonFanOn��$��Fan On��$
��Left=�$��	69,30,0,0q�$	��Top=�$	��100���� -   $ ButtonFanOff��$��Fan Off��$
��Left=�$��	70,57,0,0q�$	��Top=�$	��100���� $��Gain:��$
��Left=�$��
490,43,0,0q�$	��Top=��� $��	Exposure:��$
��Left=�$��
466,72,0,0q�$	��Top=��� -	    ��Name$ SliderRefCamGain��$
��Left=�$��
586,47,0,0q�$	��Top=�$	��144�� � Maximum$	 100Q��� -
   $ SliderRefCamExposure��$
��Left=�$��
586,74,0,0q�$	��Top=�$	��144��$	 100Q��� -    ��Name$ ComboBoxRefCamAwbMode��$
��Left=�$��474,113,0,0q�$	��Top=�$	��256��.@��� -   $��RefAwbManual��.��Manual�� -   $��RefAwbGreyworld��.��
Grey World�� -   $��RefAwbAdobeRgbD65��.��Temperature - Adobe RGB D65�� -   $��RefAwbCieRgbE��.��Temperature - CIE RGB E�� -   $��RefAwbEciRgbD50��.��Temperature - ECI RGB D50�� -   $��RefAwbSrgbD50��.��Temperature - SRGB D50�� -   $��RefAwbSrgbD65��.��Temperature - SRGB D65�� -   $ SliderRefCamRed��$
��Left=�$��586,150,0,0q�$	��Top=�$	��144���� -   $ SliderRefCamGreen��$
��Left=�$��586,177,0,0q�$	��Top=�$	��144���� -   $ SliderRefCamBlue��$
��Left=�$��586,204,0,0q�$	��Top=�$	��144���� $��	Red Gain:��$
��Left=�$��30��$��515,150,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.5,0.5&��� $��Green Gain:��$
��Left=�$��30��$��503,177,0,0q�$	��Top=�$ 0.5,0.5&��� $��
Blue Gain:��$
��Left=�$��30��$��512,204,0,0q�$	��Top=�$ 0.5,0.5&��� -   $ ButtonFilterPosition1��$��
Position 1��$
��Left=�$��334,294,0,0q�$	��Top=�$��75���� -   $ ButtonFilterPosition2��$��
Position 2��$
��Left=�$��334,321,0,0q�$	��Top=�$��75���� -   $ ButtonFilterPosition3��$��
Position 3��$
��Left=�$��334,348,0,0q�$	��Top=�$��75���� -   $ ButtonFilterPosition4��$��
Position 4��$
��Left=�$��334,375,0,0q�$	��Top=�$��75���� -   	 ��Name$	 LabelFilterPosition��$��Filter wheel position��$
��Left=�$��298,429,0,0q�$	��Top=�$	��162���� -   $ ButtonMirrorEmccd��$��	For Emccd��$
��Left=�$��556,316,0,0q�$	��Top=�$	��100���� -   $ ButtonMirrorReference��$��For Reference��$
��Left=�$��556,343,0,0q�$	��Top=�$	��100���� -   $	 LabelMirrorStatus��$��Mirror position��$
��Left=�$��532,408,0,0q�$	��Top=�$	��156���� $��	Gain Type��$
��Left=�$��
19,225,0,0q�$	��Top=��� -   $ ComboBoxEmccdGainType��$
��Left=�$��
87,229,0,0q�$	��Top=�$	��177��.@��� -   $��EmccdGainEmccd��.��Electron-multiplying CCD�� -    $��EmccdGainConventional��.��Conventional CCD�� $��Pre-Amp��$
��Left=�$��
19,254,0,0q�$	��Top=��� -!   $ ComboBoxEmccdPreAmp��$
��Left=�$��
87,256,0,0q�$	��Top=�$	��177��.@��� -"   $��EmccdPreampGain1��.��Gain 1�� -#   $��EmccdPreampGain2��.��Gain 2�� -$   $��EmccdPreampGain3��.��Gain 3�� $��
EMCCD Gain��$
��Left=�$��
13,285,0,0q�$	��Top=��� -%   $ SliderEmccdGain��$
��Left=�$��
87,289,0,0q�$	��Top=�$	��177��$	 300Q�
 � Minimum$
 1Q��� $��Shutter��$
��Left=�$��
25,312,0,0q�$	��Top=��� -&   $ ComboBoxEmccdShutter��$
��Left=�$��
87,316,0,0q�$	��Top=�$	��177��.@��� -'   $��EmccdShutterAuto��.��Automatic - use caution�� -(   $��EmccdShutterClosed��.��Always closed�� -)   $��EmccdShutterOpen��.��Always open�� -*   $  CheckBoxEmccdStabilisation��$ ��Require stable temperature��$
��Left=�$��
19,399,0,0q�$	��Top=��� -+   $ ButtonEmccdCool��$
��Cool��$
��Left=�$��188,370,0,0q�$	��Top=�$��75���� -,   $ ButtonEmccdWarm��$
��Warm��$
��Left=�$��189,343,0,0q�$	��Top=�$��75���� --    ��Name$ TextboxEmccdTemp��$
��Left=�$��23��$��
99,371,0,0q� �� TextWrapping$
 Wrap=�$��Target Temp��$	��Top=�$��85���� $��Target Temp��$
��Left=�$��
13,369,0,0q�$	��Top=�$��86���� $��Current Temp��$
��Left=�$��
13,341,0,0q�$	��Top=�$��86���� -.   $	 LabelEmccdCurrentTemp��$��Current Temp��$
��Left=�$��
99,343,0,0q�$	��Top=�$��85�����	#FF701F1F�� -/   $ ButtonDoorLock��$
��Lock��$
��Left=�$��969,661,0,0q�$	��Top=�$��65���� -0   $ ButtonDoorUnlock��$��Unlock��$
��Left=�$��969,688,0,0q�$	��Top=�$��65���� -1   $	 LabelDoorIsLocked��$��	isLocked?��$
��Left=�$��973,715,0,0q�$	��Top=�$��65���� -2   $	 LabelDoorLockIsOk��$��isOk?��$
��Left=�$��973,746,0,0q�$	��Top=�$��65���� -3   $ ButtonSerialSet��$	��Set��$
��Left=�$��761,371,0,0q�$	��Top=�$��60���� -4   $ TextBoxSerialNumber��$
��Left=�$��22��$��761,340,0,0q�$
 Wrap=�$��current serial number��$	��Top=�$	��125���� -5   $ ButtonLightsOn��$��	Lights On��$
��Left=�$��796,554,0,0q�$	��Top=�$��75���� -6   $ ButtonLightsOff��$��
Lights Off��$
��Left=�$��796,581,0,0q�$	��Top=�$��75���� -7   $	 LabelLightsStatus��$	��Off��$
��Left=�$��796,608,0,0q�$	��Top=��� $��Horizontal Shift Speed��$
��Left=�$��
19,420,0,0q�$	��Top=��� -8   $ ComboBoxEmccdHss��$
��Left=�$��153,420,0,0q�$	��Top=�$	��112���� $��Vertical Shift Speed��$
��Left=�$��
35,447,0,0q�$	��Top=��� -9   $ ComboBoxEmccdVss��$
��Left=�$��152,447,0,0q�$	��Top=�$	��112��.@��� -:   $��EmccdVss0300Ns��.��0.3 us�� -;   $��EmccdVss0500Ns��.��0.5 us�� -<   $��EmccdVss0900Ns��.��0.9 us�� -=   $��EmccdVss1700Ns��.��1.7 us�� ->   $��EmccdVss3300Ns��.��3.3 us�� $��Vertical Clocking Voltage��$
��Left=�$��	4,470,0,0q�$	��Top=��� -?   $ ComboBoxEmccdVcv��$
��Left=�$��153,474,0,0q�$	��Top=�$	��112��.@��� -@   $��EmccdVcvNormal��.��Normal�� -A   $��EmccdVcvPlus1��.��Plus 1�� -B   $��EmccdVcvPlus2��.��Plus 2�� -C   $��EmccdVcvPlus3��.��Plus 3�� -D   $��EmccdVcvPlus4��.��Plus 4�� -E   $ ButtonEmccdApply��$��Apply Settings��$
��Left=�$��153,779,0,0q�$	��Top=�$��99���� $��Exposure Time (s)��$
��Left=�$��
45,499,0,0q�$	��Top=��� -F   $ TextBoxEmccdExposure��$
��Left=�$��23��$��153,501,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��112���� -G   $ TextBoxEmccdFirstCol��$
��Left=�$��23��$��152,529,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��112���� -H   $ TextBoxEmccdLastCol��$
��Left=�$��23��$��153,557,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��112���� -I   $ TextBoxEmccdFirstRow��$
��Left=�$��23��$��153,585,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��112���� -J   $ TextBoxEmccdLastRow��$
��Left=�$��23��$��153,613,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��112���� $��First column��$
��Left=�$��
77,527,0,0q�$	��Top=��� $��Last column��$
��Left=�$��
74,554,0,0q�$	��Top=��� $��	First row��$
��Left=�$��
93,583,0,0q�$	��Top=��� $��Last row��$
��Left=�$��
94,610,0,0q�$	��Top=��� $��Horizontal Bin Size��$
��Left=�$��
39,637,0,0q�$	��Top=��� -K   $ ComboBoxEmccdHBinSize��$
��Left=�$��153,641,0,0q�$	��Top=�$	��111��.@��� -L    ��Name$ HBin0��$��1���� -M   $ HBin1��$��2���� -N   $ HBin2��$��4���� -O   $ HBin3��$��8���� -P   $ HBin4��$��16���� -Q   $ HBin5��$��32���� -R   $ HBin6��$��64���� -S   $ HBin7��$	��128���� -T   $ HBin8��$	��256���� $��Vertical Bin Size��$
��Left=�$��
54,665,0,0q�$	��Top=��� -U   $ ComboBoxEmccdVBinSize��$
��Left=�$��153,668,0,0q�$	��Top=�$	��111��.@��� -V   $ VBin0��$��1���� -W   $ VBin1��$��2���� -X   $ VBin2��$��4���� -Y   $ VBin3��$��8���� -Z   $ VBin4��$��16���� -[   $ VBin5��$��32���� -\   $ VBin6��$��64���� -]   $ VBin7��$	��128���� -^   $ VBin8��$	��256���� $��Cooling Timeout (s)��$
��Left=�$��
33,693,0,0q�$	��Top=��� -_   $ TextBoxEmccdCoolTimeout��$
��Left=�$��23��$��153,695,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��111���� -`   $ ButtonCancel��$��
Cancel All��$
��Left=�$��
53,116,0,0q�$	��Top=�$	��151��$��56��$��20(��� -a   $ ButtonEmccdLoad��$��Load Settings��$
��Left=�$��
35,779,0,0q�$	��Top=�$	��102���� -b   $ ButtonFilterPositionHome��$
��Home��$
��Left=�$��334,402,0,0q�$	��Top=�$��75���� -c   $ ButtonMirrorHome��$
��Home��$
��Left=�$��556,370,0,0q�$	��Top=�$	��100���� -d   $ ButtonSerialGet��$	��Get��$
��Left=�$��826,371,0,0q�$	��Top=�$��60���� -e   $ TextBoxEmccdKineticTimeS��$
��Left=�$��23��$��153,723,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��110���� -f   $ TextBoxEmccdKineticCount��$
��Left=�$��23��$��153,751,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��111���� $��Kinetic cycle time (s)��$
��Left=�$��
19,721,0,0q�$	��Top=��� $��Kinetic series count��$
��Left=�$��
35,749,0,0q�$	��Top=��� $
��Left=�$	��170��$��
787,29,0,0q�$	��Top=�$	��137��.+��� $��Status��$��0 0 10 0q� � 	Resources )   #LightpathApp.EnumToBooleanConverter   EnumToBooleanConverter��%   &	          .���� .+�	� $��Ready�� 	� 	GroupName$ Status�� d� 	IsChecked ��  �� Path$ 	Indicator� �� 	Converter# [  /  )LightPath.InstrumentModel.IndicatorStatus   
StateReady �� ConverterParameter# Z 	� $��Error��$ Status�� �� $ 	Indicator�# [     
StateError# Z 	� $��Cooling/Warming��$ Status�� �� $ 	Indicator�# [     StateCoolingWarming# Z 	� $��Scanning��$ Status�� �� $ 	Indicator�# [     StateScanning# Z �� $��Door locked�� �� *IndicatorDoorLocked+ �� Mode$ TwoWay=��� $��Specimen detected�� �� * IndicatorSpecimenHolderPresent+$ TwoWay=��� -g   $ CheckBoxHeartbeatAuto��$��Automatic Heartbeat�� �� *AutomaticHeartbeat+�� -h   $ ButtonKickWdt��$��Kick Heartbeat��$	��100���� $
��Left=�$��700,738,0,0q�$	��Top=�$	��250��$��0q�.����  �� Orientation$ 
Horizontal=�.+�   LightpathApp.BinaryOut     Caption$ Specimen��$��0 0 25 0q�   IsSet �� *IsSpecimenPresent+  $ Drawer closed�� �� *IsDrawerClosed+�� $
��Left=�$	��Top=�$��93��$��
945,10,0,0q�.+��� $��Debug LED 1�� �� *OutputDebugLed1+$ TwoWay=��� $��Debug LED 2�� �� *OutputDebugLed2+$ TwoWay=��� $��Debug LED 3�� �� *OutputDebugLed3+$ TwoWay=��� $��Debug LED 4�� �� *OutputDebugLed4+$ TwoWay=��� $��I2C Bus��$	��0 5q�$��0 50 0 0q�.���� .+�  $ OK��   LedColor$ Green�� �� *
IsI2CBusOk+�� -i   $# ButtonResetInstrumentHardware��$��Reset���� $ 
Horizontal=�$��316,527,227,119q�.+��� $��Board 1��.���� $ 
Horizontal=�.+��� -j   $ Board1RSlider��$
��Left=�$	��Top=�$��25�� �� Orientation$ Vertical=�$	��136��$	 255Q� � SmallChange$ 1Q��� -k   $ Board1GSlider��$
��Left=�$	��Top=�$��25��$ Vertical=�$	��136��$	 255Q�$ 1Q��� -l   $ Board1BSlider��$
��Left=�$	��Top=�$��25��$ Vertical=�$	��136��$	 255Q�$ 1Q��� $��Board 2��.���� $ 
Horizontal=�.+��� -m   $ Board2RSlider��$
��Left=�$	��Top=�$��25��$ Vertical=�$	��136��$	 255Q�$ 1Q��� -n   $ Board2GSlider��$
��Left=�$	��Top=�$��25��$ Vertical=�$	��136��$	 255Q�$ 1Q��� -o   $ Board2BSlider��$
��Left=�$	��Top=�$��25��$ Vertical=�$	��136��$	 255Q�$ 1Q��� $��Board 3��.���� $ 
Horizontal=�.+��� -p   $ Board3RSlider��$
��Left=�$	��Top=�$��25��$ Vertical=�$	��136��$	 255Q�$ 1Q��� -q   $ Board3GSlider��$
��Left=�$	��Top=�$��25��$ Vertical=�$	��136��$	 255Q�$ 1Q��� -r   $ Board3BSlider��$
��Left=�$	��Top=�$��25��$ Vertical=�$	��136��$	 255Q�$ 1Q��� $��Board 4��.���� $ 
Horizontal=�.+��� -s   $ Board4RSlider��$
��Left=�$	��Top=�$��25��$ Vertical=�$	��136��$	 255Q�$ 1Q��� -t   $ Board4GSlider��$
��Left=�$	��Top=�$��25��$ Vertical=�$	��136��$	 255Q�$ 1Q��� -u   $ Board4BSlider��$
��Left=�$	��Top=�$��25��$ Vertical=�$	��136��$	 255Q�$ 1Q��� $��Master��.���� -v   $ LedMasterSlider��$��Center=�$	��Top=�$��25��$ Vertical=�$	��136��$	 255Q�$ 1Q�