﻿using Day9.IRepository;
using Day9.Models;

namespace Day9.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ITIEntities context;

        public EmployeeRepository(ITIEntities _context)
        {
            context = _context;
        }

        public List<Employee> GetAll() =>
            context.Employees.ToList();


        public Employee GetById(int id) =>
            context.Employees.FirstOrDefault(d => d.Id == id);


        public void Insert(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public void Edit(int id, Employee employee)
        {
            var oldEmp = GetById(id);
            oldEmp.Name = employee.Name;
            oldEmp.Address = employee.Address; 
            oldEmp.Age = employee.Age;
            oldEmp.Salary = employee.Salary;
            oldEmp.DeptId = employee.DeptId;
            

            context.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            context.Employees.Remove(employee);
            
            context.SaveChanges();
        }

        public List<Department> GetDepartments()
        {
            var departmetns = context.Departments.ToList();

            return departmetns;
        }
    }
}
