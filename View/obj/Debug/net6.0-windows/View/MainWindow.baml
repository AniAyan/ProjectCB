   M S B A M L   `   `   `  ����?  ;View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:View.ViewModelsView.ViewModels  5   	       View.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4
viewModelsclr-namespace:View.ViewModels     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��customerGrid��5      $��0��5         AutoGenerateColumns$ False��5         CanUserAddRows$ False��5         SelectionMode$ Single=�5         
IsReadOnly$
 True��5      ��5      �� *	Customers+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	FirstName��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *	FirstName+  5      $ LastName��6%    67   �� *
LastName+  5      $ Address��6%    66   �� *	Address+  5      $ Region��6%    65   �� *Region+5        5   
   -   5        $��applicationGrid��5      $��1��5      $ False��5!      $ False��5"      $ Single=�5#      $
 True��5$      ��5       �� *SelectedCustomerApplications+ 5%        5&      $ Branch��6%    65   �� *Branch+	   	CellStyle	 5'      �� 5(      
 �� 
TargetType*  $System.Windows.Controls.DataGridCell"
  6    .�5)      -   5        5*      5,        5-      $ 
CustomerId��6%    69   �� *
CustomerId+  5.      $
 Type��6%    63   �� *Type+  5/      $ Amount��6%    65   �� *Amount+  50      $
 Rate��6%    63   �� *Rate+  51      $
 Date��6%    63   �� *Date+53      54      55      