   M S B A M L   `   `   `  ����D  @ProjetISF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ProjetISF	ProjetISF  5   	        ProjetISF.addCllientWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   )localclr-namespace:ProjetISF     5   	   -   5          � Title$  addCllientWindow��5   	   $	��480��6"   $	��380��6/    � AllowsTransparency$
 True��5	   	   
������  � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   ��  �� CornerRadius$ 10��6   $��2��6#   ��5      �� 5      .��5      �  � Color$ 	LightGray��6#    � Offset$	 0.0Q�65   � 5      $
 Gray��6#   $ 1Q�60   5      5      �� 5   
   $��Center=�6   .+�5      �� -   5        $
��test��5      $��ADD USER��5      $��Light"�5      $��	helvetica)�5      $��22(�5      
�������$��Center=�5       5!      �� 5"   
   $��1��6    �� Orientation$ Vertical=�6"   $��10,-70,0,10q�69   .+�5#      �� $
��Name��6   $��22(�6&   �� 5$      -   5        $
��name��5$      $	��355��6#   $��22(�6/   �� 5%      $��	Firstname��6   $��22(�6+   �� 5&      -   5        $��	firstname��5&      $	��355��6'   $��22(�64   �� 5'      $	��Pin��6   $��22(�6%   �� 5(      -   5        $	��pin��5(      $	��355��6!   $��22(�6-   �� 5*      -   5        $��currency��5*      $��50��6'   $��Center=�62   .@�5+      �� .��6   EUR6$   �� 5,      	 �� 
IsSelected$
	 True��6   .��61   USD66   �� 5-      .��6   JPY6$   5.      �� 5/      -   5        $��0,10,0,0q�5/         specificButton#��[  6(   $	��100��6k   $��40��6w   $��
Add Client��6�   
 � Cursor$

 Hand��6�   �� 50      -   5        #��[  50      $��0,5,0,0q�6=   $	��100��6O   $��40��6[   $
��Quit��6g   $

 Hand��6v   6�   52      54      55      