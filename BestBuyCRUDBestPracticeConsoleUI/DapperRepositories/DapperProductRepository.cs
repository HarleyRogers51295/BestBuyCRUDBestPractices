using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuyCRUDBestPracticeConsoleUI
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            var depos = _connection.Query<Product>("SELECT * FROM products");
            return depos;
        }
        public void CreateProduct(string newProductName, decimal newProductPrice, int newProductCategoryID)
        {
            _connection.Execute("INSERT INTO PRODUCTS(Name, Price, CategoryID)VALUES(@Name, @Price, @ProductID);",
                new { Name = newProductName, Price = newProductPrice, ProductID = newProductCategoryID }); 
        }
        public void UpdateProduct(string column, string value, int id)
        {
            _connection.Execute($"UPDATE Products SET {column} = '{value}' WHERE ProductID = {id}");
        }
        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM Products WHERE ProductID = @ID;", new { ID = productID });
            _connection.Execute("DELETE FROM Sales WHERE ProductID = @ID;", new { ID = productID });
            _connection.Execute("DELETE FROM Reviews WHERE ProductID = @ID;", new { ID = productID });
        }


       
    }
}
