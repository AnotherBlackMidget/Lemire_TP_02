using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TP_02.Models;
using System.Collections.ObjectModel;


namespace TP_02.UI.ViewModels
{
    class EmployeeViewModel : BaseViewModel
    {
        public ObservableCollection<Employee> Employees { get; set; }
        Employee _employee;

        public EmployeeViewModel()
        {
            Employees = new ObservableCollection<Employee>();

            _employee = new Employee() { WorkerId = 1, Name = "Dong Wang", CardId = 1 };
            Employees.Add(_employee);

            _employee = new Employee() { WorkerId = 2, Name = "Yong Wayne", CardId = 2 };
            Employees.Add(_employee);

            _employee = new Employee() { WorkerId = 3, Name = "Sum-Ting Wong", CardId = 3 };
            Employees.Add(_employee);

            _employee = new Employee() { WorkerId = 4, Name = "Wing Meng", CardId = 4 };
            Employees.Add(_employee);
        }
    }
}
