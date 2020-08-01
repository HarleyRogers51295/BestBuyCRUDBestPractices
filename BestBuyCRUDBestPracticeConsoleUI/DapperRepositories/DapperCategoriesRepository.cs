using BestBuyCRUDBestPracticeConsoleUI.IRepositories;
using BestBuyCRUDBestPracticeConsoleUI.Tables;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuyCRUDBestPracticeConsoleUI.DapperRepositories
{
    class DapperCategoriesRepository : ICategoriesRepository
    {
        private readonly IDbConnection _connection;

        public DapperCategoriesRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Categories> GetAllCategories()
        {
            var depos = _connection.Query<Categories>("SELECT * FROM categories");
            return depos;
        }

        public void InsertCategory(string newCategoryName, int departmentID)
        {
            _connection.Execute("INSERT INTO Categories (Name, DepartmentID) VALUES (@catName, @depID);",
            new { catName = newCategoryName, depID = departmentID });
        }
        public void DeleteCategory(int CatID)
        {
            _connection.Execute("DELETE FROM Categories WHERE CategoryID = @ID;", new { ID = CatID });
        }
    }
}
