   M S B A M L   `   `   `  ����I  ECryptoCurrency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:CryptoCurrency.PagesCryptoCurrency.Pages  5      C&clr-namespace:CryptoCurrency.ViewModelCryptoCurrency.ViewModel  5      2    ,CryptoCurrency.Pages.TopCryptocurrenciesItem   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:CryptoCurrency.Pages     5      5vm&clr-namespace:CryptoCurrency.ViewModel     5      $��5q�5	   6     � DataContext  5
      4   .CryptoCurrency.ViewModel.TopCryptocurrenciesVM  5   
   .��5      � 
������  � Cursor$
 Hand��6$    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��3* �6    � ColumnDefinitions 5   
   �� 5      $	��29* �6   �� 5      $	��62* �6   �� 5      $	��26* �6   .+�5   
   �� -   5         ��Name$ 
CryptImage��5      $��0��6%   $��2��65   $��5q�6F   �� 5   
   -   5         ��Name$ 	CryptName��5      $��1��6$   $��0q�64   $��Center=�6@      Text#���   6[   $��16(�6   �� 5   
   -   5        $ 	CryptCost��5      $��2��6$   $��0q�64   $��Center=�6@   #���   6\   $��16(�6�   �� 5   
   -   5        $ Crypt24h��5      $��1��6#   $��1��63   $��0q�6A   $��Bottom=�6M   $��0 0 0 5q�6h   $��12(�6y   
�������6�   5      5      