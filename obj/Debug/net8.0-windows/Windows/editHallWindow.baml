   M S B A M L   `   `   `  ����I  ECinemaSchedule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CinemaSchedule.WindowsCinemaSchedule.Windows  5   	   +    %CinemaSchedule.Windows.editHallWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:CinemaSchedule.Windows     5   	     � Title$!  Изменение зала��5   	   $	��450��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�69   .��5	      � .+�5
   
   �� $!��Изменение зала��6   $��Center=�6)   $��0,10,0,0q�6F   $	��Top=�6X   $��20(�6p   �� 5   
   $��Название зала��6   $
��Left=�6(   $��	60,55,0,0q�6C   $	��Top=�6V   $��16(�6n   �� 5   
   -   5         ��Name$ hallName��5      $
��Left=�6$   $��	60,86,0,0q�6?    �� TextWrapping$
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��340��6�    �� 	MaxLength$ 64��6�   $��24��6�    �� 
AcceptsTab$
 True��6�    �� AcceptsReturn$
 True��6�   �� 5   
   $��Описание зала��6   $
��Left=�6(   $��
60,110,0,0q�6C   $	��Top=�6W   $��16(�6o   �� 5   
   -   5        $ hallDescription��5      $
��Left=�6+   $��
60,146,0,0q�6F   $
 Wrap=�6Z   $�� ��6n   $	��Top=�6v   $	��340��6�   $ 64��6�   $	��238��6�   $
 True��6�   $
 True��6�   �� 5   
   -   5         �� 	IsDefault$
 True��5      $��Добавить��6"   $
��Left=�65   $��516,265,0,0q�6P   $	��Top=�6e   $	��199��6}   $��45��6�   ���	#FFBFF99C6�   �� 5   
    �� IsCancel$
 True��6   $��Отмена��6!   $
��Left=�62   $��516,339,0,0q�6M   $	��Top=�6b   $	��199��6z   $��45��6�   ���	#FFD4D4D46�   5      5      