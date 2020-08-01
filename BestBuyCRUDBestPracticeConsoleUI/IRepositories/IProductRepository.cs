using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUDBestPracticeConsoleUI
{
    interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        void CreateProduct(string name, decimal price, int categoryID);
    }
    
}
