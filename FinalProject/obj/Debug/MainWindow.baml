   M S B A M L   `   `   `  ����G  CFinalProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FinalProjectFinalProject  5   	       FinalProject.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FinalProject     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  $
��Left=�6   $	��200��6.   $��	10,10,0,0q�6;   $	��Top=�6N   $	��757��6f   ��6r   �� *
Collection+ �� SelectedItem 6�   �� *Model+�� 5   
   $��	Nama Obat��6   $
��Left=�6$   $��
10,232,0,0q�6?   $	��Top=�6S    J� RenderTransformOrigin$ 0.451,-0.049&�6k   �� 5   
   $��Khasiat��6   $
��Left=�6"   $��
34,280,0,0q�6=   $	��Top=�6Q   $ 0.451,-0.049&�6i   �� 5   
   $��Jumlah��6   $
��Left=�6!   $��
35,322,0,0q�6<   $	��Top=�6P   $ 0.451,-0.049&�6h   �� 5   
   $��Harga satuan��6   $
��Left=�6'   $��	1,366,0,0q�6B   $	��Top=�6U   $ 0.451,-0.049&�6m   �� 5   
   $��ID Obat��6   $
��Left=�6"   $��185,322,0,0q�6=   $	��Top=�6R   $ 0.451,-0.049&�6j   �� 5   
   -   5         ��Name$ TxtName��5      $
��Left=�6#   $��23��6>   $��
95,236,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $	��Top=�6�   $	��251��6�   ��6r   �� *Model.nama_obat+ �� Mode$ TwoWay=�6�   �� 5   
   -   5        $ 
TxtKhasiat��5      $
��Left=�6&   $��23��6A   $��
95,280,0,0q�6M   $
 Wrap=�6a   $	��Top=�6�   $	��251��6�   ��6u   �� *Model.khasiat+$ TwoWay=�6�   �� 5   
   -   5        $ 	TxtJumlah��5      $
��Left=�6%   $��23��6@   $��
95,322,0,0q�6L   $
 Wrap=�6`   $	��Top=�6�   $��85��6�   ��6t   �� *Model.jumlah+$ TwoWay=�6�   �� 5   
   -   5        $ TxthargaSatuan��5      $
��Left=�6*   $��23��6E   $��
95,369,0,0q�6Q   $
 Wrap=�6e   $	��Top=�6�   $	��251��6�   ��6y   �� *Model.harga_satuan+$ TwoWay=�6�   �� 5   
   -   5        $ 	TxtIdObat��5      $
��Left=�6%   $��23��6@   $��241,325,0,0q�6L   $
 Wrap=�6a   $	��Top=�6�   $	��105��6�   ��6u   �� *Model.id_obat+$ TwoWay=�6�   �� 5   
   -   5         ��Name$ BtnInput��5      $��INPUT��6^   $
��Left=�6n   $��648,236,0,0q�6�   $	��Top=�6�   $	��134��6�   $ 0.097,0.008&�6�   $	��156��6�   ��6#   �� *InsertCommand+6�   �� 5   
   -   5        $ 	BtnUpdate��5      $��UPDATE��6$   $
��Left=�65   $��499,236,0,0q�6P   $	��Top=�6e   $	��126��6}   $ 0.097,0.008&�6�   $	��156��6�   �� 5   
   -   5        $ 	BtnDelete��5      $��DELETE��6$   $
��Left=�65   $��362,236,0,0q�6P   $	��Top=�6e   $	��118��6}   $ 0.097,0.008&�6�   $	��156��6�   5      5      