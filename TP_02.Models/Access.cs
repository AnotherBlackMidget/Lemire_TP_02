using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_02.Models
{
    public class Access : INotifyPropertyChanged
    {
        public int WorkerId { get; set; }

        public string Name { get; set; }

        public int CardId { get; set; }

        public int RoomId { get; set; }

        public string Desc { get; set; }

        public string Hours { get; set; }

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
