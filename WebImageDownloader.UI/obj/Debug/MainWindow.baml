   M S B A M L   `   `   `  ����O  KWebsiteImageDownload, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:WebsiteImageDownload.ViewModelsWebsiteImageDownload.ViewModels  5   	   %    WebsiteImageDownload.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   D
viewModels-clr-namespace:WebsiteImageDownload.ViewModels     5   	     � Title$  
MainWindow��5   	      WindowStyle#��[  5   	    � DataContext 5      9   3WebsiteImageDownload.ViewModels.MainWindowViewModel  5	   
    � 	Resources 5       �� Source�� 5   
   $ Styles/MainViewStyle.xaml?�6   %    .��5      ]� $	��Top=�6   ��.   TopmostPanel#��[ 6=   .+�5   
   � $	��Top=�6   $��20��6$    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      �� 5      $
��Auto �6#   .+�5      �� $��0��6     GridElement#��[ 6(   Add Website:6[   �� 5      $��1��6   #��[ 6&   ��6K   �� *Url+�� 5      $��2��6   #��[ 6%   ��6J   �� *AddWebsiteCommand+.��6p   Add6u   5      � 5   
   $��Bottom=�6   $��Stretch=�6.   6N   � 5   
   $
��Left=�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      �� 5       .+�5"      �� $��0��6   #��[ 6%   Downloaders:6X   �� 5#      -   5        $��Websites��5#      $��1��6'     WebsiteListStyle#��[ 64   ��6^   �� *
Websites+�� 5$      $��2��6    �� Orientation$ 
Horizontal=�6&   $��Center=�6?   .+�5%      �� #��[ 6   .��6>   Page Settings6M   �� 5&      #��[ 6   ��6>   �� *DownloadCommand+��6b   ��  �� ElementName$ Websites�� �� Path$ SelectedItem�.��6�   
Download6�   �� 5'      #��[ 6   .��6>   
Remove All6J   5(      5)      � 5*   
   $��Right=�6   $
��Auto��6&    5+      �� 5,      $
��Auto �6    �� 5-      .+�5/      �� $��0��6   #��[ 6%   Recent Images:6Z   �� 50      $��1��6   6&   51      52      53      