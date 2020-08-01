using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUDBestPracticeConsoleUI.Tables
{
    class Sales
    {
        public int SalesID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeID { get; set; }
    }
}
