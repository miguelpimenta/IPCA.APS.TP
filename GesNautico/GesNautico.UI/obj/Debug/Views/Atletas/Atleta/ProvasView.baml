   M S B A M L   `   `   `  ����H  DGesNautico.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:GesNautico.UI.Views.Atletas.Atleta"GesNautico.UI.Views.Atletas.Atleta  5      3    -GesNautico.UI.Views.Atletas.Atleta.ProvasView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NMahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5      <local0clr-namespace:GesNautico.UI.Views.Atletas.Atleta  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      .��5      � .+�5   
   ��   �� Orientation$  Vertical=�6   .+�5      �� -   5         ��Name$ 	textBlock��5      $��	Pesquisar��5      $
��Wrap=�5      �� 5      $
��auto��6   $  
Horizontal=�6'   .+�5      �� -   5         ��Name$ tbSearchProva��5      $	��200��5      $��26��5      $	��0,6q�5      $��Center=�5      $�� ��5       �� TextWrapping$
 Wrap=�5      �� 5      -   5         ��Name$ 
btnRefresh��5      $
��auto��5      $
��auto��5      $��5,0,0,0q�5      
������ $��Right=�5&      ���#0047ab   TransparentStyle#��[  5(      ��5!      �� *ProvasRefresh+��5"      7  1MahApps.Metro.IconPacks.PackIconMaterialExtension  �  �MahApps.Metro.IconPacks.PackIconExtension`2[[MahApps.Metro.IconPacks.PackIconMaterial, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null],[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]]   Kind$ Refresh=�   Width$ 26X�   Height$ 26X�   Spin$ FalseX�	 � ToolTip	 5)      �� *ProvasRefreshContent+�� 5*      -   5        $ 	btnExport��5+      $
��auto��5,      $
��auto��5-      $��5,0,0,0q�5.      
������ $��0q�50      $��Right=�56      ���#0047ab#��[  58      ��51      �� *
ExportList+��52        $ Export=�$ 26X�$ 26X�$ FalseX�	 59      �� *ExportProvasList+�� 5:      -   5        $ btnNew��5;      $
��auto��5<      $
��auto��5=      $��05,0,0,0q�5>      
������ $��0q�5@      $��Right=�5F      ���#0047ab#��[  5H      ��5A      �� *
NewProva+��5B        $
 Plus=�$ 26X�$ 26X�$ FalseX�	 5I      �� *InsertProva+5J      &   System.Windows.Controls.DataGrid  5K      -   5        
  Name$
 
dgdAtletas��5L      $
��auto��5M         AutoGenerateColumns .  
������    CanUserAddRows .     CanUserDeleteRows .    DataGridContentCentering02   	CellStyle# [ 5R         GridLinesVisibility$
 None=�5S         
IsReadOnly .    RowBackground
 ����    	RowHeight$ 36Q�5W         SelectionMode$ Single=�5Y         SelectionUnit$ FullRow=�5Z      ��5U      ��  �� SelectedItem 5X      �� *SelectedItem+   Columns 5[      0  *System.Windows.Controls.DataGridTextColumn  5\      -   5        Id��,  &System.Windows.Controls.DataGridColumn   Header$ Id��5_         
Visibility$ Hidden=�5`      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5^      �� *Id+5`        5a      -   5        Data��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5c         MinWidth$ 80Q�5d        CellCenterText   ElementStyle# [ 5f      $
 Data��5g       5e      �� *
DataNasc+ �� StringFormat$ {0:dd-MM-yyyy HH:mm}��5g        5h      -	   5        	Prova��$
 Auto 5j      $ Prova��5l       5k      �� *Prova+5l        5m      -
   5        	Local��$
 Auto 5o      $ Local��5q       5p      �� *Local+5q        5r      -   5        	Categoria��$
 Auto 5t      $ 	Categoria��5v       5u      �� *	Categoria+5v      5x      5y      5{      5|      