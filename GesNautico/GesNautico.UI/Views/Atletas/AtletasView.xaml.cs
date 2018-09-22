using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using GesNautico.Shared.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FirstFloor.ModernUI.Windows.Navigation;
using GesNautico.Core.ViewModels;

namespace GesNautico.UI.Pages
{
    /// <summary>
    /// Interaction logic for AtletasView.xaml
    /// </summary>
    public partial class AtletasView : UserControl, IContent
    {
        //AtletasViewModel dataContext;

        #region Constructor
        public AtletasView()
        {
            InitializeComponent();
            //dataContext = AtletasList.DataContext as AtletasViewModel;
        }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
           
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {

        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            //dataContext.AtletasRefresh.Execute(null);
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            
        }
        #endregion


        #region New Atleta
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {            
            try
            {
                var window = App.Current.MainWindow as ModernWindow;
                var menuLinks = window.MenuLinkGroups;
                foreach (LinkGroup lg in menuLinks)
                {
                    if (lg.DisplayName.ToUpper().Equals("ATLETAS"))
                    {
                        lg.Links.Add(new Link { DisplayName = "Ficha Atleta", Source = new Uri("/Views/Atletas/FichaAtletaView.xaml", UriKind.Relative) });
                    }
                }
                NavigationCommands.GoToPage.Execute("/Views/Atletas/FichaAtletaView.xaml#" + string.Empty, this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Open "Ficha Atleta"
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {                
                //DataRowView drv = (DataRowView)dgdAtletas.SelectedItem;
                //string idAtleta = (drv["Id"]).ToString();

                Atleta atleta = dgdAtletas.SelectedItem as Atleta;
                string idAtleta = atleta.Id.ToString();

                // Insert Usercontrol "Ficha Atleta"
                var window = App.Current.MainWindow as ModernWindow;
                var menuLinks = window.MenuLinkGroups;
                foreach (LinkGroup lg in menuLinks)
                {
                    if (lg.DisplayName.ToUpper().Equals("ATLETAS"))
                    {
                        lg.Links.Add(new Link { DisplayName = "Ficha Atleta", Source = new Uri("/Views/Atletas/FichaAtletaView.xaml", UriKind.Relative) });
                    }
                }
                NavigationCommands.GoToPage.Execute("/Views/Atletas/FichaAtletaView.xaml#" + idAtleta, this);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        
    }
}

