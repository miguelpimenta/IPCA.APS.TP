using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GesNautico.Shared.Models;
using System.Windows.Input;
using GesNautico.DAL.LiteDB;
using System.Windows.Media;
using System.IO;
using GesNautico.Shared.Extensions;
using System.Drawing;
using System.Drawing.Imaging;
using GesNautico.Shared;
using System.Windows;

namespace GesNautico.Core.ViewModels
{
    class SocioViewModel : ModelBase
    {
        public Atleta atleta;
        public bool NewAtleta { get; set; } = false;
        public ICommand AtletaSave { get; private set; }
        public ICommand AtletaInsertFoto { get; private set; }
        public ICommand ShowDialogCommand { get; private set; }


        #region constructor
        public SocioViewModel()
        {
            NewAtleta = true;
            atleta = new Atleta();
            AtletaSave = new RelayCommand(SaveAtleta);
            AtletaInsertFoto = new RelayCommand(InsertFoto);
            ShowDialogCommand = new RelayCommand(ShowDialog);

            using (ILitedbDAL liteDAL = new LitedbDAL())
            {                
                atleta.NumAtleta = liteDAL.GetNextNumAtleta("Atletas");
            }
        }

        public SocioViewModel(Guid idAtleta)
        {            
            NewAtleta = false;
            atleta = GetAtleta(idAtleta);
            AtletaSave = new RelayCommand(SaveAtleta);
            AtletaInsertFoto = new RelayCommand(InsertFoto);
            ShowDialogCommand = new RelayCommand(ShowDialog);
        }
        #endregion

        #region Get Atleta
        private Atleta GetAtleta(Guid pkIdAtleta)
        {
            using (ILitedbDAL liteDAL = new LitedbDAL())
            {
                atleta = liteDAL.ReadAtleta(pkIdAtleta);
            }
            return atleta; 
        }
        #endregion


        #region Dados (Model)
        public int NumAtleta
        {
            get
            {
                return atleta.NumAtleta;
            }
            set
            {
                atleta.NumAtleta = value;
            }
        }

        public string Nome
        {
            get
            {
                return atleta.Nome;
            }
            set
            {
                atleta.Nome = value;
            }
        }

        public string Sexo
        {
            get
            {
                return atleta.Sexo;
            }
            set
            {
                atleta.Sexo = value;
            }
        }

        public DateTime DataNasc
        {
            get
            {
                return atleta.DataNasc;
            }
            set
            {
                atleta.DataNasc = value;
            }
        }

        public int Idade
        {
            get
            {
                return atleta.Idade;
            }
            set { }
        }

        public string Morada
        {
            get
            {
                return atleta.Morada;
            }
            set
            {
                atleta.Morada = value;
            }
        }

        public string Localidade
        {
            get
            {
                return atleta.Localidade;
            }
            set
            {
                atleta.Localidade = value;
            }
        }

        public string CodPostal
        {
            get
            {
                return atleta.CodPostal;
            }
            set
            {
                atleta.CodPostal = value;
            }
        }

        public string Email
        {
            get
            {
                return atleta.Email;
            }
            set
            {
                atleta.Email = value;
            }
        }

        public int? Telef
        {
            get
            {
                return atleta.Telef;
            }
            set
            {
                atleta.Telef = value;
            }
        }

        public int? Tlm
        {
            get
            {
                return atleta.Tlm;
            }
            set
            {
                atleta.Tlm = value;
            }
        }

        public string Escalao
        {
            get
            {
                return atleta.Escalao;
            }
            set
            {
                atleta.Escalao = value;
            }
        }

        public ImageSource Foto
        {
            get
            {
                if (atleta.Foto.Length > 20)
                {                    
                    ImageSourceConverter s = new ImageSourceConverter();
                    return (ImageSource)s.ConvertFrom(atleta.Foto);
                }
                else
                {
                    try
                    {
                        Image img = Properties.Resources.user;
                        byte[] buffer;
                        MemoryStream memoryStream = new MemoryStream();                        
                        img.Save(memoryStream, ImageFormat.Png);
                        buffer = memoryStream.ToArray();                         
                        return buffer.ByteToImageSource();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }
        }

        public string Obs
        {
            get
            {
                return atleta.Obs;
            }
            set
            {
                atleta.Obs = value;
            }
        }

        public bool Activo
        {
            get
            {
                return atleta.Activo;
            }
            set
            {
                atleta.Activo = value;
            }
        }

        string estado = string.Empty;
        public string Estado
        {
            get
            {
                if (atleta.Activo == true)
                {
                    estado = "Activo";
                    return estado;
                }
                else
                {
                    estado = "Inactivo";                    
                    return estado;
                }                
            }
            set
            {
                if (value.Contains("Activo"))
                {
                    estado = "Activo";
                    Activo = true;
                }
                else
                {
                    estado = "Inactivo";
                    Activo = false;
                }
                
            }
        }
        #endregion


        #region UI Bindinds / Info / Tooltips
        public List<string> EscalaoGeral
        {
            get
            {
                return Enums.EscalaoGeral();
            }
        }

        public List<string> Estados
        {
            get
            {
                return Enums.Estado();
            }
        }

        public List<string> Sexos
        {
            get
            {
                return Enums.Sexos();
            }
        }

        public string AtletaSaveContent
        {
            get
            {
                return "Gravar";
            }            
        }

        public string AtletaCancelContent
        {
            get
            {
                return "Cancelar";
            }
        }

        public string AtletaFoto
        {
            get
            {
                return "Inserir Foto";
            }
        }
        #endregion


        #region Commands

        private void InsertFoto(object obj)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png";            
            if (ofd.ShowDialog() == true)
            {
                atleta.Foto = File.ReadAllBytes(ofd.FileName);
                RaisePropertyChanged("Foto");
            }
        }

        private void SaveAtleta(object obj)
        {
            if (NewAtleta)
            {
                // Insert
                using (ILitedbDAL liteDAL = new LitedbDAL())
                {
                    liteDAL.InsertAtleta(atleta);
                }
                NewAtleta = false;
                ShowDialog("Registo inserido com sucesso.");                
            }
            else
            {
                // Update
                using (ILitedbDAL liteDAL = new LitedbDAL())
                {
                    liteDAL.UpdateAtleta(atleta);
                }
                ShowDialog("Registo actualizado com sucesso.");
            }
        }

        private void ShowDialog(object msg)
        {
            MessageBox.Show(msg.ToString(), "Informação", MessageBoxButton.OK, MessageBoxImage.Information);
        }       
        #endregion

    }
}
