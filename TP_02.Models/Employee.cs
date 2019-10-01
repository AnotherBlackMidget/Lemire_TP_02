using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

using System.ComponentModel.DataAnnotations;

namespace TP_02.Models
{
    public class Employee : INotifyPropertyChanged
    {
        public int WorkerId { get; set; }

        public string Name { get; set; }

        public int CardId { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

    }
}
