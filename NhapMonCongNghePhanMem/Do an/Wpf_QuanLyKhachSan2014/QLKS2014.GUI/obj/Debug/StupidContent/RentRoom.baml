   M S B A M L   `   `   `  ����  QLKS2014.GUI)    #QLKS2014.GUI.StupidContent.RentRoom   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          >�Name$	  own��5      $��Times New Roman)�5      $	��437��5	   ,   .��5
      �  � RowDefinitions 5   
   �� 5      $��69 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $
��150* �6   �� 5      $	��50* �6    � ColumnDefinitions 5   
   �� 5      $
��100* �6   �� 5      $
��250* �6   �� 5      $
��100* �6   �� 5      $
��250* �6   �� 5      $
��100* �6   .+�5   
   �� $��PHIẾU THUÊ PHÒNG��6   $��25(�6+   $��3��5      $��SemiBold"�6$   &   System.Windows.Media.TextOptions   TextHintingMode$ Animated=�5      $��1��5      $��192,15,148,16q�6    $��Center=�5      $��38��6+   $��Center=�5      $	��260��6-   �� 5    
   $��Phòng:��6   $��30��6!   $��25,10,249,0q�6-   $	��Top=�5!      $��1��6(   $��2��5"      �� 5#   
   -   5        $��cbbRoom��5#      $��30��6"   $��
15,10,43,0q�6.   $	��Top=�5$      $��1��6*   $��1��6:   5%      �� 5'   
   $��Ngày bắt đầu thuê:��6   $��30��6-   $��
2,10,247,0q�5(      $	��Top=�6$   $��2��5)      $��1��6    $��2��6-   �� 5*   
   -   5        $��lblRentStartDate��5*      $��30��6(   $��
13,10,21,0q�64   $	��Top=�5+      $��3��6*   $��1��6:   &   System.Windows.Controls.DataGrid  5-   
   -   5          Name$ 
dgCustomer��5-      $��25,13,25,10q�6'   $��5��6<   $��4��5.         CanUserDeleteRows .    AutoGenerateColumns .     
IsReadOnly . ��6=   �� *
OcCustomer+ �� ElementName$	 own��	   Columns	 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Tên��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *MaNV+  56      $

 CMND��6%    63   �� *TenNV+  57      $
 Địa Chỉ��6%    66   �� *
DiaChiNV+  58      $
 Loại Khách��6%    69   �� *SDT+5:      �� 5H   
   $��Tên:��6   $��30��6   $��25,10,249,0q�6+   $	��Top=�5I      $��2��6(   $��2��5J      �� 5K   
   -   5         ��Name$ txtbName��5K      $��30��6$   $��
15,10,43,0q�60   $	��Top=�5L      $��1��6*   $��2��6:   �� 5M   
   $��
Loại KH:��6   $��30��6#   $��
2,10,247,0q�6/   $	��Top=�5N      $��2��6(   $��2��65   $��2��5O      �� 5P   
   -   5        $��cbbCustomerType��5P      $��30��6*   $��
17,10,21,0q�66   $	��Top=�5Q      $��3��6+   $��2��5R      5T      �� 5U   
   $��CMND:��6   $��30��6    $��25,10,249,0q�6,   $	��Top=�5V      $��3��6(   $��2��5W      �� 5X   
   -   5        $ 
txtbCartId��5X      $��30��6&   $��
15,10,43,0q�62   $	��Top=�5Y      $��1��6*   $��3��6:   5Z      �� 5[   
   $��Địa chỉ:��6   $��30��6#   $��
2,10,247,0q�6/   $	��Top=�5\      $��3��6(   $��2��65   $��2��5]      �� 5^   
   -   5        $ 
txtbAdress��5^      $��30��6&   $��
17,10,21,0q�62   $	��Top=�5_      $��3��6*   $��3��6:   �� 5`   
   -	   5        $��btnSave��5`      $��30��6    $	��100��6,   $��
Lưu Lại��5a      $��	64,6,86,0q�6#   $��5��66   $��Center=�5b      $	��Top=�6.   $��1��5c      6!   �� 5d   
   -
   5         ��Name$ btnAddCotomer��5d      $��30��6)   $��Thêm Khách Hàng��5e      $��3��6+   $��	64,6,66,0q�5f      $	��120��6$   $��5��60   $	��Top=�5g      $��Center=�6)   5h      5j      5k      