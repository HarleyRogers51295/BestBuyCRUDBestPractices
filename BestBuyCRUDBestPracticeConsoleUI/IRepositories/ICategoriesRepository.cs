using BestBuyCRUDBestPracticeConsoleUI.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUDBestPracticeConsoleUI.IRepositories
{
    interface ICategoriesRepository
    {
        IEnumerable<Categories> GetAllCategories();
        void InsertCategory(string newCategoryName, int depID);
    }
}
