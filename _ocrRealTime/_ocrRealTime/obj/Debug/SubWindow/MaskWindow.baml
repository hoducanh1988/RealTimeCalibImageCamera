   M S B A M L   `   `   `  ����\  XrealTimeCalibSharpness_Ver1.0.0.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:_ocrRealTime_ocrRealTime  5   	       _ocrRealTime.MaskWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:_ocrRealTime     5   	   -   5          � Title$  
MaskWindow��5   	      customWindow#��[  5	   	    � Topmost .  � ShowActivated .   � ShowInTaskbar .  ��5
   	   ��  �� Path$ windowbackground� �� UpdateSourceTrigger$ PropertyChanged=���5   	   �� $ windowwidth�$ PropertyChanged=���5   	   �� $ windowheight�$ PropertyChanged=� J� Opacity 5   	   �� $ windowopacity�$ PropertyChanged=�.��5      �� .+�5   
   �� -   5         ��Name$ _rect��5      
���  ��$��4��60   
������ $y�	Collapsed=�6W   $	��top=�6n   $
��Left=�6�    J� IsHitTestVisible .  6�   �� 5   
   -   5        	 ��Name$	 
_cropImage��5      
 �� Bottom$
 35��6$    �� Left$ 1��67   $	��200��6G   $	��200��6T   $
��Fill=�6`   �� 5   
   $��22(�6X   $��SemiBold"�6f   
��� � �$
 35��6�    �� Right$ 10��6�   ��6   �� $ 	retrytime�$ PropertyChanged=�6�   �� 5   
   $y�	Collapsed=�6   $��22(�6n   $��SemiBold"�6|   
��� � �
 �� Top$ 30��6�   $ 5��6�   ��6'   �� $ rectInfo�$ PropertyChanged=�6�   5      5"      