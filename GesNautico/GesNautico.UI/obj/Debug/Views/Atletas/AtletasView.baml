   M S B A M L   `   `   `  ����J  FGesNautico.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null`Aclr-namespace:GesNautico.Core.ViewModels;assembly=GesNautico.CoreGesNautico.Core.ViewModels  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      H DGesNautico.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GesNautico.UI.PagesGesNautico.UI.Pages 5	      `Aclr-namespace:GesNautico.Core.ViewModels;assembly=GesNautico.CoreGesNautico.Core.ViewModels  5      %   GesNautico.UI.Pages.AtletasView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      PdcAclr-namespace:GesNautico.Core.ViewModels;assembly=GesNautico.Core     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      R NMahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5      -local!clr-namespace:GesNautico.UI.Pages  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      JvmAclr-namespace:GesNautico.Core.ViewModels;assembly=GesNautico.Core  5      -   5          >�Name$  AtletasList��5       � DataContext 5      1   +GesNautico.Core.ViewModels.AtletasViewModel  5   
   .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� -   5         ��Name$ 	textBlock��5      $��	Pesquisar��5      $
��Wrap=�5      �� 5      $
��auto��6   $ 
Horizontal=�6'   .+�5      �� -   5         ��Name$ tbSearchAtletas��5      $	��200��5      $��26��5      $	��0,6q�5      $��Center=�5        �� TextWrapping$
 Wrap=�5"      ��5!      �� *
Pesquisa+ �� Mode$ OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=�.��5"   )    J� InputBindings 5#      �� 5$      
	 �� Key$	 Enter��6%   
 �� Command
 61   �� *AtletasRefresh+�� 5%      $	 Return��6%   
 62   �� *AtletasRefresh+.��5&   -   5'      �� 5(      -   5         ��Name$ cbTipoAtleta��5)      $	��120��5*      $��26��5+      $��5,0,0,0q�5,      $��Center=�5-       �� SelectedIndex$ 0��5/      ��5.      �� *EscalaoPesquisa+ �� SelectedItem 50      �� *	Escalao+$ OneWayToSource=�$ PropertyChanged=�55      �� 56      -   5        $ cbEstado��57      $	��120��58      $��26��59      $��5,0,0,0q�5:      $��Center=�5;      $ 0��5=      ��5<      �� *	Estados+ �� Text 5>      �� *Estado+$ OneWayToSource=�$ PropertyChanged=��� 5?      -   5         ��Name$ 
btnRefresh��5@      $
��auto��5A      $
��auto��5B      $��5,0,0,0q�5C      
������ $��Right=�5J      ���#0047ab   TransparentStyle#��[  5L      ��5E      �� *AtletasRefresh+��5F      7  1MahApps.Metro.IconPacks.PackIconMaterialExtension  �  �MahApps.Metro.IconPacks.PackIconExtension`2[[MahApps.Metro.IconPacks.PackIconMaterial, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null],[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]]   Kind$ Refresh=�   Width$ 26X�   Height$ 26X�   Spin$ FalseX� � ToolTip 5M      �� *AtletasRefreshContent+�� 5N      -   5        $ btnNew��5O      $
��auto��5P      $
��auto��5Q      $��05,0,0,0q�5R      
������ $��0q�5T      $��Right=�5Z      ���#0047ab#��[  5\      ��5V        $
 Plus=�$ 26X�$ 26X�$ FalseX� 5]      �� *InsertAtleta+5r      &   System.Windows.Controls.DataGrid  5t      -   5          Name$ 
dgdAtletas��5u      $
��auto��5v         AutoGenerateColumns .  
������    CanUserAddRows .     CanUserDeleteRows .     DataGridContentCellCentering   	CellStyle# [ 5{         GridLinesVisibility$ 
Horizontal=�5|         HeadersVisibility$ Column=�5}         
IsReadOnly .    RowBackground
 ����    	RowHeight$ 64Q�5�         SelectionMode$ Single=�5�          SelectionUnit$  FullRow=�5�      ��5      �� *	Atletas+$ TwoWay=�$ PropertyChanged=�!   Columns! 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      -	   5        Id��,  &System.Windows.Controls.DataGridColumn"   Header$" Id��5�      #   
Visibility$# Hidden=�5�      1  +System.Windows.Controls.DataGridBoundColumn$   Binding$ 5�      �� *Id+5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      -
   5        Foto��%   MinWidth$% 40Q�5�      &   
IsReadOnly& . $# Visible=�5�      '   CellTemplate' 5�      �� 5�      .R�5�   "   �� ( �� BitmapScalingMode$( HighQuality=�6(   ��6V   �� *
FotoBitmap+$ OneWay=�$ PropertyChanged=�5�      5�        5�      -   5        
PkIdAtleta��$" 
PkIdAtleta��5�      $# Hidden=�5�      $ 5�      �� *
PkIdAtleta+5�        5�      -   5        Nome��)   Width5	  /System.Windows.Controls.DataGridLengthConverter$
) Auto	 5�      $	% 200Q�5�      $
" Nome��5�      $ 5�      �� *Nome+5�        5�      -   5        	Idade��$
) Auto	 5�      $" Idade��5�      $ 5�      �� *Idade+*   ElementStyle* 5�      �� 5�      + �� 
TargetType"+ ��6$   .�5�   "   �� , �� Property, � ��- �� Value$- Center=�6H   5�      5�        5�      -   5        Tipo��$
) Auto	 5�      $" Escalão��5�      $ 5�      �� *	Escalao+5�        5�      -   5        	Email��$
) Auto	 5�      $" Email��5�      $ 5�      �� *Email+5�        5�      -   5        	Telef��$
) Auto	 5�      $" Telefone��5�      $ 5�      �� *Telef+5�        5�      -   5        Tlm��$
) Auto	 5�      $	" Tlm��5�      $ 5�      �� *Tlm+5�        5�      -   5        
Activo��$" Activo��5�      $# Hidden=�5�      $ 5�      �� *Activo+5�      . � 	Resources. 5�      )
  #System.Windows.Controls.DataGridRow��%E   '
        �� 5�      "+ 
 6   .�5�      -   5        5�      5�      5�      5�      5�      5�      