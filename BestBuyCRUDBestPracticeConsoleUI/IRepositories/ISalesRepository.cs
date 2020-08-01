using BestBuyCRUDBestPracticeConsoleUI.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUDBestPracticeConsoleUI.IRepositories
{
    interface ISalesRepository
    {
        IEnumerable<Sales> GetSales();
        void CreateSale(decimal pricePerUnit, int quantity, DateTime date, int prodID );
    }
}
