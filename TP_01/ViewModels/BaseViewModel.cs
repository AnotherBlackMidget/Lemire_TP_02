using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_02.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TP_02.UI.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public RelayCommand<IClosable> CloseWindowCommand { get; private set; }
        public BaseViewModel()
        {
            this.CloseWindowCommand = new RelayCommand<IClosable>(this.CloseWindow);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string PropertyName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        public void CloseWindow(IClosable window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
    }
}
