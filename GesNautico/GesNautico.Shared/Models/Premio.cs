using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNautico.Shared.Models
{
    public class Premio : ModelBase
    {
        ObjectId idPremio = ObjectId.NewObjectId();
        ObjectId idProva = ObjectId.NewObjectId();
        ObjectId idAtleta = ObjectId.NewObjectId();
        string classificacao = string.Empty;
        string tipoPremio = string.Empty;
        float valorPremio = 0;
        

        [BsonId]
        [BsonField("_id")]
        public ObjectId IdPremio
        {
            get { return idPremio; }
            set
            {
                idPremio = value;
                RaisePropertyChanged("IdPremio");
            }
        }

        public ObjectId IdProva
        {
            get { return idProva; }
            set
            {
                idProva = value;
                RaisePropertyChanged("IdProva");
            }
        }

        public ObjectId IdAtleta
        {
            get { return idAtleta; }
            set
            {
                idAtleta = value;
                RaisePropertyChanged("IdAtleta");
            }
        }

        public string Classificacao
        {
            get { return classificacao; }
            set
            {
                classificacao = value;
                RaisePropertyChanged("Classificacao");
            }
        }

        public string TipoPremio
        {
            get { return tipoPremio; }
            set
            {
                tipoPremio = value;
                RaisePropertyChanged("TipoPremio");
            }
        }
        

        public float ValorPremio
        {
            get { return valorPremio; }
            set
            {
                valorPremio = value;
                RaisePropertyChanged("ValorPremio");
            }
        }


        public Premio()
        {

        }
        
    }
}
