   M S B A M L   `   `   `  ����I  ECinemaSchedule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CinemaSchedule.WindowsCinemaSchedule.Windows  5   	   0    *CinemaSchedule.Windows.addEventsAutoWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:CinemaSchedule.Windows     5   	     � Title$7  1Автоматическое добавление��5   	   $	��300��6+   $
��1050��68    � WindowStartupLocation$ CenterScreen=�6E   .��5	      � .+�5
   
   �� $H��BАвтоматическое составление событий��6   $��Center=�6=   $��0,10,0,0q�6Z   $	��Top=�6l   $��20(�6�   �� 5   
   -   5         �� 	IsDefault$
 True��5      $��Добавить��6"   $
��Left=�65   $��
65,215,0,0q�6P   $	��Top=�6d   $	��199��6|   $��45��6�   ���	#FFBFF99C6�   �� 5   
    �� IsCancel$
 True��6   $��Отмена��6!   $
��Left=�62   $��450,215,0,0q�6M   $	��Top=�6b   $	��199��6z   $��45��6�   ���	#FFD4D4D46�   �� 5   
   $!��Время открытия��6   $��Center=�6)   $��-750,60,0,0q�6F   $	��Top=�6[   $��18(�6s   �� 5   
   $��Час��6   $
��Left=�6   $��	90,85,0,0q�69   $	��Top=�6L   $��16(�6d   �� 5   
   -   5         ��Name$ 
hoursBegin��5      $��Center=�6&   $��-830,115,0,0q�6C    �� TextWrapping$
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $��20��6�    �� 	MaxLength$ 2��6�   $��24��6�    �� 
AcceptsTab$ False��6�    �� AcceptsReturn$ False��6�   	 � ContextMenu	 6F  Z� �� 5   
   $��Минута��6   $
��Left=�6!   $��
150,85,0,0q�6<   $	��Top=�6P   $��16(�6h   �� 5   
   -   5        $ minutesBegin��5      $��Center=�6(   $��-695,115,0,0q�6E   $
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $��20��6�   $ 2��6�   $��24��6�   $ False��6�   $ False��6�   	 6L  Z� �� 5   
   $!��Время закрытия��6   $��Center=�6)   $��-150,60,0,0q�6F   $	��Top=�6[   $��18(�6s   �� 5   
   $��Час��6   $
��Left=�6   $��
390,85,0,0q�69   $	��Top=�6M   $��16(�6e   �� 5   
   -   5        $ hoursEnd��5      $��Center=�6$   $��-230,115,0,0q�6A   $
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $��20��6�   $ 2��6�   $��24��6�   $ False��6�   $ False��6�   	 6@  Z� �� 5   
   $��Минута��6   $
��Left=�6!   $��
440,85,0,0q�6<   $	��Top=�6P   $��16(�6h   �� 5   
   -   5        $ 
minutesEnd��5      $��Center=�6&   $��-110,115,0,0q�6C   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $��20��6�   $ 2��6�   $��24��6�   $ False��6�   $ False��6�   	 6F  Z� 5      5      