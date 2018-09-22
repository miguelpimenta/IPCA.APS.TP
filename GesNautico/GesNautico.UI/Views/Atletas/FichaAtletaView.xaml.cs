using System;
using System.Windows;
using System.Windows.Controls;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Presentation;
using System.Windows.Input;

namespace GesNautico.UI.Views.Atletas
{
    /// <summary>
    /// Interaction logic for AtletaView.xaml
    /// </summary>
    public partial class FichaAtletaView : UserControl, IContent
    {

        #region Constructor
        public FichaAtletaView()
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
            var result = ModernDialog.ShowMessage("Sair da Ficha de Atleta?", "Sair", System.Windows.MessageBoxButton.YesNo);
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
                        if (lg.DisplayName.ToUpper().Equals("ATLETAS"))
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
