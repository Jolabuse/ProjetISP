   M S B A M L   `   `   `  ����D  @ProjetISF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ProjetISF	ProjetISF  5   	       ProjetISF.AllClientWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   )localclr-namespace:ProjetISF     5   	     � Title$  AllClientWindow��5   	   $	��450��6!   $	��800��6.   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��Users��5
   %   $��0,30,0,0q�6      AutoGenerateColumns$ False��62      CanUserAddRows$ false��6N      
IsReadOnly$
 true��6e      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *name+  5      $ 	firstname��6%    68   �� *	firstname+  5      $ currency��6%    67   �� *
currency+  5      $ id��6%    61   �� *guid+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Delete��6)      CellTemplate 5      �� 5      .R�5      �� $��btnView��6%   -   5        $	��Del��5   4   6B   5      5        5      $ 
Change Pin��6)    5      �� 5      .R�5      �� $��btnView��6%   -   5        $��Change��5   4   6E   5      5        5      $ 
GO to page��6)    5      �� 5       .R�5!      �� $��btnView��6%   -   5        $��GO��5!   4   6A   5"      5$      5&      �� 5'   
   -   5         ��Name$ textBox1��5'      $��22��6$   $	��Top=�60   6H   � 5)   
   -   5        $��Popup1��5)   $   $��
10,10,0,13q�6   $
��Left=�62   $	��Top=�5*      $	��194��6(   $	��200��64   $��False��6A   .��5,      �� .+�5-      �� -   5        $	��Box��5-      �� 5.      -   5        $��
Change Pin��5.      6/   5/      50      51      52      