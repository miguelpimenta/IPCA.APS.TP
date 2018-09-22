using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GesNautico.Shared.Models
{
    public class Atleta : Pessoa
    {        

        int numAtleta = 0;
        string escalao = string.Empty;

        public int NumAtleta
        {
            get { return numAtleta; }
            set
            {
                numAtleta = value;
                RaisePropertyChanged("NumAtleta");
                //string z = MethodBase.GetCurrentMethod().Name;
                //string x = MethodBase.GetCurrentMethod().Name.Substring(4);
            }
        }

        public string Escalao
        {
            get { return escalao; }
            set
            {
                escalao = value;
                RaisePropertyChanged("Escalao");
            }
        }

        //public List<Prova> ProvasParticipadas;
        //public List<Premio> PremiosGanhos;        

        public Atleta()
        {

        }

    }
}
