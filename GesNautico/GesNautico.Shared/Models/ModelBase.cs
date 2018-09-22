using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNautico.Shared.Models
{
    public class ModelBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
