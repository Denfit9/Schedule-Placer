   M S B A M L   `   `   `  ����I  ECinemaSchedule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CinemaSchedule.UserControlsCinemaSchedule.UserControls  5      .    (CinemaSchedule.UserControls.MovieControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:CinemaSchedule.UserControls     5      .��5	      � .+�5
   
   ��   �� RadiusX$  25��6    �� RadiusY$ 25��6!   ���	#FFD4F7F6$	��950��6?   $	��550��6K   6Z   �� 5   
   -   5         ��Name$ 	movieName��5      $
��Name��6'   $
��Wrap=�63   $��Center=�6G   $��
20,15,20,0q�6e   $	��Top=�6y   $��18(�6�   $	��850��6�   $��30��6�   $
��Bold"�6�    �� TextAlignment$ Center=�6�   �� 5   
   -   5        $ movieDescription��5      $����jjQA8JmUHEXPAdFv9FyJLhNN8PkM3oDjn0qD15zMdSzkGk73RYThxdJx5FmBt78IWDX4ZRnLDgkpS04G5WQuGXt8j0B2abT7QWyrdvkcEcgHyK9oEj3dlm0zF1QsvXX7NPD5z8QfNp607b7hXJ1LrIdv2zR6i5GiLPJkAJkNfpowC4V3TkIEaYUHvC88FiKSOAmxoiQUDGwau3ruDjfEnhPAjErpdeaJ1OlaTAuUkl3Y4YWwaEu5CC5DXWnrRNMXbIcVVEtvm4EJPfP41TC9OSgmyT1RbVQBfKrbc2fbfG62ulBRfoWpFxUWpaasyflLLnK78pgfQ6CogqijZ0EDh08uOr9gOXYIXhYbJ9YsC6b1OxaCmnlmfAypAJOsNfxYN6p68P4yVItmmRqIN0l3d5lwPT1HKmDuhoHH50WBZ8uQOnwkTx2mYZKpxabqd5AGhlm5m4vY6mZVf4sUUggzOzFdfvwNyw9aEv5Kw3Q9vvT4DNrmN4PzG4GuShrhPNnSm7AF3Wwl9Ao4zFOXwFSyd5AuPqOUeOqpVJvZTgXAjkMnSLAeyCGXyE19HniwDzQbLblq1UHpFOs1kJWBYv6n10FbSAkU5iGAfr9K4V4ccDjPvIcPgdf999M2Na0iYCrvAIt3MtvzLmIHpew8pT4jCwD9jRHu0SmL4X4IWRxqmyGQDssFTlVZIGQ8dXE6WzOe7eRk02wm5RPOl9WWkeyWgAdAMjBSfoe4fFeOshxsXMP0mLn11R0o2fsnsxsuj9az3Y14exrXA2WtpeR2jVtiDJpbv3Oa5eQRkhZuIix1komsMotMn9PIBxI63CGbuvxbx1Rx8jx9DWkrtfRMwwFLrHhshWjnwg04lrCdgkP8kSJqzmsa1ZemXLrFux4OSoA5BqwfbywEdltlCo0k2B0oV4Ab6Exz833jtFUwH4RWQ1tarWLrGq2mksztALyk0pbXcjrxkkzMjRp7Mw8rO9Ri0ZrSOIEeEmAo9QB9R8gF  ��6.   $
��Wrap=�5      $��Center=�6   $��
20,55,20,0q�65   $	��Top=�6I   $��16(�6a   $	��900��6o   $	��250��6{   �� 5   
   -   5        $��Изменить��5      $
��Left=�6$   $��	20,0,0,20q�6?   $��Bottom=�6R   ���	#FFFCFCFC$��16(�6�   $��1q�6�   
���   �$	��100��6�   6�   �� 5   
   -   5        $��Удалить��5      $��Right=�6#   $��	0,0,20,20q�6?   $��Bottom=�6R   ���	#FFFDB9B9$��16(�6�   $��1q�6�   
���   �$	��100��6�   6�   �� 5   
   -   5         ��Name$ movieID��5      $��Label��6!   $
��Left=�61   $��	70,10,0,0q�6L   $	��Top=�6_   $y�Hidden=�6w   �� 5   
   -   5        $ 
movieGenre��5      $��Жанры:��6(   $
��Wrap=�66   $��Center=�6J   $��-810,310,20,0q�6h   $	��Top=�6   $��18(�6�   $	��100��6�   $��30��6�   $
��Bold"�6�   $ Center=�6�   �� 5   
   -   5        $ movieGenres��5      $�� ��6)   $
��Wrap=�61   $��Center=�6E   $��100,315,20,0q�6c   $	��Top=�6y   $��14(�6�   $	��800��6�   $��60��6�   $
 Left=�6�   �� 5   
   -   5        $ movieCountry��5      $��Страны:��6*   $
��Wrap=�69   $��Center=�6M   $��-810,380,20,0q�6k   $	��Top=�6�   $��18(�6�   $	��100��6�   $��30��6�   $
��Bold"�6�   $ Center=�6�   �� 5   
   -	   5        $ movieCountries��5      $�� ��6,   $
��Wrap=�64   $��Center=�6H   $��100,385,20,0q�6f   $	��Top=�6|   $��14(�6�   $	��800��6�   $��60��6�   $
 Left=�6�   �� 5   
   -
   5        $ startingDate��5      $ ��Старт проката:��6*   $
��Wrap=�6@   $��Center=�6T   $��-750,450,20,0q�6r   $	��Top=�6�   $��18(�6�   $	��150��6�   $��30��6�   $
��Bold"�6�   $ Center=�6�   �� 5   
   -   5        $ startingDateText��5      $��
03-02-2002��6.   $
��Wrap=�6@   $��Center=�6T   $��-500,455,20,0q�6r   $	��Top=�6�   $��14(�6�   $	��120��6�   $��25��6�   $ Center=�6�   �� 5   
   -   5        $ 
endingDate��5      $ ��Конец проката:��6(   $
��Wrap=�6>   $��Center=�6R   $��410,450,20,0q�6p   $	��Top=�6�   $��18(�6�   $	��150��6�   $��30��6�   $
��Bold"�6�   $ Center=�6�   �� 5   
   -   5        $ endingDateText��5      $��
03-02-2002��6,   $
��Wrap=�6>   $��Center=�6R   $��650,455,20,0q�6p   $	��Top=�6�   $��14(�6�   $	��120��6�   $��25��6�   $ Center=�6�   �� 5   
   -   5        $ DurationText��5      $#��2 час. 3 мин. 2 сек.��6*   $
��Wrap=�6F   $��Center=�6Z   $��-50,455,20,0q�6x   $	��Top=�6�   $��14(�6�   $	��150��6�   $��25��6�   $ Center=�6�   5      5      