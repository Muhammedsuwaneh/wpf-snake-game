   M S B A M L   `   `   `  ����D  @SnakeGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SnakeGame	SnakeGame  5          SnakeGame.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:SnakeGame     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          � Title$  Snake��5       � Icon$! Resources/SnakeGameIcon.png��5
       � 
ResizeMode$ NoResize=�5       � SizeToContent$ WidthAndHeight=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        PlayGameCommand��   SnakeGame.MainWindow   PlayCommand   Command# Z 5      5        5   
   -   5        PauseGameCommand��	   PauseCommand# Z	 5      5        5   
   -   5        ContinueGameCommand��
   ContinueCommand# Z
 5"      5#        5$   
   -   5        ResetGameCommand��   ResetCommand# Z 5'      5(        5)   
   -   5        ExitGameCommand��   ExitCommand# Z 5,      5-      .��51      �  � RowDefinitions 53   
   �� 54      $��* �6   �� 55      $��* �6   �� 56      $
��Auto �6   .+�59   
   � $��0��5:      
���   �$	��Top=�5<       � ColumnDefinitions 5=      �� 5>      $��* �6#   �� 5?      $��* �6#   �� 5@      $
��Auto �6#    � 	Resources 5C       �� 
TargetType �� Property �� Value��%�   '��       �� 5D      " ��6   .�5E      ��  � ��$ Consolas)�63   �� 5F       � ��
 �����63   �� 5G       � ��$ 24(�61   �� 5H       � ��$
 Bold"�63   5I      5J      .+�5L      � $��10,0,0,0q�6   .+�5M      �� Score:6$   �� 5N      -   5        $��tbStatusScore��5N      064   5O      � 5P      $��1��6   .+�5Q      �� Speed:6$   �� 5R      -   5        $��tbStatusSpeed��5R      064   5S      �� 5T      -	   5        $��btnClose��5U      $��2��5V      $
��10,0q�5W      
������ $��0q�5Y      $��Right=�5[      $��20(�5\      $
��Bold"�5]      
�������.��5^   $   X5`      5a      o� 5b   
   $��1��6   .@�5c      m� $��_Game��6   .@�5d      m� -
   5         m�Name$ PlayGame��5e      $��
_Play Game��5g       m� InputGestureText$ Ctrl+G��5h      m� 5i      -   5        $ 	PauseGame��5j      $��_Pause��5l      $ Ctrl+P��5m      m� 5n      -   5        $ ContinueGame��5o      $��	_Continue��5q      $ Alt+C��5r      m� 5s      -   5        $ 	ResetGame��5t      $��_Reset��5v      $ Ctrl+R��5w      m� 5x      -   5        $ ExitGame��5y      $��_Exit��5{      $ Ctrl+Q��5|      5}      m� 5~      $��_Help��6   .@�5      m� -   5        $��	_Controls��5   2   5�      5�      �� 5�   
   $��2��5�      
���   �$��5q�5�      ._�5�      �� -   5         ��Name$ GameArea��5�      $	��880��5�      $	��700��5�      }�. 5�      5�      5�      5�      