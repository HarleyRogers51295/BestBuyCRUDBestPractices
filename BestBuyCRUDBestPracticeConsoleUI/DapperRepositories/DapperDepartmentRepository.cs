using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace BestBuyCRUDBestPracticeConsoleUI
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        //field or local variable for making quiries to the database
        private readonly IDbConnection _connection; //feild


        //constructor
        public DapperDepartmentRepository(IDbConnection connection)//making a connection 
        {
            _connection = connection;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            //here we do the magic! Put in the SQL needs to be the same name as on SQL.
            var depos = _connection.Query<Department>("SELECT * FROM departments");
            return depos;
        }

        public void InsertDepartment(string newDepartmentName)//you need to know the data type for this.
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
            new { departmentName = newDepartmentName }); //anonymous type. creates whatever type we want

        }
        public void DeleteDepartment(int DepID)
        {
            _connection.Execute("DELETE FROM Departments WHERE DepartmentID = @ID;", new { ID = DepID });
        }

    }
}
