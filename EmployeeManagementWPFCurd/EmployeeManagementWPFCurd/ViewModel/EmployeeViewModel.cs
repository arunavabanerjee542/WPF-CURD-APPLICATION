﻿using EmployeeManagementWPFCurd.Command;
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
        public RelayCommand Command { get; }
        public RelayCommand SearchCommand { get; }
        public RelayCommand UpdateCommand { get; }
        public RelayCommand DeleteCommand { get; }
        private EmployeeService _employeeService;
        public EmployeeViewModel()
        {           
             _employeeService = new EmployeeService();
             LoadData();
            MyEmployee = new Employee();
            Command = new RelayCommand(CanExecuteAdd, ExecuteAdd);
            SearchCommand = new RelayCommand(CanExecuteSearch, ExecuteSearch);
            UpdateCommand = new RelayCommand(CanExecuteUpdate, ExecuteUpdate);
            DeleteCommand = new RelayCommand(CanExecuteDelete, ExecuteDelete);
        }

        private ObservableCollection<Employee> _myCollection;
        public ObservableCollection<Employee> MyCollection
        {
            get { return _myCollection; }
            set { _myCollection = value;/* OnPropertyChanged("MyCollection");*/ }
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

        public bool CanExecuteAdd()
        {
            return true;
        }

        public void ExecuteAdd()
        {
            Employee e = new Employee(MyEmployee.Id, MyEmployee.Name, MyEmployee.Age);
            _employeeService.Add(e);
            LoadData();
        }

        public bool CanExecuteSearch()
        {
            return true;
        }

        public void ExecuteSearch()
        {
            var emp = _employeeService.Search(MyEmployee.Id);
            MyEmployee.Name = emp.Name;
            MyEmployee.Age = emp.Age;
            LoadData();
        }


        public bool CanExecuteUpdate()
        {
            return true;
        }

        public void ExecuteUpdate()
        {
            _employeeService.Update(MyEmployee);
            LoadData();
        }


        public bool CanExecuteDelete()
        {
            return true;
        }

        public void ExecuteDelete()
        {
            _employeeService.Delete(MyEmployee.Id);
            LoadData();
        }


    }
}
