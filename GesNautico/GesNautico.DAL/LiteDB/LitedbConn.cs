using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNautico.DAL.LiteDB
{
    public static class LitedbConn
    {
        public static string ConnString()
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(SettingsLitedb.Default.Path))
            {
                sb.Append(SettingsLitedb.Default.Path + "\\");
            }
            sb.Append(SettingsLitedb.Default.Filename);
            return sb.ToString();
        }

    }
}
