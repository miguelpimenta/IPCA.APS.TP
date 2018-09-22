using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNautico.Shared.Models
{
    public class Prova : ModelBase
    {
        ObjectId idProva = ObjectId.NewObjectId();
        string descricao = string.Empty;
        string localizacao = string.Empty;
        string categoria = string.Empty;
        string obs = string.Empty;
        DateTime data = DateTime.Now;

        [BsonId]
        [BsonField("_id")]
        public ObjectId IdProva
        {
            get { return idProva; }
            set
            {
                idProva = value;
                RaisePropertyChanged("IdProva");
            }
        }

        public string Descricao
        {
            get { return descricao; }
            set
            {
                descricao = value;
                RaisePropertyChanged("Descricao");
            }
        }

        public string Localizacao
        {
            get { return localizacao; }
            set
            {
                localizacao = value;
                RaisePropertyChanged("Localizacao");
            }
        }

        public string Categoria
        {
            get { return categoria; }
            set
            {
                categoria = value;
                RaisePropertyChanged("IdProva");
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

        public DateTime Data
        {
            get { return data; }
            set
            {
                data = value;
                RaisePropertyChanged("Data");
            }
        }


        public Prova()
        {

        }

    }
}
