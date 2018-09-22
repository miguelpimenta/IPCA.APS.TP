using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstFloor.ModernUI.Presentation;

namespace GesNautico.UI
{
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        private LinkGroupCollection groups = new LinkGroupCollection();

        public LinkGroupCollection Groups
        {
            get { return this.groups; }
        }

        public void GetMenu()
        {
            var groupInicio = new LinkGroup { DisplayName = "Início" };
            groupInicio.Links.Add(new Link { DisplayName = "Início", Source = new Uri("/Views/InicioView.xaml", UriKind.Relative) });
            this.groups.Add(groupInicio);

            var groupAtletas = new LinkGroup { DisplayName = "Atletas" };
            groupAtletas.Links.Add(new Link { DisplayName = "Listagem", Source = new Uri("/Views/Atletas/AtletasView.xaml", UriKind.Relative) });
            groupAtletas.Links.Add(new Link { DisplayName = "Próximos Aniversários", Source = new Uri("/Views/Atletas/AtletasProxAniverView.xaml", UriKind.Relative) });
            //groupAtletas.Links.Add(new Link { DisplayName = "Ficha Atleta", Source = new Uri("/Views/Atletas/Atleta/FichaAtletaView.xaml", UriKind.Relative) });
            this.groups.Add(groupAtletas);

            var groupSocios = new LinkGroup { DisplayName = "Sócios" };
            groupSocios.Links.Add(new Link { DisplayName = "Listagem", Source = new Uri("/Views/Socios/SociosView.xaml", UriKind.Relative) });
            groupSocios.Links.Add(new Link { DisplayName = "Próximos Aniversários", Source = new Uri("/Views/Socios/SociosProxAniverView.xaml", UriKind.Relative) });
            this.groups.Add(groupSocios);
        }
    }
}
