using BestBuyCRUDBestPracticeConsoleUI.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUDBestPracticeConsoleUI.IRepositories
{
    interface IEmployeesRepository
    {
        IEnumerable<Employees> GetAllEmployees();
        void CreateEmployee(string firstName, string middleInitial, string lastName, string emailAddress, string phoneNumber, string title, DateTime dateOfBirth);
    }
}
