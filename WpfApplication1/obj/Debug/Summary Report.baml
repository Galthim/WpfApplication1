   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5      $    WpfApplication1.Summary_Report   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:WpfApplication1     5        N� Title$  Summary_Report��5	      $	��540��6   $	��630��6+   .��5      � 
�������.+�5   
   	� -   5         	�Name$ Order_Date_Range��5      $��Order Date Range��60   $
��Left=�6K   $��	50,10,0,0q�6f   $	��Top=�6y    	� 	GroupName$ Summary��6�   6�   	� 5   
   -   5        $ Customer_Style��5      $��Customer Name��6.   $
��Left=�6F   $��
195,10,0,0q�6a   $	��Top=�6u   $ Summary��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ Summary_Grid��5      $
��Left=�6)   $��	10,85,0,0q�6D   $	��Top=�6W   $	��333��6o   $	��610��6|      
IsReadOnly . 6�   �� 5   
   -   5         ��Name$ 	From_Date��5      $
��Left=�6&   $��	50,30,0,0q�6A   $	��Top=�6T   $	��120��6l   �� 5   
   $��From:��6   $
��Left=�6    $��	10,30,0,0q�6;   $	��Top=�6N   �� 5   
   $	��To:��6   $
��Left=�6   $��	25,59,0,0q�69   $	��Top=�6L   �� 5   
   -   5        $ 	Till_Date��5      $
��Left=�6&   $��	50,56,0,0q�6A   $	��Top=�6T   $	��120��6l   �� 5   
   -   5        $ Customer_Combo��5      $
��Left=�6+   $��
195,30,0,0q�6F   $	��Top=�6Z   $	��120��6r   �� 5   
   -   5         ��Name$ 
Submit_Btn��5      $��Submit��6%   $
��Left=�66   $��
500,30,0,0q�6Q   $	��Top=�6e   $��75��6}   $��40��6�   6�   �� 5   
   -   5         ��Name$ Grand_Total_Box��5      $
��Left=�6+   $��41��6F   $��418,423,0,0q�6R    �� TextWrapping$
 Wrap=�6g   $	��Top=�6{   $	��120��6�   	 �� 
IsReadOnly	 . 6�   �� 5   
   $��Grand Total:��6   $
��Left=�6'   $��340,438,0,0q�6B   $	��Top=�6W   5      5      