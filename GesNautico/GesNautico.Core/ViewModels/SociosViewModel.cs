using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GesNautico.Shared.Models;
using System.Collections.ObjectModel;
using GesNautico.Shared;
using GesNautico.DAL.LiteDB;

namespace GesNautico.Core.ViewModels
{
    public class SociosViewModel : ModelBase
    {

        public ICommand AtletasRefresh { get; private set; }
        public ICommand OpenAtleta { get; private set; }
        //public ICommand NewAtleta { get; private set; }
        public ICommand ExportList { get; private set; }        

        //public DataTable atletas = null;
        ObservableCollection<Atleta> atletas;

        public SociosViewModel()
        {
            AtletasRefresh = new RelayCommand(Refresh);            
            //NewAtleta = new New();
            OpenAtleta = new Open();
            ExportList = new Export();

            Refresh(null);
        }

        #region UI Bindinds / Info / Tooltips
        public string AtletasRefreshContent
        {
            get
            {
                return "Pesquisar/Refrescar";
            }
        }

        public string ExportAtletasList
        {
            get
            {
                return "Exportar para Excel";
            }
        }

        public string InsertAtleta
        {
            get
            {
                return "Inserir novo Atleta";
            }
        }

        public List<string> EscalaoPesquisa
        {
            get
            {
                return Enums.EscalaoPesquisa();
            }
        }

        public List<string> Estados
        {
            get
            {
                return Enums.Estados();
            }
        }
        #endregion


        #region Inputs
        public string Pesquisa { get; set; } = string.Empty;
        string escalao = string.Empty;
        public string Escalao
        {
            get
            {
                return escalao;
            }
            set
            {
                if (value.Equals("Todos"))
                {
                    escalao = string.Empty;
                }
                else
                {
                    escalao = value;
                }                
                RaisePropertyChanged("Escalao");
                Refresh(null);
            }
        }

        string estado = string.Empty;
        public string Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
                RaisePropertyChanged("Estado");
                Refresh(null);
            }
        }
        #endregion


        #region Props
        //public DataTable Atletas
        //{
        //    get
        //    {
        //        return atletas;
        //    }
        //    set
        //    {
        //        atletas = value;
        //        RaisePropertyChanged("Atletas");
        //    }
        //}

        public ObservableCollection<Atleta> Atletas
        {
            get
            {
                return atletas;
            }
            set
            {
                atletas = value;
                RaisePropertyChanged("Atletas");
            }
        }
        #endregion


        #region Commands
        private void Refresh(object obj)
        {
            using (ILitedbDAL liteDAL = new LitedbDAL())
            {
                Atletas = null;
                Atletas = liteDAL.ListAtletas(Pesquisa, Escalao, string.Empty, string.Empty, Estado.Contains("Inactivo") ? false : true);
            }
        }

        class Open : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                if (!(parameter is Atleta))
                {
                    return;
                }
                else
                {
                    return;
                    //1new AtletaViewModel(Guid.Parse(parameter.ToString()));
                }
            }
        }

//        class New : ICommand
//        {
//            public event EventHandler CanExecuteChanged;

//            public bool CanExecute(object parameter)
//            {
//                return true;
//            }

//            public void Execute(object parameter)
//            {
//                if (!(parameter is Atleta))
//                {
//                    return;
//                }
//                else
//                {
////                    ((Frame)Window.Current.Content).Navigate(typeof(VehicleItemDetailPage), 0);
//                    //NavigationCommands.GoToPage.Execute("/Views/Atletas/Atleta/FichaAtletaView.xaml#" + Guid.Empty, this);
//                    //new AtletaViewModel();
//                }
//            }
//        }


        class Export : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                Exception ex = new Exception("Testing - Export");
                throw ex;
            }
        }        
        #endregion

    }
}
