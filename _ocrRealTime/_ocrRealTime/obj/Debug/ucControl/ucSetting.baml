   M S B A M L   `   `   `  ����\  XrealTimeCalibSharpness_Ver1.0.0.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:_ocrRealTime.ucControl_ocrRealTime.ucControl  5      &     _ocrRealTime.ucControl.ucSetting   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:_ocrRealTime.ucControl     5      .��5
      �� 
���   �$	��0.5q�6!     �� CornerRadius$  5��67      colorBackground#��[  6H   ._�5   
   �  � RowDefinitions 5      �� 5      $��* �6    �� 5      $��55 �6    .+�5      �� $��0��6   $��5,5,5,5q�6(   .��5      �� $��0,0,5,0q�6   .+�5      � $	��230��6   .+�5      �� $��0��6%   .+�5      ��   colorBorder#��[ 6$   $��14(�6N   $
��Bold"�6\   $��SETUP CAMERA INFO:��6n   6�   �� 5      $��IP Address Of Camera:��6$   $��13(�6D   6T   �� 5      $��27��6&   
�������$
��Bold"�6E   $��13(�6W   $��5,0,0,0q�6e   ��5   &   ��  �� Path$ cameraip� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� 5      $��Telnet User:��6$   $��13(�6;   6K   �� 5      $��27��6&   
�������$
��Bold"�6E   $��13(�6W   $��5,0,0,0q�6e   ��5   &   �� $ 
telnetuser�$ PropertyChanged=�$ TwoWay=��� 5!      $��Telnet Password:��6$   $��13(�6?   6O   �� 5"      $��27��6&   
�������$
��Bold"�6E   $��13(�6W   $��5,0,0,0q�6e   ��5#   &   �� $ 
telnetpass�$ PropertyChanged=�$ TwoWay=�5%      5&      �� 5)      $��15(�6   $
��Bold"�6*   $��-��6<   6J   � 5,      $	��120��6   .+�5-      �� $��0��6%   .+�5.      �� #��[ 6$   $��14(�6N   $
��Bold"�6\   $��SETUP LIVE STREAM:��6n   6�   �� 54      $!��RTSP path stream of Camera:��6$   $��13(�6J   6Z   �� 55      $��27��6&   {�.  
�������$
��Bold"�6W   $��13(�6i   $��5,0,0,0q�6w   ��56   &   �� $ rtsppath�$ PropertyChanged=�$ TwoWay=�58      59      �� 5<      $��15(�6   $
��Bold"�6*   $��-��6<   6J   � 5?      $	��200��6   .+�5A      �� $��0��6%   .+�5B      �� #��[ 6$   $��14(�6N   $
��Bold"�6\   $��SETUP TEST CAMERA LENS:��6n   6�   �� 5D      $��Standard Value:��6$   $��13(�6>   6N   �� 5E      $��27��6&   
�������$
��Bold"�6E   $��13(�6W   $��5,0,0,0q�6e   ��5F   &   �� $ standardvalue�$ PropertyChanged=�$ TwoWay=��� 5G      $��Tolerance Value:��6$   $��13(�6?   6O   �� 5H      $��27��6&   
�������$
��Bold"�6E   $��13(�6W   $��5,0,0,0q�6e   ��5I   &   �� $ 	tolerance�$ PropertyChanged=�$ TwoWay=�5J      5L      5O      5P      �� 5R      -   5        $��5,0,5,5q�5R      $��1��6;   $��50��6H   $��SAVE SETTING��6T   ���#cc821c
�������$��22(�6�   5S      5T      5V      