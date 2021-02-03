using EmployeeManagementWPFCurd.Command;
using EmployeeManagementWPFCurd.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementWPFCurd.ViewModel
{
    class EmployeeViewModel: INotifyPropertyChanged
    {

        public RelayCommand Command { get; set; }

        private EmployeeService _employeeService;
        public EmployeeViewModel()
        {
            Command = new RelayCommand(CanExecute,Execute);
            _employeeService = new EmployeeService();
            MyEmployee = new Employee();
            LoadData();
           // MyCollection = new ObservableCollection<Employee>();
           
        }

        private ObservableCollection<Employee> _myCollection;
        public ObservableCollection<Employee> MyCollection
        {
            get { return _myCollection; }
            set { _myCollection = value; OnPropertyChanged("MyCollection"); }
        }

        public void LoadData()
        {
            MyCollection = _employeeService.GetAllEmployees();
        }

        private Employee _employee;
        public Employee MyEmployee
        {
            get { return _employee; }
            set { _employee = value; OnPropertyChanged("MyEmployee"); }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }


        public bool CanExecute()
        {
            return true;
        }

        public void Execute()
        {
            _employeeService.Add(MyEmployee);
            LoadData();
        }






    }
}
