   M S B A M L   `   `   `  ����E  AWeatherApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WeatherApp.ViewsWeatherApp.Views  5   	   %    WeatherApp.Views.MainWindowView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WeatherApp.Views     5   	   -   5          � Title$  MainWindowView��5      $	��700��6    � WindowStyle$
 None=�6,   $
��1200��6?    � 
ResizeMode$ NoResize=�6b    � WindowStartupLocation$ CenterScreen=�6x   .��5
      � 
��� E�� � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��13* �6   �� 5      $��1* �6   .+�5   
   � $��0��6   $��0��6   $��2��6,   .+�5      �� $��30(�6    �� TextAlignment$ Center=�6&   $��Black"�6=   
���   �
����+��Weather App6�   5      � 5   
   -   5        $��	DailyView��5   ,   $��0��6   $��1��6   5      � 5   
   -   5        $��
WeeklyView��5   -   $��1��6   $��1��6   $��2��6?   5      � 5   
   $��0��6   $��2��6   
��� E��.+�5      �� -   5         ��Name$ btnExit��5   {   $��Center=�6      ButtonRoundedCorner#��[  62   $��Center=�6_   $��64��6�   $��37��6�   .��6�   Exit5      5      5       5!      