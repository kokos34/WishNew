   M S B A M L   `   `   `  ����E  AWishNewApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WishNewApp
WishNewApp  5   	       WishNewApp.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WishNewApp     5   	   -   5          �Name$  WishNew1��5   	    � Title$ WishNew��5   	   $	��350��6   $	��525��6&   .��5	      � ��5
   
   �� 5       �� ImageSource$/ )C:\\Users\\epiokok\\Desktop\\elephant.jpg��6    � ColumnDefinitions 5   
   �� 5      -   5         ��Name$ WishNew��5      $
��116* �60   �� 5      $	��44* �6   �� 5      $
��357* �6   .+�5   
   �� -   5        $��Get current data��5      $
��Left=�6,   $��
36,273,0,0q�6G   $	��Top=�6[   $	��138��6s   $��3��5   (   &   System.Windows.Controls.DataGrid  5   
   -   5        $��ProdSOAP��5   j   $��Stretch=�6   $	��240��61   $��
18,18,11,0q�6>   $	��Top=�6R   $��3��6z      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�      SelectionMode$ Single=�6�      GridLinesVisibility$
 None=�6�    J� Opacity$
 0.75Q�6�   ��5      �� 5      	 �� Color$	 White��6"   
 �� Opacity$

 0.75Q�60   6A   5      �� 5   
   -   5         ��Name$ addProductButton��5      $��Add new product��6+   $
��Left=�6E   $��
48,273,0,0q�6`   $	��Top=�6t   $	��121��6�   $��2��6�   �� 5   
   -   5        $ Deleteelements��5      $��Delete element��6)   $��2��6B   $
��Left=�6R   $��209,273,0,0q�6m   $	��Top=�6�   $	��122��6�   6�   5      5      