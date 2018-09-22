using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNautico.Shared.Models
{
    public class Socio : Pessoa
    {
        ObjectId idSocio = ObjectId.NewObjectId();
        int numSocio = 0;
        TipoSocio tipo = TipoSocio.Socio;

        public enum TipoSocio
        {
            Socio
        };

        //[BsonId]
        //[BsonField("_id")]
        //public ObjectId IdSocio
        //{
        //    get { return idSocio; }
        //    set
        //    {
        //        idSocio = value;
        //        RaisePropertyChanged("IdSocio");
        //    }
        //}

        public int NumSocio
        {
            get { return numSocio; }
            set
            {
                numSocio = value;
                RaisePropertyChanged("NumSocio");
            }
        }

        public TipoSocio Tipo
        {
            get { return tipo; }
            set
            {
                tipo = value;
                RaisePropertyChanged("Tipo");
            }
        }


        public Socio()
        {

        }

    }
}
