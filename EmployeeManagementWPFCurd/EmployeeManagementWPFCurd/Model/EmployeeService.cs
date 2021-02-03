using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementWPFCurd.Model
{
    class EmployeeService
    {
       private  ObservableCollection<Employee> _myEmployeeList;

        public EmployeeService()
        {
            _myEmployeeList = new ObservableCollection<Employee>
            {
                new Employee(1,"abc",22)
            };
        }

        public void Add(Employee employee)
        {
            _myEmployeeList.Add(employee);
        }

        public ObservableCollection<Employee> GetAllEmployees()
        {
            return _myEmployeeList;
        }

    }
}
