   M S B A M L   `   `   `  ����I  ECinemaSchedule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CinemaScheduleCinemaSchedule  5   	   !    CinemaSchedule.Registration   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:CinemaSchedule     5   	     � Title$  Registration��5   	   $	��900��6   $
��1920��6+    � WindowState$ 	Maximized=�5	   	   .��5
      � ���	#FFF4EEEE.+�5   
   �� $F��@Страница регистрации пользователя��6   $��Center=�6<   $��0,74,0,0q�6Y   $	��Top=�6k   $��66��6�   $	��624��6�   $��36(�6�   �� 5   
   $��Введите имя:��6   $��Center=�6'   $��-200,158,0,0q�6D   $	��Top=�6Z   $	��196��6r   $��16(�6~   $��31��6�   �� 5   
   -   5         ��Name$ 	name_text��5   /   $��Center=�6   $��	0,191,0,0q�6B    �� TextWrapping$ NoWrap=�6U   $�� ��6k   $	��Top=�6s   $	��412��6�   
�������$��40��6�   $��	15,7,15,0q�6�   $��18(�6�   .��6�    � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers	 P� Property
 P� Value��%�   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 15��65   �� 5       � ��$ 0q�68    5      P� 5      	 � {�$
 false��67   . �5      ��  � ��# � ��6<   5      5      5      .��6!   5      �� 5   
   $$��Введите фамилию:��6   $��Center=�6+   $��-200,234,0,0q�6H   $	��Top=�6^   $	��196��6v   $��16(�6�   $��31��6�   �� 5   
   -   5        $ surname_text��5   /   $��Center=�6   $��	0,260,0,0q�6E   $ NoWrap=�6X   $�� ��6n   $	��Top=�6v   $	��412��6�   
�������$��40��6�   $��	15,7,15,0q�6�   $��18(�6�   .��6�    5      ��%�   '��       �� 5       " ��6   .�5!      ��  �@��CornerRadius$ 15��65   �� 5"       � ��$ 0q�68    5#      P� 5$      	 � {�$
 false��67   . �5%      ��  � ��# � ��6<   5'      5)      5*      .��6!   5+      �� 5-   
   $&�� Введите отчество:��6   $��Center=�6,   $��-200,300,0,0q�6I   $	��Top=�6_   $	��196��6w   $��16(�6�   $��31��6�   �� 5.   
   -   5        $ patronymic_text��5.   /   $��Center=�6   $��	0,326,0,0q�6H   $ NoWrap=�6[   $�� ��6q   $	��Top=�6y   $	��412��6�   
�������$��40��6�   $��	15,7,15,0q�6�   $��18(�6�   .��6�    5/      ��%�   '��       �� 50      " ��6   .�51      ��  �@��CornerRadius$ 15��65   �� 52       � ��$ 0q�68    53      P� 54      	 � {�$
 false��67   . �55      ��  � ��# � ��6<   57      59      5:      .��6!   5;      �� 5<   
   $ ��Введите почту:��6   $��Center=�6)   $��-200,368,0,0q�6F   $	��Top=�6\   $	��196��6t   $��16(�6�   $��31��6�   �� 5=   
   -   5        $ 
email_text��5=   /   $��Center=�6   $��	0,396,0,0q�6C   $ NoWrap=�6V   $�� ��6l   $	��Top=�6t   $	��412��6�   
�������$��40��6�   $��	15,7,15,0q�6�   $��18(�6�   .��6�    5>      ��%�   '��       �� 5?      " ��6   .�5@      ��  �@��CornerRadius$ 15��65   �� 5A       � ��$ 0q�68    5B      P� 5C      	 � {�$
 false��67   . �5D      ��  � ��# � ��6<   5F      5H      5I      .��6!   5J      �� 5K   
   $"��Введите пароль:��6   $��Center=�6*   $��-200,432,0,0q�6G   $	��Top=�6]   $	��196��6u   $��16(�6�   $��31��6�   G� 5L   
   -   5         G�Name$ password_text��5L   a   $��Center=�6      roundcornerpassword#��[  64   $��	0,462,0,0q�6x    G� PasswordChar$ *��6�   $	��Top=�6�   $	��412��6�   $��40��6�   $��	15,7,15,0q�6�   $��18(�6�    5M      ��%    5N      5O      �� 5Q   
   $&�� Повторите пароль:��6   $��Center=�6,   $��-200,498,0,0q�6I   $	��Top=�6_   $	��196��6w   $��16(�6�   $��31��6�   G� 5R   
   -   5        $ password_repeat_text��5R   a   $��Center=�6   #��[  64   $��	0,525,0,0q�6   $ *��6�   $	��Top=�6�   $	��412��6�   $��40��6�   $��	15,7,15,0q�6�   $��18(�6�    5S      ��%    5T      5U      �� 5V   
   -   5        $��
Назад��5V      $��16(�6!   $
��Left=�6/   $��	10,10,0,0q�6J   $	��Top=�6]   $��0q�6u   $��41��6�   $��75��6�   5X      �� 5Y   
   $;��5Введите название кинотеатра:��6   $��Center=�67   $��-165,568,0,0q�6T   $	��Top=�6j   $	��235��6�   $��16(�6�   $��31��6�   �� 5Z   
   -   5        $ cinema_name_text��5Z   /   $��Center=�6   $��	0,596,0,0q�6I   $ NoWrap=�6\   $�� ��6r   $	��Top=�6z   $	��412��6�   
�������$��40��6�   $��	15,7,15,0q�6�   $��18(�6�   .��6�    5[      ��%�   '��       �� 5\      " ��6   .�5]      ��  �@��CornerRadius$ 15��65   �� 5^       � ��$ 0q�68    5_      P� 5`      	 � {�$
 false��67   . �5a      ��  � ��# � ��6<   5c      5e      5f      .��6!   5g      �� 5h   
   -	   5         ��Name$ RegisterButton��5h   o    � ToolTip$k eОстальные данные о кинотеатре нужно будет ввести потом��6   $*��$Зарегистрироваться��6R   $��	0,658,0,0q�6�   $	��Top=�6�   $��52��6�   $	��220��6�   $��20(�6�   $��Arial)�6�   ���	#FF85CAE6
������� J� RenderTransformOrigin$ 0.5,0.5&�6  $��0q�65   5i      ��%�   '��       �� 5j      " ��6   .�5k      ��  �@��CornerRadius$ 25��65   �� 5l       � ��$ 0q�68   5m      5n      5o      5p      5q      