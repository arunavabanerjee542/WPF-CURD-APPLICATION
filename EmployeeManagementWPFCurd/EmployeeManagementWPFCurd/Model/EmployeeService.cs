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

        public ObservableCollection<Employee> GetAllEmployees()
        {
            return _myEmployeeList;
        }

        public void Add(Employee employee)
        {
            _myEmployeeList.Add(employee);
        }

        public Employee Search(int id)
        {
           return  _myEmployeeList.Where(x => x.Id == id).SingleOrDefault();
        }


        public void Update(Employee e)
        {
            _myEmployeeList.Where(ee => ee.Id == e.Id).FirstOrDefault().Id = e.Id;
            _myEmployeeList.Where(ee => ee.Id == e.Id).FirstOrDefault().Name = e.Name;
            _myEmployeeList.Where(ee => ee.Id == e.Id).FirstOrDefault().Age = e.Age;
        }

        public void Delete(int id)
        {
            _myEmployeeList.Remove(_myEmployeeList.Where(ee => ee.Id == id).FirstOrDefault());
        }


    }
}
