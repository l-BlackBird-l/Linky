   M S B A M L   `   `   `  ����I  ECryptoCurrency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CryptoCurrencyCryptoCurrency  5   	   C&clr-namespace:CryptoCurrency.ViewModelCryptoCurrency.ViewModel  5   	   ;"clr-namespace:CryptoCurrency.PagesCryptoCurrency.Pages  5   	   C&clr-namespace:CryptoCurrency.UtilitiesCryptoCurrency.Utilities  5   	       CryptoCurrency.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:CryptoCurrency     5   	   5vm&clr-namespace:CryptoCurrency.ViewModel     5   	   1uc"clr-namespace:CryptoCurrency.Pages     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5
   	   3Menu&clr-namespace:CryptoCurrency.Utilities   5   	     � Title$  
MainWindow��5   	   $	��520��6   $
��1020��6)    � WindowStartupLocation$ CenterScreen=�66    � 
ResizeMode$ NoResize=�6[    � WindowStyle$
 None=�6q   
������  � AllowsTransparency$
 True��6�    � DataContext 5      )  #CryptoCurrency.ViewModel.Navigation  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��7* �6   �� 5      $��8* �6   �� 5      $	��50* �6    � ColumnDefinitions 5   
   �� 5      $	��37* �6   �� 5      $
��157* �6   �� 5      $	��61* �6   .+�5   
   ��  �� CornerRadius$ 25��6      Backgrounds#���   6#   $��3��6N   $��3��6b   �� 5   
     Card#���  6   $ 	25 0 0 25��65   $��3��6N   �� 5   
   $��0��6   $��/ProgramLogo.png��6    $��35��6;   $
��Left=�6F   $��Center=�6a   $��10,0,0,0q�6|   $��36��6�   �� 5   
   $��Linky��6     Text#���  6    $
��Left=�6E   $��Center=�6`   $��24(�6{   $��Comic Sans MS)�6�   $��50,0,0,0q�6�   �� 5    
   $��3��6   $��Bottom=�6(    	 Separ#���  6C   $��0,0,0,2q�6h   $��1��6y   �� 5"   
   $��0��6   $��2��6%   	 �� Orientation$	 Vertical=�62   .+�5#      "   CryptoCurrency.Utilities.Btn  -   5        
  Name$
 
CoinButton��5#        BtnStyle#��[ 6+    d� 	IsChecked$
 TrueY�6N   ��6_   �� *CoinsCommand+.��5$      � .+�5%      �� $
��Coin��6      
Text_Style#��[ 6,   #���  6P   .  (MahApps.Metro.IconPacks.PackIconMaterial  5&         Kind$ Bitcoin=�6,     
Icon_Style#��[ 6<   #���  6`   5'      5(        5*      -   5        $
 SearchButton��5*      #��[ 6-   ��6O   �� *SearchCommand+.��5+      � .+�5,      �� $��Search��6    #��[ 6.   #���  6R     5-      $ ShieldSearch=�6,   #��[ 6A   #���  6e   5.      5/        51      -   5        $
 ConvertButton��51      #��[ 6.   ��6P   �� *ConvertCommand+.��52      � .+�53      �� $��Convert��6    #��[ 6/   #���  6S     54      $ AccountConvert=�6,   #��[ 6C   #���  6g   55      56        58      -   5        $
 FavoriteButton��58      #��[ 6/   ��6Q   �� *FavoritesCommand+.��59      � .+�5:      �� $��	Favorites��6    #��[ 61   #���  6U     5;      $ Heart=�6,   #��[ 6:   #���  6^   5<      5=      5>      �� 5?   
   $��1��6   $��1��6&   $��2��66   ��6G   �� *CurrentView+5A      � 5C   
   $��1��6   $��2��6   $��2��6-   .+�5D      .   (CryptoCurrency.Pages.TopCryptoCurrencies  5E      �� 5G   
   $ 24��6   $��0��6#   $��2��60   $��
0,10,10,10q�6A   $��Right=�6U   ._�5H      � .+�5J      �� -   5         ��Name$ ButtonClose��5J   N     	topButton#��[ 6   $��0 0 0 0q�6<    � Cursor$
 Hand��6s   .��5K        $ Close=�6,   $	��Top=�69   $��13��6Q   5L      �� 5N      -   5        $ 	ButtonMin��5N   O   #��[ 6   $��0 0 35 0q�6<   $
 Hand��6b   .��5O        $ CollapseAll=�6,   $	��Top=�6?   $��13��6W   5P      5Q      5R      �� 5T   
   $ 24��6   $��0��6#   $��2��60   $��20,10,10,10q�6A   $
��Left=�6V   ._�5U      � .+�5W      �� -   5        #��[ 5W      $��0 0 0 0q�6<   $
 Hand��6N   .��5X        -   5          Name$ ChangeTheme��5X   c   $ WeatherNight=�6,   $	��Top=�6@   $��13��6X   6c   5Y      5Z      5[      �� 5]   
   -	   5        $��2��5]      $��1��6(   
������ $��
140,0,0,20q�6L   $
 Hand��6`   6n   5^      5`      