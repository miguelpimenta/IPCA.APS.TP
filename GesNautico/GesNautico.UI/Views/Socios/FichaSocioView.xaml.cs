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
using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;

namespace GesNautico.UI.Views.Socios
{
    /// <summary>
    /// Interaction logic for FichaSocioView.xaml
    /// </summary>
    public partial class FichaSocioView : UserControl, IContent
    {
        #region Constructor
        public FichaSocioView()
        {
            InitializeComponent();

        }
        #endregion

        #region Navigation
        void IContent.OnFragmentNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Fragment))
            {
                try
                {
                    Guid atletaId = Guid.Parse(e.Fragment);
                    DataContext = new Core.ViewModels.AtletaViewModel(atletaId);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                DataContext = new Core.ViewModels.AtletaViewModel();
            }
        }

        void IContent.OnNavigatedFrom(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {

        }

        void IContent.OnNavigatedTo(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            //ModernDialog.ShowMessage(e.Frame.ToString(), "Sair", System.Windows.MessageBoxButton.YesNo);
        }

        void IContent.OnNavigatingFrom(FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            var result = ModernDialog.ShowMessage("Sair da Ficha de Sócio?", "Sair", System.Windows.MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                NavigationCommands.GoToPage.Execute(e.Source.ToString(), this);
                try
                {
                    // Remove "Ficha Atleta"
                    var window = App.Current.MainWindow as ModernWindow;
                    var menuLinks = window.MenuLinkGroups;
                    foreach (LinkGroup lg in menuLinks)
                    {
                        if (lg.DisplayName.ToUpper().Equals("SÓCIOS"))
                        {
                            lg.Links.RemoveAt(2);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion
    }
}
