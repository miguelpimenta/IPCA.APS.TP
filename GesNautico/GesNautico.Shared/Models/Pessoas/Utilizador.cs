using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNautico.Shared.Models
{
    public class Utilizador : Colaborador
    {

        //ObjectId idUtilizador = ObjectId.NewObjectId();
        int numUtilizador = 0;
        string nomeUtilizador = string.Empty;
        TipoUtilizador tipo = TipoUtilizador.Admin;

        public enum TipoUtilizador
        {
            [Description("Administrativo")]
            Admin,
            [Description("Tesoureiro")]
            Tes,
            [Description("Presidente")]
            Pres
        };

        //[BsonId]
        //[BsonField("_id")]
        //public ObjectId IdUtilizador
        //{
        //    get { return idUtilizador; }
        //    set
        //    {
        //        idUtilizador = value;
        //        RaisePropertyChanged("IdUtilizador");
        //    }
        //}

        public int NumUtilizador
        {
            get { return numUtilizador; }
            set
            {
                numUtilizador = value;
                RaisePropertyChanged("NumUtilizador");
            }
        }

        public string NomeUtilizador
        {
            get { return nomeUtilizador; }
            set
            {
                nomeUtilizador = value;
                RaisePropertyChanged("NomeUtilizador");
            }
        }

        public TipoUtilizador Perfil
        {
            get { return tipo; }
            set
            {
                tipo = value;
                RaisePropertyChanged("Tipo");
            }
        }        

        public Utilizador()
        {

        }

    }
}
