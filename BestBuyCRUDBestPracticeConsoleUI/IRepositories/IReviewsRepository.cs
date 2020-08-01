using BestBuyCRUDBestPracticeConsoleUI.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUDBestPracticeConsoleUI.IRepositories
{
    interface IReviewsRepository
    {
        IEnumerable<Reviews> GetAllReviews();
        
    }
}
