using BestBuyCRUDBestPracticeConsoleUI.IRepositories;
using BestBuyCRUDBestPracticeConsoleUI.Tables;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuyCRUDBestPracticeConsoleUI.DapperRepositories
{
    class DapperEmployeesRepository : IEmployeesRepository
    {
        private readonly IDbConnection _connection;

        public DapperEmployeesRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Employees> GetAllEmployees()
        {
            var depos = _connection.Query<Employees>("SELECT * FROM employees");
            return depos;
        }
        public void CreateEmployee(string firstName, string middleInitial, string lastName, string emailAddress, string phoneNumber, string title, DateTime dateOfBirth)
        {
            _connection.Execute("INSERT INTO Employees(FirstName, MiddleInitial, LastName, EmailAddress, PhoneNumber, Title, DateOfBirth)" +
                "VALUES(@firstName, @middleInitial, @lastName, @emailAddress, @phoneNumber, @title, @dateOfBirth);",
                new { FirstName = firstName, MiddleInitial = middleInitial, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber, Title = title, DateOfBirth = dateOfBirth});
        }
        public void UpdateEmployee(string column, string value, int id)
        {
            _connection.Execute($"UPDATE employees SET {column} = '{value}' WHERE EmployeeID = {id}");
        }
        public void DeleteEmployee(int employeeID)
        {
            _connection.Execute("DELETE FROM employees WHERE EmployeeID = @ID;", new { ID = employeeID });
        }

        
    }

}
