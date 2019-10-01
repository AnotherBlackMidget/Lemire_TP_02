using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_02.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Diagnostics;
using System.ComponentModel;

namespace TP_02.UI.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Access> Test { get; set; }

        public RelayCommand<IOpenable> OpenWindowCommand { get; private set; }
        public RelayCommand NextCommand { get; private set; }
        public RelayCommand PrevCommand { get; private set; }
        public RelayCommand AddEmpCommand { get; private set; }
        public RelayCommand RemoveEmpCommand { get; private set; }
        public RelayCommand AddAccCommand { get; private set; }
        public RelayCommand RemoveAccCommand { get; private set; }
        

        EmployeeViewModel _employee;
        AccessViewModel _access;
        int iter;

        public Access SelectedItem { get; set; }

        public MainViewModel()
        {
            this.OpenWindowCommand = new RelayCommand<IOpenable>(this.OpenWindow);
            this.NextCommand = new RelayCommand(this.Next);
            this.PrevCommand = new RelayCommand(this.Prev);
            this.AddEmpCommand = new RelayCommand(this.AddEmp);
            this.RemoveEmpCommand = new RelayCommand(this.RemoveEmp);
            this.AddAccCommand = new RelayCommand(this.AddAcc);
            this.RemoveAccCommand = new RelayCommand(this.RemoveAcc);
            _employee = new EmployeeViewModel();
            _access = new AccessViewModel();
            iter = 0;
        }


        private void OpenWindow(IOpenable window)
        {
            SecondWindow secWin = new SecondWindow();
            secWin.Show();
            CloseWindow(window);
        }

        private void Next()
        {
            if(iter < _employee.Employees.Count-1)
            {
                iter++;
                OnPropertyChanged("Employee");
                OnPropertyChanged("Access");
            }
        }

        private void Prev()
        {
            if (iter > 0)
            {
                iter--;
                OnPropertyChanged("Employee");
                OnPropertyChanged("Access");
            }
        }

        private void AddEmp()
        {
            iter = _employee.Employees.Count;
            Employee _newEmp = new Employee(){ WorkerId = iter+1, Name = "New Employee", CardId = iter+1 };
            _employee.Employees.Add(_newEmp);
            OnPropertyChanged("Employee");
            OnPropertyChanged("Access");
        }

        private void RemoveEmp()
        {
            if (_employee.Employees.Count > 0) _employee.Employees.RemoveAt(iter);
            if(iter>0) iter--;         
            OnPropertyChanged("Employee");
            OnPropertyChanged("Access");
        }
        private void AddAcc()
        {
            if (_employee.Employees.Count > 0)
            {
                Access _newAcc = new Access() { WorkerId = _employee.Employees[iter].WorkerId, Name = _employee.Employees[iter].Name, CardId = _employee.Employees[iter].CardId, RoomId = 0, Desc = "New Room", Hours = "00h00 - 24h00" };
                _access.Accesses.Add(_newAcc);
            }
            OnPropertyChanged("Access");
        }

        private void RemoveAcc()
        {
            _access.Accesses.Remove(SelectedItem);
            OnPropertyChanged("Employee");
            OnPropertyChanged("Access");
        }

        public Employee Employee
        {
            get { try {return _employee.Employees[iter];} catch { return null; }}
        }

        public IEnumerable<Access> Access
        {
            get
            {
                if (_employee.Employees.Count > 0)
                {
                    return _access.Accesses.Where(a => a.WorkerId == _employee.Employees[iter].WorkerId);
                }
                else return null;
            }
        }
    }
}
