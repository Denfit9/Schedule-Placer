   M S B A M L   `   `   `  ����I  ECinemaSchedule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CinemaSchedule.UserControlsCinemaSchedule.UserControls  5      *    $CinemaSchedule.UserControls.Schedule   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:CinemaSchedule.UserControls     5      
�������.��5	      � .+�5
   
   �� -   5          ��Name$  cinemaScheduleLabel��5
      $��Расписание��6-   $��Center=�6B   $��30(�6_   $��Book Antiqua)�6m   $��0,15,0,0q�6�   $	��Top=�6�   �� 5   
   -   5        $  cinemaFinalScheduleLabel��5      $+��%Итоговое расписание��62   $��Center=�6P   $��20(�6m   $��Book Antiqua)�6{   $��	0,279,0,0q�6�   $	��Top=�6�   �� 5   
   $
��Auto=�6   $
��Auto=�6:   $
��1400��6_   $	��230��6l   $��Center=�6y   $��	0,320,0,0q�6�   $	��Top=�6�   .��5      �� -   5         ��Name$ 
eventsList��5      $��1q�6/   
���   ���5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6%   5      5      5      �� 5   
   -   5        $  cinemaScheduleLabel_Copy��5      $��Зал:��62   $
��Left=�6A   $��20(�6\   $��Book Antiqua)�6j   $��
100,70,0,0q�6�   $	��Top=�6�   �� 5   
   -   5         ��Name$ hallsComboBox��5      $
��Left=�6*   $��
160,75,0,0q�6E   $	��Top=�6Y   $	��220��6q   $��26��6}   $��16(�6�   �� 5   
   -   5        $  scheduleDateLabel��5      $��	Дата:��6+   $
��Left=�6;   $��20(�6V   $��Book Antiqua)�6d   $��
650,70,0,0q�6~   $	��Top=�6�   &   System.Windows.Controls.Calendar  5   
   -   5          Name$ dateCalendar��5      $
��Left=�6)   $��
720,70,0,0q�6D   $	��Top=�6X   $	��165��6p   �� 5   
   -   5         ��Name$ showEventsButton��5      $��Показать��6+   $
��Left=�6>   $��1050,65,0,0q�6Y   $	��Top=�6n   $��18(�6�   
���   �$��2q�6�   $	��340��6�   $��50��6�   ��6�   Z� 6�   �� 5   
   -	   5        $ addEventButton��5      $%��Добавить событие��6)   $
��Left=�6D   $��1050,125,0,0q�6_   $	��Top=�6u   $��18(�6�   
���   �$��2q�6�   $	��340��6�   $��50��6�   ��6�   Z� 6�   �� 5   
   -
   5        $ addEventsAutoButton��5      $H��BЗаполнить расписание автоматически��6.   $
��Left=�6[   $��1050,185,0,0q�6v   $	��Top=�6�   $��18(�6�   
���   �$��2q�6�   $	��340��6�   $��50��6�   ��6�   Z� 6	  5      5      