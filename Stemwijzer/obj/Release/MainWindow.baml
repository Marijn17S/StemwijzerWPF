   M S B A M L   `   `   `  ���� E  AStemwijzer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Stemwijzer
Stemwijzer      Stemwijzer.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:Stemwijzer       � Title$  F1DB WPF��$	��500��$	��950��.��� ����  j� Stretch$ UniformToFill=� �� ImageSource$ Resources/background.jpg��.+��  � RowDefinitions �� $��15��$��32��$��* ��� $��2* ��� $��2* ��� $��2* ��� $��2* ��� $��50��$��* � � ColumnDefinitions �� $
��0.1* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $
��0.1* �.+�	� -    d� 	IsChecked$
 TrueY�$��2��$��0�� 	� 	GroupName$ TabelSwitch��$��Center=�$��Center=�$��Partijen��
���   �$
��Bold"�	� -   $��3��$��0��$��Center=�$��Center=�$ TabelSwitch��$��Verkiezingen��
���   �$
��Bold"�	� $��4��$��0��$��Center=�$��Center=�$ TabelSwitch��$��Standpunten��
���   �$
��Bold"�&   System.Windows.Controls.DataGrid  -   $��	F1Drivers��$��13(�   AutoGenerateColumns .  $��1��$��5��$��1��$��4��$��0,0,0,5q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   
IsReadOnly	 . 
   Header$
 	Driver ID��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 3.1* 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	driver_id+  $
 Driver name��$ 8*  �� *name+  $	
 Car��$
 1.5*  �� *
car_number+  $
 Team ID��$
 2.9*  �� *	team_id+  	 . $

 Team��$ 9*  �� *
teamname+  	 . $
 Teammate��$
 6.2*  �� *tmname+  	 . $
 Teammate ID��$ 4*  �� *teammate_id+  $	
 Car��$
 1.5*  �� *teammate_carnumber+  -   $��F1Teams��$y�Hidden=�$��12(� .  $��1��$��6��$��1��$��4��$��0,0,0,5q�   	 . $
 Team ID��$ 3.35*  �� *	team_id+  $
 	Team Name��$ 8*  �� *
teamname+  $
 	Engine ID��$ 4*  �� *	engine_id+  	 . $
 Engine Manufacturer��$ 9*  �� *engine+  $
 Main Sponsor��$ 7*  �� *main_sponsor+�� -   $��btn_DriverAdd��$��2��$��5��$��4q�$
��10.6(�$��	Toevoegen���� -    ��Name$ updateButton��$��3��$��5��$��	Bijwerken��$��4q��� -   $��deleteButton��$��4��$��5��$��Verwijderen��$��4q�