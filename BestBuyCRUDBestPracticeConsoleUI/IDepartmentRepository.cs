using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUDBestPracticeConsoleUI
{
    interface IDepartmentRepository
    {
        //saying we need a mtethod called get all that returns
        //a collection that conforms to IEnumerable<T>
        IEnumerable<Department> GetAllDepartments();
        void InsertDepartment(string newDepartmentName);
    }

}
