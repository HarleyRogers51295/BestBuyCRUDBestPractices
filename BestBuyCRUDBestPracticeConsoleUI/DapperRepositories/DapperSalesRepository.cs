using BestBuyCRUDBestPracticeConsoleUI.IRepositories;
using BestBuyCRUDBestPracticeConsoleUI.Tables;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuyCRUDBestPracticeConsoleUI.DapperRepositories
{
    class DapperSalesRepository : ISalesRepository
    {
        private readonly IDbConnection _connection;

        public DapperSalesRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Sales> GetSales()
        {
            var depos = _connection.Query<Sales>("SELECT * FROM Sales ORDER BY quantity DESC");
            return depos;
        }
        public void CreateSale(decimal pricePerUnit, int quantity, DateTime date, int productID)
        {
            _connection.Execute("INSERT INTO sales(PricePerUnit, Quantity, Date, ProductID) VALUES(@pricePerUnit, @quantity, @date, @productID);",
               new { PricePerUnit = pricePerUnit, Quantity = quantity, Date = date, ProductID = productID });
        }
        public void UpdateSale(string column, string value, int id)
        {
            _connection.Execute($"UPDATE sales SET {column} = '{value}' WHERE SalesID = {id}");
        }
        public void DeleteSale(int salesID)
        {
            _connection.Execute("DELETE FROM Sales WHERE SalesID = @ID;", new { ID = salesID }); 
        }

        

        
    }
}
