   M S B A M L   `   `   `  ����H  DClientBankApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:ClientBankApp.Infrastructure.Behaviors&ClientBankApp.Infrastructure.Behaviors  5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089_ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a   WindowHeaderButtonStyle2  �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� Triggers P� Property P� Value �� 
TargetName  MinimizeButtonIconGeomentry $  MaximizeToMaxButtonIconGeomentry  CloseButtonIconGeomentry  WindowTemplate2	 J� Effect-   'System.Windows.Media.Effects.BlurEffect
    RenderingBias �Name&   System.Windows.Media.TextOptions   TextRenderingMode   TextFormattingMode*  $Microsoft.Xaml.Behaviors.Interaction   	BehaviorsC   =ClientBankApp.Infrastructure.Behaviors.WindowTitleBarBehavior � IconE  ?ClientBankApp.Infrastructure.Behaviors.WindowSystemIconBehavior �� Orientation � 	Resources �� BasedOn �� RelativeSource �� AncestorType;  5ClientBankApp.Infrastructure.Behaviors.MinimizeWindow>  8ClientBankApp.Infrastructure.Behaviors.WindowStateChange8   2ClientBankApp.Infrastructure.Behaviors.CloseWindow � Title  WindowStyle 3 /x:Key{x:Static SystemColors.WindowTextBrushKey} / +x:Key{x:Static SystemColors.WindowBrushKey}�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      3i+http://schemas.microsoft.com/xaml/behaviors  5      :b4clr-namespace:ClientBankApp.Infrastructure.Behaviors  5      %g
  &	        &	 �    &	     &	 L    &	 w    7   7  7  7  &	 �    7  �� 5      "  ��6-   .�5   
   ��  � |�$ False��6&   �� 5   
    � ��$ 0q�6,   �� 5   
    � �� 5	      �� 5
      " ��6"   .R�5      � .+�5      �� $ PART_Border��6!   
������ #��z��5      #��z��5      ._�5      �� 5      5       5      P� 5       �@J�IsMouseOver$
 True��69   . �5      �� $ PART_Border��6%    � ��
 ��·�6T   �� 5      $ PART_Border��6%    �@J�Opacity$	 0.7Q�6Q   5      P� 5       � ��$
 True��67   . �5      �� $ PART_Border��6%    � ��
 ��  �6T   �� 5      $ PART_Border��6%    �@J�Opacity$ 1Q�6Q   �� 5       � ��
 �����6;   5      5      5      5       �5"      M0,8 H8 M0,7 H8 M0,6 H8�6L   �5#      $ M0,0 H8 V8 H0 V0 M0,1 H8 M0,2 H8�6Z   �5$      M0,0 L8,8 M0,8 L8,0�6E   �� 5&      " �6.   .R�5'   
   � .+�5(      �� $��PART_Border��6   $��7q�5)      #��z��5*      #��z��5+      	 5,         5-      #
 z��6!   5/      � 50      $ PART_MainGrid��6   $��7q�51      #��z��52      $ 	ClearType=�53      $ Display=�54      .+�55      ]� .+�56      � $��PART_TitleBar��6   $	��Top=�60   
������� 57        58      .+�5:      ]� $��32��6$   .+�5;      �� $��	PART_Icon��6$   $
��Left=�65   #��z 5<       $��	0,-10,0,0q�5=        5>   "     5?   &   5A      �� 5B      $��Right=�6)   $ 
Horizontal=�6@    5C   "   ���� 5D   &   '��       "  ��6,   8   6I   �� 5E   &   'F�       "  F�6,   .�5F   *   ��  � ��$ 1��6L   6X   �� 5G   *    � �� 5H   -   �� *
Foreground+ �� 
 Button�� 5I   *    � ��$ 10q�6C   5J   '   5K   #   .+�5L   "   ��  5M   &     5N   *   .��5P   &   F� 8�� 6+   5Q   #   �� 5R   "    5S   &     5T   *   .��5V   &   F� 8�� 6+   5W   #   �� 5X   "   
���  �� 5Y   &     5Z   *   .��5\   &   F� 8�� 6+   5]   #   5^      �� 5_      $��
PART_Title��6(   #��z 5`   $   $��12(�5a   $   $��4,0,0,0q�5b   $   $��Center=�5c   $   5e      5f      �� 5g      .u�5h      �� 5i      5j      5k      5l      5m      �� 5n      "  �6    .�5o   
   ��  �@�WindowStyle$
 None=�6(   �� 5p   
    �@�AllowsTransparency$
 True��6/   �� 5q   
    � ��$ 7q�6,   �� 5r   
    � ��# �  6'   �� 5s   
    � ��# �  6'   �� 5t   
    �@�
ResizeMode$ CanResizeWithGrip=�6'   �� 5u   
    � ��8   6%   5v      5w      