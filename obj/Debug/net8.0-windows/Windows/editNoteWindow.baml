   M S B A M L   `   `   `  ����I  ECinemaSchedule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CinemaSchedule.WindowsCinemaSchedule.Windows  5   	   +    %CinemaSchedule.Windows.editNoteWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:CinemaSchedule.Windows     5   	   -   5          � Title$'  !Изменение заметки��5   	   $	��450��6#   $	��800��60    � WindowStartupLocation$ CenterScreen=�6<   .��5
      � .+�5   
   �� $0��*Создание новой заметки��6   $��Center=�61   $��0,10,0,0q�6N   $	��Top=�6`   $��20(�6x   �� 5   
   $#��Контент заметки��6   $
��Left=�6*   $��	60,45,0,0q�6E   $	��Top=�6X   $��16(�6p   �� 5   
   -   5         ��Name$ noteNameTextBox��5      $
��Left=�6+   $��	60,80,0,0q�6F    �� TextWrapping$
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $	��440��6�    �� 	MaxLength$
 1000��6�   $	��320��6�    �� 
AcceptsTab$
 True��6�    �� AcceptsReturn$
 True��6�   .��6�   5      �� 5      -   5         �� 	IsDefault$
 True��5      $��Добавить��6&   $
��Left=�69   $��516,265,0,0q�6T   $	��Top=�6i   $	��199��6�   $��45��6�   ���	#FFBFF99C6�   �� 5   
    �� IsCancel$
 True��6   $��Отмена��6!   $
��Left=�62   $��516,339,0,0q�6M   $	��Top=�6b   $	��199��6z   $��45��6�   ���	#FFD4D4D46�   5      5      