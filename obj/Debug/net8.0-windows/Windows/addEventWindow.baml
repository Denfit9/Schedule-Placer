   M S B A M L   `   `   `  ����I  ECinemaSchedule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CinemaSchedule.WindowsCinemaSchedule.Windows  5   	   +    %CinemaSchedule.Windows.addEventWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:CinemaSchedule.Windows     5   	   -   5          � Title$  Новое событие��5   	   $	��300��6   $
��1050��6,    � WindowStartupLocation$ CenterScreen=�69   .��5
      � .+�5   
   �� $2��,Создание нового события��6   $��Center=�62   $��0,10,0,0q�6O   $	��Top=�6a   $��20(�6y   �� 5   
   $��Тип события��6   $
��Left=�6&   $��
120,55,0,0q�6A   $	��Top=�6U   $��16(�6m   �� 5   
   -   5         ��Name$ typeComboBox��5      $
��Left=�6)   $��	50,85,0,0q�6D   $	��Top=�6W   $	��230��6o   $��26��6{   $��16(�6�   6�   �� 5   
   -   5         ��Name$ 
movieLabel��5      $��
Фильм��6$   $
��Left=�64   $��
520,55,0,0q�6O   $	��Top=�6c   $��16(�6{   $y�Hidden=�6�   �� 5   
   -   5        $ movieComboBox��5      $
��Left=�6*   $��
435,85,0,0q�6E   $	��Top=�6Y   $	��230��6q   $��26��6}   $��16(�6�   $y�Hidden=�6�   �� 5   
   -   5         �� 	IsDefault$
 True��5      $��Добавить��6"   $
��Left=�65   $��
65,215,0,0q�6P   $	��Top=�6d   $	��199��6|   $��45��6�   ���	#FFBFF99C6�   �� 5   
    �� IsCancel$
 True��6   $��Отмена��6!   $
��Left=�62   $��450,215,0,0q�6M   $	��Top=�6b   $	��199��6z   $��45��6�   ���	#FFD4D4D46�   �� 5   
   $��Час��6   $
��Left=�6   $��
718,55,0,0q�69   $	��Top=�6M   $��16(�6e   �� 5   
   -   5         ��Name$ 
movieHours��5      $��Center=�6&   $��
430,85,0,0q�6C    �� TextWrapping$
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $��20��6�    �� 	MaxLength$ 2��6�   $��24��6�   	 �� 
AcceptsTab$	 False��6�   
 �� AcceptsReturn$
 False��6�    � ContextMenu 6D  Z� �� 5   
   $��Минута��6   $
��Left=�6!   $��
790,55,0,0q�6<   $	��Top=�6P   $��16(�6h   �� 5   
   -   5        $ movieMinutes��5      $��Center=�6(   $��
595,85,0,0q�6E   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $��20��6�   $ 2��6�   $��24��6�   $	 False��6�   $
 False��6�    6J  Z� �� 5   
   $��Секунда��6   $
��Left=�6"   $��
890,55,0,0q�6=   $	��Top=�6Q   $��16(�6i   �� 5   
   -   5        $ movieSeconds��5      $��Center=�6(   $��
800,85,0,0q�6E   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $��20��6�   $ 2��6�   $��24��6�   $	 False��6�   $
 False��6�    6J  Z� �� 5   
   -	   5        $ eventDurationLabel��5      $7��1Продолжительность события��6,   $
��Left=�6P   $��725,115,0,0q�6k   $	��Top=�6�   $��16(�6�   �� 5   
   -
   5        $ 
hoursLabel��5      $��
Часов��6%   $
��Left=�65   $��712,135,0,0q�6P   $	��Top=�6e   $��16(�6}   �� 5   
   -   5        $ 
eventHours��5      $��Center=�6&   $��430,165,0,0q�6C   $
 Wrap=�6X   $�� ��6l   $	��Top=�6t   $��20��6�   $ 2��6�   $��24��6�   $	 False��6�   $
 False��6�    6E  Z� �� 5   
   -   5        $ minutesLabel��5      $��
Минут��6&   $
��Left=�66   $��793,135,0,0q�6Q   $	��Top=�6f   $��16(�6~   �� 5   
   -   5        $ eventMinutes��5      $��Center=�6(   $��595,165,0,0q�6E   $
 Wrap=�6Z   $�� ��6n   $	��Top=�6v   $��20��6�   $ 2��6�   $��24��6�   $	 False��6�   $
 False��6�    6K  Z� �� 5   
   -   5        $ secondsLabel��5      $��Секунд��6&   $
��Left=�67   $��893,135,0,0q�6R   $	��Top=�6g   $��16(�6   �� 5   
   -   5        $ eventSeconds��5      $��Center=�6(   $��800,165,0,0q�6E   $
 Wrap=�6Z   $�� ��6n   $	��Top=�6v   $��20��6�   $ 2��6�   $��24��6�   $	 False��6�   $
 False��6�    6K  Z� �� 5!   
   -   5        $ eventNameLabel��5!      $%��Название события��6(   $
��Left=�6C   $��
60,115,0,0q�6^   $	��Top=�6r   $��16(�6�   $y�Hidden=�6�   �� 5"   
   -   5        $ 	eventName��5"      $
��Left=�6%   $��
50,145,0,0q�6@   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��230��6�   $	 255��6�   $��24��6�   $	 False��6�   $
 False��6�   $y�Hidden=�6�   5#      5$      