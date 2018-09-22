using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNautico.Shared.Models
{
    public class Colaborador : Pessoa
    {
        //ObjectId idColaborador = ObjectId.NewObjectId();
        int numColab = 0;
        TipoColaborador tipo = TipoColaborador.Func;
        DateTime dataEntrada = DateTime.Now;
        DateTime? dataSaida = null;

        public enum TipoColaborador
        {
            [Description("Funcionário")]
            Func,
            [Description("Treinador")]
            Trei
        };

        //[BsonId]
        //[BsonField("_id")]
        //public ObjectId IdColaborador
        //{
        //    get { return idColaborador; }
        //    set
        //    {
        //        idColaborador = value;
        //        RaisePropertyChanged("IdColaborador");
        //    }
        //}

        public int NumColab
        {
            get { return numColab; }
            set
            {
                numColab = value;
                RaisePropertyChanged("NumColab");
            }
        }

        public TipoColaborador Tipo
        {
            get { return tipo; }
            set
            {
                tipo = value;
                RaisePropertyChanged("Tipo");
            }
        }

        public DateTime DataEntrada
        {
            get { return dataEntrada; }
            set
            {
                dataEntrada = value;
                RaisePropertyChanged("DataEntrada");
            }
        }

        public DateTime? DataSaida
        {
            get { return dataSaida; }
            set
            {
                dataSaida = value;
                RaisePropertyChanged("DataSaida");
            }
        }


        public Colaborador()
        {

        }

    }
}