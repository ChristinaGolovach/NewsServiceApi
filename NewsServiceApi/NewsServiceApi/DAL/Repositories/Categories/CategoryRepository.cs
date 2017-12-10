using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsServiceApi.DAL.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace NewsServiceApi.DAL.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _connectinString;
        private readonly IConfiguration _configuration;

        private IDbConnection _connection
        {
            get { return new MySqlConnection(_connectinString); }
        }

        public CategoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectinString = _configuration["Data:ConnectionString:MySqlConnection"];
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = "SELECT * FROM news_category";
                var categories = await dbConnection.QueryAsync<Category>(query);
                return categories;
            }
        }

    }
}
