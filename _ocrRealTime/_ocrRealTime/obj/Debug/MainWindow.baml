   M S B A M L   `   `   `  ����\  XrealTimeCalibSharpness_Ver1.0.0.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:_ocrRealTime_ocrRealTime  5   	   ?$clr-namespace:_ocrRealTime.ucControl_ocrRealTime.ucControl  5   	       _ocrRealTime.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:_ocrRealTime     5   	   9userctrl$clr-namespace:_ocrRealTime.ucControl     5   	   -   5          � Title$  
MainWindow��5	   	   $	��650��6   $	��850��6,    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      ��    colorBackground#��[  6    �� CornerRadius$ 5,5,5,5��6;     colorBorder#��[ 6R   $��1q�6}   ._�5   
   �  � RowDefinitions 5      �� 5      $��40 �6    �� 5      $��50 �6    �� 5      $��40 �6    �� 5      $��* �6    �� 5      $��20 �6    .+�5      � $��0��6   $��5,0,0,0q�6    .+�5       � $
��Left=�6   .+�5"      �� $��Center=�6   
���   �$�� Version 1.0.0.0��6J   6g   �� 5#      $��Center=�6   
���   �$�� Build date 08/11/2018��6J   6m   �� 5$      $��Center=�6   
���   �$(��" Copyright of VNPT Technology 2018��6J   6y   5%      � 5&      $��Center=�6   $��Right=�67   .+�5'      �� -   5         ��Name$ lblMin��5'      $��10,0,0,0q�6I   $��30��6[   $��Center=�6f   
���   �$��20(�6�   $
��Bold"�6�    ^� ToolTip$ Minimize��6�   $��0,-5,0,0q�6�   .��5(      �� -   5         ��Name$ bdMin��5(   !   $��0,13,0,0q�6M   $��Center=�6_   $��Center=�6z   
���   �$��2q�6�   $��10��6�   5)      5*      �� 5+      -   5        $��20(�5+   8   $��30��6F   $
��Bold"�6Q   $��0,-5,5,0q�6c   
���   �$ Close Application��6�   $��X��6�   6�   5,      5-      � 50      $��4,25,1,0q�6   $��2��6%   .+�52      o� $
��Auto��6   $
��Left=�6$   #��[  6?   .@�54      m� $
��File��6   $
��Bold"�6-   .@�55      m� -   5        $��Open log��55   #   65   �� 56      m� 57      -   5        $
��Exit��57   #   61   58      m� 5:      $
��Edit��6   $
��Bold"�6-   .@�5;      m� -   5        	 m�Name$	 _miDraw��5;   #   $��Draw Testing Area��64   6O   m� 5<      -   5        $	 _miSave��5<   #   $��	Save Area��64   {�.  6Y   �� 5=      m� 5>      -	   5        $	 _miCal��5>   #   $��Calculate Standard��63   6O   5?      5@      5B      � 5E      -
   5        $��2��5E      $��	5,-25,0,0q�6    .+�5F      �� $6��0Tool Support Calibration The Sharpness Of Camera��6   $��SemiBold"�6S   $��26(�6i   5G      � 5J      $��3��6   $��	0,-10,0,0q�6     5K      �� 5L      $��35 �6$   �� 5M      $��* �6$   .+�5Q      � $��0��6   $��5,0,0,0q�6$    5R      �� 5S      $��27 �6(   �� 5T      $��4 �6(   .+�5V      � $��0��6   .+�5W      � $��0,-2,0,0q�6$   .+�5X      �� -   5        $	��110��5X   @   $��Center=�6L   $��Center=�6n   $��15(�6�   $��SemiBold"�6�   .��6�   LIVE STREAM6�   �� 5Y      -   5        $	��110��5Y   @   $��Center=�6L   $��Center=�6n   $��15(�6�   $��SemiBold"�6�   .��6�   	SETTING6�   �� 5Z      -   5        $��60��5Z   @   $��Center=�6K   $��Center=�6m   $��15(�6�   $��SemiBold"�6�   .��6�   HELP6�   �� 5[      -   5        $	��100��5[   @   $��Center=�6L   $��Center=�6n   $��15(�6�   $��SemiBold"�6�   .��6�   ABOUT6�   5\      5]      �� 5^      -   5        $ lblMinus��5^      $��1��6.   $��Stretch=�6;   $	��100��6W   $
��Left=�6c   ���#2fef486�   5_      � 5b      $��1��6   $��5,5,5,5q�6$   .+�5c      $   _ocrRealTime.ucControl.ucAbout  -   5        
  Name$
 ucAbout��5c   '   #   _ocrRealTime.ucControl.ucHelp  5d      -   5          Name$ ucHelp��5d   &   &    _ocrRealTime.ucControl.ucSetting  5e      -   5          Name$ 	ucSetting��5e   )   )   #_ocrRealTime.ucControl.ucLiveStream  5f      -   5          Name$ ucLiveStream��5f   ,   5g      5i      � 5m      $��4��6   .+�5n      �� -   5         ��Name$ _urlTextBox��5n      $��Center=�6s   ��6/   ��  �� Path$ rtsppath� �� UpdateSourceTrigger$ PropertyChanged=�.��6�   ��5o      �� 5p       �� 
TargetType" ��6    .�5q      ��  �� Property � �� �� Value
 �  ��6;    �� Triggers 5r      �� 5s   "    �� Binding 6.   �� $ CameraIsOnline� �� Value True6V   .a�5t   &   ��  � ��
 � � �6C   5u   #   5w      .��5x   %   5y      5z      5{      5      5�      