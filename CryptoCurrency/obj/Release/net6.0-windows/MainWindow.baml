   M S B A M L   `   `   `  ���� I  ECryptoCurrency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CryptoCurrencyCryptoCurrency  C&clr-namespace:CryptoCurrency.ViewModelCryptoCurrency.ViewModel  ;"clr-namespace:CryptoCurrency.PagesCryptoCurrency.Pages  C&clr-namespace:CryptoCurrency.UtilitiesCryptoCurrency.Utilities      CryptoCurrency.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:CryptoCurrency     5vm&clr-namespace:CryptoCurrency.ViewModel     1uc"clr-namespace:CryptoCurrency.Pages     c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   3Menu&clr-namespace:CryptoCurrency.Utilities     � Title$  
MainWindow��$	��520��$
��1020�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=�
������  � AllowsTransparency$
 True�� � DataContext )  #CryptoCurrency.ViewModel.Navigation  .���  � RowDefinitions �� $��7* ��� $��8* ��� $	��50* � � ColumnDefinitions �� $	��37* ��� $
��157* ��� $	��61* �.+���  �� CornerRadius$ 25��   Backgrounds#���   $��3��$��3����   Card#���  $ 	25 0 0 25��$��3���� $��0��$��/ProgramLogo.png��$��35��$
��Left=�$��Center=�$��10,0,0,0q�$��36���� $��Linky��  Text#���  $
��Left=�$��Center=�$��24(�$��Comic Sans MS)�$��50,0,0,0q��� $��3��$��Bottom=� 	 Separ#���  $��0,0,0,2q�$��1���� $��0��$��2��	 �� Orientation$	 Vertical=�.+�"   CryptoCurrency.Utilities.Btn  -   
  Name$
 
CoinButton��  BtnStyle#��[  d� 	IsChecked$
 TrueY����� *CoinsCommand+.��� .+��� $
��Coin��  
Text_Style#��[ #���  .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ Bitcoin=�  
Icon_Style#��[ #���    -   $
 SearchButton��#��[ ���� *SearchCommand+.��� .+��� $��Search��#��[ #���    $ ShieldSearch=�#��[ #���    -   $
 ConvertButton��#��[ ���� *ConvertCommand+.��� .+��� $��Convert��#��[ #���    $ AccountConvert=�#��[ #���    -   $
 FavoriteButton��#��[ ���� *FavoritesCommand+.��� .+��� $��	Favorites��#��[ #���    $ Heart=�#��[ #���  �� $��1��$��1��$��2������ *CurrentView+� $��1��$��2��$��2��.+�.   (CryptoCurrency.Pages.TopCryptoCurrencies  �� $ 24��$��0��$��2��$��
0,10,10,10q�$��Right=�._�� .+��� -    ��Name$ ButtonClose��  	topButton#��[ $��0 0 0 0q� � Cursor$
 Hand��.��  $ Close=�$	��Top=�$��13���� -   $ 	ButtonMin��#��[ $��0 0 35 0q�$
 Hand��.��  $ CollapseAll=�$	��Top=�$��13���� $ 24��$��0��$��2��$��20,10,10,10q�$
��Left=�._�� .+��� -   #��[ $��0 0 0 0q�$
 Hand��.��  -     Name$ ChangeTheme��$ WeatherNight=�$	��Top=�$��13���� -	   $��2��$��1��
������ $��
140,0,0,20q�$
 Hand��