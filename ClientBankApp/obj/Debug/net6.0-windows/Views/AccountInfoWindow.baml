   M S B A M L   `   `   `  ����H  DClientBankApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ClientBankApp.ViewsClientBankApp.Views  5   	   +    %ClientBankApp.Views.AccountInfoWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ClientBankApp.Views     5   	   -   5          �Name$  AccountWindow��5   	    � Title$ AccountInfoWindow��5
   	   $	��266��6#   $	��429��60    � WindowStartupLocation$ CenterScreen=�6<   .��5      �� $��	10,0,10,0q�6   $	��241��6$   $��Center=�61   .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $��0��6%   $��10,10q�65   $��20(�6D   
�������$��Тип счета:��6d   �� 5      $��0��6   $��1��6$   $��20(�6Y   $��3,0,3,10q�6g   ��64   �� *AccountTypes+ �� Text 5      �� *Type+�� 5      $��1��6   $��0��6%   $!��Сумма в рублях:��65   $��10,10q�6L   $��20(�6[   
�������6i   �� 5      -   5        $��1��5      $��1��6#   $��20(�6^   $��3,0,3,10q�6l   ��5      �� *Amount+�� 5      $��2��6   $��0��6%   $)��#Срок действия (мес):��65   $��10,10q�6Q   $��20(�6`   
�������6n   �� 5      -   5        $��2��5      $��1��6#   $��20(�6^   $��3,0,3,10q�6l   ��5      �� *AccountTerm+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5    
    �� Orientation$ 
Horizontal=�6   $	��320��6.   $
��5,20q�6:   .+�5!      �� $��Сохранить��6   $��0,0,20,0q�6)   $	��150��6;    � Cursor$
 Hand��5#   H   ��5"      �� 	 �� Path$	 SaveCommand���5#      �� 
 �� ElementName$
 AccountWindow��6H   �� 5$      $��Отмена��6   $	��150��6&   $
 Hand��62   ��5%      �� *
OutCommand+��5&      �� $
 AccountWindow��5'      5(      5)      