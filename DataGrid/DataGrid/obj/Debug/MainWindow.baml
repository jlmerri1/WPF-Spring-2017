   M S B A M L   `   `   `  ����C  ?DataGrid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:DataGridDataGrid  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       DataGrid.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:DataGrid     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$  
MainWindow��5	   	   $	��350��6   $	��525��6)   .��5
      � .+�5   
   #clr-namespace:DataGridDataGrid  5      1&clr-namespace:System;assembly=mscorlibSystem 5      &   System.Windows.Controls.DataGrid  5   
   (localclr-namespace:DataGrid     5      6sys&clr-namespace:System;assembly=mscorlib     5         
IsReadOnly .  � 	Resources 5   
      
genderEnum S� 
MethodName S� 
ObjectType  System.Enum S� MethodParameters M� Type   DataGrid.Gender��%i   &	        S� 5      $ 	GetValues��68   "  5   %    5      M� 5      "  6!   5      5         Columns 5   
   0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
First Name��6!   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 65   �� *	FirstName+  5      $ 	Last Name��6!   	 64   �� *
LastName+5  /System.Windows.Controls.DataGridHyperlinkColumn  5      $ Website��6&   	 67   �� *	Website+4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ Billionaire��6%   	 6:   �� *IsBillionaire+4	  .System.Windows.Controls.DataGridComboBoxColumn	  5      $ Gender��6%   
 	  SelectedItemBinding
 65   �� *Gender+ 	  ItemsSource 5   )   ��  �� Source# [  .@�5#      
  DataGrid.Record
   
  	FirstName$
 Bill��6    
  LastName$ Gates��6,    
  Website$ http://www.billgates.com?�5$       
  IsBillionaire .   
  Gender$
 Male=�5&      
  5'      $ Jason��6   $ Merrill��6-   $ howdyjason.com?�5(       . $
 Male=�5*      5+      5,      5-      