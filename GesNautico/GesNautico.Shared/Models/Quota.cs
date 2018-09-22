using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNautico.Shared.Models
{
    public class Quota : ModelBase
    {
        ObjectId idQuota = ObjectId.NewObjectId();
        float valor = SharedSettings.Default.ValorQuota;
        DateTime dataPagamento = DateTime.Now;
        TipoQuota tipo = TipoQuota.Anual;

        public enum TipoQuota
        {
            Anual,
            Semestral,
            Trimestral,
            Mensal
        };

        [BsonId]
        [BsonField("_id")]
        public ObjectId IdQuota
        {
            get { return idQuota; }
            set
            {
                idQuota = value;
                RaisePropertyChanged("IdQuota");
            }
        }

        public float Valor
        {
            get { return valor; }
            set
            {
                valor = value;
                RaisePropertyChanged("Valor");
            }
        }

        public DateTime DataPagamento
        {
            get { return dataPagamento; }
            set
            {
                dataPagamento = value;
                RaisePropertyChanged("DataPagamento");
            }
        }

        public TipoQuota Tipo
        {
            get { return tipo; }
            set
            {
                tipo = value;
                RaisePropertyChanged("Tipo");
            }
        }



        public Quota()
        {

        }
    }
}
