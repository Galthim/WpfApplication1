   M S B A M L   `   `   `  ����  WpfApplication1&     WpfApplication1.Retrieve_Invoice   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     N� Title$  Retrieve Invoice��5   	   $	��540��6"   $	��630��6/   .��5      � 
�������.+�5   
   �� $��Retrieve Invoice��6   $
��Left=�6+   $��Center=�6F   $��	220,3,0,0q�6j   $	��Top=�6}    J� RenderTransformOrigin$ 0.474,-0.192&�6�   $	��187��6�   $
��Bold"�6�   $��22(�6�   �� 5   
   $	��488��6   $��
10,42,10,0q�6"   $	��Top=�66   .+�5      � $��0,0,10,0q�6   .+�5	      �� -   5         ��Name$ Customer_Name��5	      $��23��61    �� TextWrapping$
 Wrap=�6=   $��129,0,230,0q�6Q   {�.  6f   �� 5
      $��Customer Name:��6   $��
28,0,-28,0q�61   �� 5      -   5        $ 
Order_date��5      $
��Left=�6.   $��Right=�6I   $��41��6l   $��486,0,0,-18q�6x   $
 Wrap=�6�   $	��Top=�6�   $	��104��6�   {�.  6�   �� 5      $��Order Date:��6   $��408,7,114,-7q�6.   5      � 5      $��0,0,10,0q�6    � ColumnDefinitions 5      �� 5      $	��70* �6'   �� 5      $	��20* �6'   �� 5      $
��213* �6'   �� 5      $
��114* �6'   �� 5      $
��126* �6'   �� 5      $	��19* �6'   �� 5      $	��38* �6'   .+�5      �� -   5        $ Customer_Address_Street��5      $
 Wrap=�6;   $��39,0,18,-29q�6O   {�.  $��2��6v   $��2��6�   �� 5      $��Shipping Address:��6   $��3��64   $��25,11,130,-11q�6H   �� 5      -   5         ��Name$ ComboBox_Invoice��5      $
��Left=�6j   $��25��6�   $��57,27,0,-29q�6�   $	��Top=�6�   $	��116��6�   $��3��6�   $��4��6�    � ToolTip$$ Please select a date to review��6�   �� 5      $��Order Date:��6   $��101,29,69,-29q�6.   $��2��6E   $��3��6Y   5      � 5      $��
10,50,10,0q�6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ Products��5      $	��306��6-      
IsReadOnly . 6:   5       5(      5)      5*      