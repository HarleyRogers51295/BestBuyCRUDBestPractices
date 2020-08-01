using BestBuyCRUDBestPracticeConsoleUI.IRepositories;
using BestBuyCRUDBestPracticeConsoleUI.Tables;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuyCRUDBestPracticeConsoleUI.DapperRepositories
{
    class DapperReviewsRepository : IReviewsRepository
    {
        private readonly IDbConnection _connection;

        public DapperReviewsRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Reviews> GetAllReviews()
        {
            var depos = _connection.Query<Reviews>("SELECT * FROM reviews ORDER BY rating DESC ");
            return depos;
        }
               
    }
}
