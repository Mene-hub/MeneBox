   M S B A M L   `   `   `  ����B  >MeneBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MeneBoxMeneBox  5   	       MeneBox.MeneBoxClient   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:MeneBox     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ MeneBox��5   	   $	��450��6   $	��800��6&   $	��450��6G    � 
ResizeMode$ CanMinimize=�6W    � WindowStartupLocation$ CenterScreen=�6p   .��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      $��4* �6   6,   .+�5   
   �� ���	#FFF2F2F2$��0��6,   .+�5      #  MaterialDesignThemes.Wpf.Chip  -   5        $��	User_Logo��5   "   $��
22,10,0,10q�63      IconBackground �	#FFFF67006G   �� 5      ���	#FFFF6700$��Segoe UI Symbol)�6+   $��0,4,4,4q�6H   $��Center=�6Z   $	��120��6|   $��20,0,0,0q�6�   $
��Left=�6�   .��6�   Gestione file6�   �� 5      -   5         ��Name$ 
UploadFile��5      $��
20,10,20,0q�6)   
����������	#FFFF6700$
��Auto��6~   $��Center=�6�   $��10(�6�   $��Center=�6�   $��	16,2,16,4q�6�   $	��120��6�   $��20��6  ��6P   Z� .��6*  Carica62  �� 5      -   5        $ Download_File��5      $��
20,10,20,0q�6,   
����������	#FFFF6700$
��Auto��6�   $��Center=�6�   $��10(�6�   $��Center=�6�   $��	16,2,16,4q�6�   $	��120��6�   $��20��6  ��6S   Z� .��6*  	Scarica63  �� 5      -   5        $ Delete_File��5      $��
20,10,20,0q�6*   
����������	#FFFF6700$
��Auto��6   $��Center=�6�   $��10(�6�   $��Center=�6�   $��	16,2,16,4q�6�   $	��120��6�   $��20��6  ��6Q   Z� .��6-  
Cancella67  '  !MaterialDesignThemes.Wpf.PopupBox  5         PlacementMode$ BottomAndAlignCentres=�6&   +	   $ToggleCheckedContentCommandParameter$	 wowsers��6L   
 � ToolTip$
 Nuovo��6{   $��Right=�6�   $��Center=�6�   $��Center=�6�   $��Center=�6�   $��
20,10,20,0q�6     ToggleContent 5      �� 5      ���	#FFFF6700
�������$
��Auto��6]   $��Center=�6k   $��12(�6�   $��Center=�6�   $��	16,2,16,4q�6�   $	��120��6�   $��20��6�   $��Center=�6�   $��Center=�6  ��63   Z� .��6)  Nuovo60     PopupContent. 5!      �� .+�5"      �� -   5        $��BT_testo��5"   7   $
 Nuovo File .txt��6   .��6^   File di testo6m   �� 5#      -   5        $��New_Directory��5#      $
 Nuova cartella��63   .��6h   
Cartella6r   5$      5%      5'      � 5)   
   $��1��6   .+�5*      ��  �� Orientation$ Vertical=�6   .+�5+      �� $ 
Horizontal=�6   $	��Top=�66   $��
10,12,0,10q�6N   $
��Left=�6b   .+�5,      �� $��Img/Icon.png��6   $��30��62   $	��Top=�6>   $��Center=�6V   6u   �� 5-      $��Center=�6   $��Center=�69   $��15(�6T   $
��Bold"�6b   .��6t   	MeneBox6}   5.        50      $ BottomAndAlignCentres=�6*   $	 wowsers��6P   $
 Account settings��6   $��Right=�6�   $��Center=�6�   $��Center=�6�   $��Center=�6�   $��	0,-48,0,0q�6     ToggleCheckedContent 51      '  !MaterialDesignThemes.Wpf.PackIcon  52         Kind$ Pencil=�62   $��24��6@   $��24��6K   . 54      �� .+�55      �� -   5        $ Download��55   !   $
 Apri Downloads��63   .��6c   Visualizza Download6x   �� 56      -	   5        $
 Exit��56   !   $
 Esci dall'account��6/   .��6^   Esci6d   �� 57      -
   5        $ Delete_Account��57   !   $
 Cancella Account��69   .��6q   Cancella Account6�   58      59      �� 5;      $ 
Horizontal=�6   .+�5<      �� -   5        $ Back_Directory��5<      $1
 +MaterialDesignFloatingActionMiniLightButton��65   $
��Left=�6k   $��Center=�6�   $��Center=�6�   $��Center=�6�   $��24��6�   $��25��6�   $��10(�6�   $��0q�6  
����������	#FFFF6700���	#FFFF6700$��Normal"�6Z  $��2,0,0,0q�6n  $��0q�6  .��5=        $ 	ArrowBack=�62   $��15��6C   $��15��6O   5>      �� 5?      ���	#FFFF6700$��0,2,0,0q�64   $��29,4,4,4q�6N   $��I Tuoi File��6a   ���	#FFFF6700$	��608��6�   5@      �� 5A      -   5         ��Name$ File_Directory��5A      $	��Top=�63   $	��342��6R   $	��342��6_    �� View 5B      �� 5C      .P�5D      ��  �� CellTemplate 5E   "   �� 5F   &   .R�5G   *   �� $ 
Horizontal=�65   .+�5H   .   �� $��30��64   ��6@   �� *Ico+6Y   �� 5I   .   $��15(�6R   $	��300��6`   ��64   ��  �� Path$
 Nome�6n   5J   +   5K   '   5M      5N      5P      5Q      5R      5S      5T      