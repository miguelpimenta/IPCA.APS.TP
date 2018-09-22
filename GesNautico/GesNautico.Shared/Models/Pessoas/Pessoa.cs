using GesNautico.Shared.Extensions;
using LiteDB;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Media;

namespace GesNautico.Shared.Models
{

    public abstract class Pessoa : ModelBase
    {
        
        Guid id = Guid.NewGuid();
        string nome = string.Empty;
        string sexo = string.Empty;
        DateTime dataNasc = DateTime.Now;
        string email = string.Empty;
        int? telef = null;
        int? tlm = null;
        string morada = string.Empty;
        string localidade = string.Empty;
        string codPostal = string.Empty;
        string obs = string.Empty;
        byte[] foto = new byte[0];
        bool activo = true;

        [BsonId]
        [BsonField("_id")]
        public Guid Id
        {
            get { return id; }
            set
            {
                id = value;
                RaisePropertyChanged("Id");
            }
        }

        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                RaisePropertyChanged("Nome");
            }
        }

        public string Sexo
        {
            get { return sexo; }
            set
            {
                sexo = value;
                RaisePropertyChanged("Sexo");
            }
        }

        [DisplayName("Data Nascimento")]        
        public DateTime DataNasc
        {
            get { return dataNasc; }
            set
            {
                dataNasc = value;
                RaisePropertyChanged("DataNasc");
                RaisePropertyChanged("Idade");
            }
        }

        [BsonIgnore]
        public int Idade
        {
            get { return CalcularIdade(DataNasc); }            
        }

        

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged("Email");
            }
        }

        public int? Telef
        {
            get { return telef; }
            set
            {
                telef = value;
                RaisePropertyChanged("Telef");
            }
        }

        public int? Tlm
        {
            get { return tlm; }
            set
            {
                tlm = value;
                RaisePropertyChanged("Tlm");
            }
        }

        public string Morada
        {
            get { return morada; }
            set
            {
                morada = value;
                RaisePropertyChanged("Morada");
            }
        }

        public string Localidade
        {
            get { return localidade; }
            set
            {
                localidade = value;
                RaisePropertyChanged("Localidade");
            }
        }

        public string CodPostal
        {
            get { return codPostal; }
            set
            {
                codPostal = value;
                RaisePropertyChanged("CodPostal");
            }
        }

        public string Obs
        {
            get { return obs; }
            set
            {
                obs = value;
                RaisePropertyChanged("Obs");
            }
        }

        public byte[] Foto
        {
            get { return foto; }
            set
            {
                foto = value;
                RaisePropertyChanged("Foto");
                RaisePropertyChanged("FotoBitmap");
            }
        }

        [BsonIgnore]
        public ImageSource FotoBitmap
        {
            get { return foto.ByteToImageSource(); }            
        }

        public bool Activo
        {
            get { return activo; }
            set
            {
                activo = value;
                RaisePropertyChanged("Activo");
            }
        }


        public Pessoa()
        {

        }

        /// <summary>
        /// Calcular Idade
        /// </summary>
        /// <param name="dataNasc"></param>
        /// <returns></returns>
        public int CalcularIdade(DateTime dataNasc)
        {
            int age = DateTime.Now.Year - dataNasc.Year;

            if (DateTime.Now.Month < dataNasc.Month || (DateTime.Now.Month == dataNasc.Month && DateTime.Now.Day < dataNasc.Day))
            {
                age--;
            }
            return age;
        }

    }
}
