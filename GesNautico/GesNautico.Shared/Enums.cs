using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNautico.Shared
{
    public static class Enums
    {

        public enum TipoAtleta
        {
            Junior,
            Juvenil,
            Senior
        };

        
        public enum TipoColaborador
        {
            [Description("Funcionário")]
            Func,
            [Description("Treinador")]
            Trei
        };

        public enum TipoSocio
        {
            Socio
        };

        public enum TipoUtilizador
        {
            [Description("Administrativo")]
            Admin,
            [Description("Tesoureiro")]
            Tes,
            [Description("Presidente")]
            Pres
        };

        #region Estados
        public static List<string> Estados()
        {
            List<string> estados;
            estados = Shared.SharedSettings.Default.Estados.Cast<string>().ToList();
            return estados;
        }

        public static List<string> Estado()
        {
            List<string> estado;
            estado = Shared.SharedSettings.Default.Estado.Cast<string>().ToList();
            return estado;
        }
        #endregion

        #region Sexos
        public static List<string> Sexos()
        {
            List<string> sexos;
            sexos = Shared.SharedSettings.Default.Sexos.Cast<string>().ToList();
            return sexos;
        }
        #endregion

        #region Escalões
        public static List<string> EscalaoPesquisa()
        {
            List<string> escaloes;
            escaloes = Shared.SharedSettings.Default.EscalaoAtleta.Cast<string>().ToList();            
            return escaloes;
        }

        public static List<string> EscalaoGeral()
        {
            List<string> escaloes;
            escaloes = Shared.SharedSettings.Default.EscalaoAtleta.Cast<string>().ToList();
            escaloes.RemoveAt(0);
            return escaloes;
        }
        #endregion

    }
}
