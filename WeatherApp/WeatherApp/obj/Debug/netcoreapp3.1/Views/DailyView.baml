   M S B A M L   `   `   `  ����E  AWeatherApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WeatherApp.ViewsWeatherApp.Views  5           WeatherApp.Views.DailyView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:WeatherApp.Views     5      .��5	      � 
���`���  � RowDefinitions  5
   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��7* �6   .+�5   
   � $��0��6   .+�5      �� $��DemiBold"�6   $��28(�6.    �� TextAlignment$ Center=�6<   $��Actual Weather��6S   $��Center=�6i   $��Center=�6�   5      � 5   
   $��1��6   .+�5      �� $��24(�6   $ Center=�6&   $��City:��6=   $
��Left=�6J   $��Center=�6e   $��10,0,0,0q�6�   �� 5      $��24(�6   $
 Left=�6'   $��Center=�6_   $��70,0,0,0q�6z   ��6<   �� *WeatherModel.Name+6z   5      � 5   
   $��2��6   .+�5      �� 
���`�����5      �� *WeatherDict+��5      �� 5      .R�5      �� .+�5      �� 
���   �$��1q�69   ._�5    "   �� $	��270��6-   $��24(�6:   $ Center=�6H   $��Center=�6t   ��6_   �� *Key+6t   5!      �� 5"      
���   �$��1q�69   $��3q�6M   ._�5#   "   �� $	��270��6,   $��22(�69   $ Center=�6G   $��Center=�6u   ��6^   �� *Value+6u   5$      5%      5&      5(      5)      5*      5+      