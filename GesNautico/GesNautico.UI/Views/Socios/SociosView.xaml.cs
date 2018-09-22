using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GesNautico.Shared.Models;

namespace GesNautico.UI.Pages
{
    /// <summary>
    /// Interaction logic for SociosView.xaml
    /// </summary>
    public partial class SociosView : UserControl
    {
        #region Constructor
        public SociosView()
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
                    if (lg.DisplayName.ToUpper().Equals("SÓCIOS"))
                    {
                        lg.Links.Add(new Link { DisplayName = "Ficha Sócio", Source = new Uri("/Views/Socios/FichaSocioView.xaml", UriKind.Relative) });
                    }
                }
                NavigationCommands.GoToPage.Execute("/Views/Socios/FichaSocioView.xaml#" + string.Empty, this);
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
                    if (lg.DisplayName.ToUpper().Equals("SÓCIOS"))
                    {
                        lg.Links.Add(new Link { DisplayName = "Ficha Sócio", Source = new Uri("/Views/Socios/FichaSocioView.xaml", UriKind.Relative) });
                    }
                }
                NavigationCommands.GoToPage.Execute("/Views/Socios/FichaSocioView.xaml#" + idAtleta, this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}

